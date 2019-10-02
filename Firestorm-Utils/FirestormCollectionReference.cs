using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QNT.LitJson;
using UnityEngine;

namespace QNT.Firebase
{
    public struct FirestormCollectionReference
    {
        internal StringBuilder stringBuilder;

        private string parentDocument;
        private string collectionName;

        public FirestormCollectionReference(string name)
        {
            stringBuilder = new StringBuilder($"/{name}");
            parentDocument = "";
            collectionName = name;
        }

        public FirestormCollectionReference(FirestormDocumentReference sb, string name)
        {
            parentDocument = sb.stringBuilder.ToString();
            collectionName = name;
            this.stringBuilder = sb.stringBuilder;
            this.stringBuilder.Append($"/{name}");
        }

        public FirestormDocumentReference Document(string name) => new FirestormDocumentReference(this, name);

        /// <summary>
        /// Get all documents in the collection.
        /// Pagination, ordering, field masking, missing document, and transactions are not supported.
        /// </summary>
        public async Task<FirestormQuerySnapshot> GetSnapshotAsync()
        {
            var uwr = await FirestormConfig.Instance.UWRGet(stringBuilder.ToString());
            Debug.Log($"Getting query snapshot : {uwr.downloadHandler.text} {uwr.error}");
            return new FirestormQuerySnapshot(uwr.downloadHandler.text);
        }

        /// <typeparam name="string">A Firebase-generated new document ID</typeparam>
        public async Task<string> AddAsync<T>(T documentData) where T : class, new()
        {
            string documentJson = FirestormUtility.ToJsonDocument(documentData, "");
            byte[] postData = Encoding.UTF8.GetBytes(documentJson);

            //The URL must NOT include document name
            var uwr = await FirestormConfig.Instance.UWRPost(stringBuilder.ToString(), new (string, string)[] { }, postData);
            return new FirestormDocumentSnapshot(uwr.downloadHandler.text).Name;
        }

        /// <summary>
        /// The real C# API will be .WhereGreaterThan .WhereLessThan etc. methods. I am just too lazy to imitate them all.
        /// Runs against only immediate descendant documents of this collection.
        /// </summary>
        /// <summary>
        /// <param name="operationString">The same strig as in Javascript API such as "==", "<", "<=", ">", ">=", "array_contains".
        /// They may add more than this in the future. "array_contains" was added later.</param>
        public async Task<FirestormQuerySnapshot> GetSnapshotAsync(params (string fieldName, string operationString, object target)[] queries)
        {
            RunQuery rq = default;

            var fieldFilters = new List<FieldFilter>();

            for (int i = 0; i < queries.Length; i++)
            {
                var query = queries[i];

                var filter = new FieldFilter();

                filter.field = new FieldReference {fieldPath = query.fieldName};
                filter.op = StringToOperator(query.operationString).ToString();
                var formatted = FirestormUtility.FormatForValueJson(query.target);
                filter.value = new Dictionary<string, object> {[formatted.typeString] = formatted.objectForJson,};
                fieldFilters.Add(filter);
            }

            //fieldFilters.Sort();
            //rq.structuredQuery.orderBy = fieldFilters.Select(x => new Order { field = x.field }).ToArray();

            if (queries.Length == 1)
            {
                rq.structuredQuery.where = new Dictionary<string, IFilter> {["fieldFilter"] = fieldFilters[0],};
            }
            else if (queries.Length > 1)
            {
                CompositeFilter cf = new CompositeFilter {op = Operator.AND.ToString(), filters = fieldFilters.Select(x => new FilterForFieldFilter {fieldFilter = x}).ToArray(),};
                rq.structuredQuery.where = new Dictionary<string, IFilter> {["compositeFilter"] = cf};
            }
            else
            {
                throw new FirestormException($"Query length {queries.Length} invalid!");
            }

            //Apparently REST API can query from more than 1 collection at once!
            //But since this class is a "CollectionReference", it should represent only this collection. So always 1 element in this array.
            rq.structuredQuery.from = new CollectionSelector[] {new CollectionSelector {collectionId = collectionName, allDescendants = false,}};

            string postJson = JsonMapper.ToJson(rq);
            //File.WriteAllText(Application.dataPath + $"/LITPOST{UnityEngine.Random.Range(0, 100)}.txt", postJson);
            byte[] postData = Encoding.UTF8.GetBytes(postJson);
            Debug.Log($"JPOST {postJson}");

            //Path is the parent of this collection.
            var uwr = await FirestormConfig.Instance.UWRPost($"{parentDocument}:runQuery", null, postData);
            //File.WriteAllText(Application.dataPath + $"/{UnityEngine.Random.Range(0, 100)}.txt", uwr.downloadHandler.text);

            //Make the format looks like the one came back from "list" REST API
            JsonData jd = JsonMapper.ToObject(uwr.downloadHandler.text);

            //First layer is json array
            List<string> collect = new List<string>();
            foreach (JsonData arrayItem in jd)
            {
                if (arrayItem.ContainsKey("document"))
                {
                    collect.Add(arrayItem["document"].ToJson());
                }
            }

            string newJo = "{ \"documents\" : [ " + string.Join(",", collect) + " ] }";

            //Debug.Log($"this is new jo {newJo}");
            return new FirestormQuerySnapshot(newJo);
        }

        public string GetQueryStringCustom(
            (string fieldName, string operationString, object target)[] qrWhere, 
            (string fieldName, string direction)[] qrOrderBy = null, 
            string[] qrSelect = null, 
            int qrOffset = -1, 
            int qrLimit = -1,
            object[] qrStartAt = null, bool beforeStartAt = false, 
            object[] qrEndAt = null, bool beforeEndAt = false)
        {
            var dictionary = new Dictionary<string, object>();
            var structuredQuery = new Dictionary<string, object>();

            #region SELLECT

            if (qrSelect != null)
            {
                structuredQuery.Add("select", new Projection
                {
                    fields = qrSelect.Select(select => new FieldReference
                    {
                        fieldPath = select
                    }).ToArray()
                });
            }

            #endregion

            #region FORM

            structuredQuery.Add("from", new[]
            {
                new CollectionSelector
                {
                    collectionId = collectionName, 
                    allDescendants = false,
                }
            });

            #endregion

            #region WHERE

            if (qrWhere != null)
            {
                var fieldFilters = new List<FieldFilter>();
                foreach (var (fieldName, operationString, target) in qrWhere)
                {
                    var filter = new FieldFilter
                    {
                        field = new FieldReference
                        {
                            fieldPath = fieldName
                        }, 
                        op = StringToOperator(operationString).ToString()
                    };

                    var (typeString, objectForJson) = FirestormUtility.FormatForValueJson(target);
                    filter.value = new Dictionary<string, object>
                    {
                        [typeString] = objectForJson,
                    };
                    fieldFilters.Add(filter);
                }

                if (qrWhere.Length == 1)
                {
                    structuredQuery.Add("where", new Dictionary<string, IFilter>
                    {
                        ["fieldFilter"] = fieldFilters[0]
                    });
                }
                else if (qrWhere.Length > 1)
                {
                    var cf = new CompositeFilter
                    {
                        op = Operator.AND.ToString(), 
                        filters = fieldFilters.Select(x => new FilterForFieldFilter
                        {
                            fieldFilter = x
                        }).ToArray(),
                    };
                    structuredQuery.Add("where", new Dictionary<string, IFilter>
                    {
                        ["compositeFilter"] = cf
                    });
                }
            }

            #endregion

            #region ORDERBY

            if (qrOrderBy != null)
            {
                structuredQuery.Add("orderBy", qrOrderBy.Select(order => new Order
                {
                    field = new FieldReference
                    {
                        fieldPath = order.fieldName,
                    }, direction = StringToDirection(order.direction).ToString(),
                }).ToArray());
            }

            #endregion

            if (qrOffset >= 0)
            {
                structuredQuery.Add("offset", qrOffset);
            }

            if (qrLimit >= 0)
            {
                structuredQuery.Add("limit", qrLimit);
            }

            dictionary.Add("structuredQuery", structuredQuery);

            var jsonWriter = new JsonWriter {PrettyPrint = true};
            JsonMapper.ToJson(dictionary, jsonWriter);
            var prettyPrint = jsonWriter.ToString();

            Debug.Log($"postJson: {prettyPrint}");
            File.WriteAllText($"{Application.dataPath}/postJson.json", prettyPrint);

            return JsonMapper.ToJson(dictionary);
        }

        private static Operator StringToOperator(string operatorString)
        {
            switch (operatorString)
            {
                case "==":
                    return Operator.EQUAL;
                case ">":
                    return Operator.GREATER_THAN;
                case "<":
                    return Operator.LESS_THAN;
                case ">=":
                    return Operator.GREATER_THAN_OR_EQUAL;
                case "<=":
                    return Operator.LESS_THAN_OR_EQUAL;
                case "array_contains":
                    return Operator.ARRAY_CONTAINS;
            }

            throw new FirestormException($"Operator {operatorString} not supported!");
        }

        private static Direction StringToDirection(string direction)
        {
            switch (direction)
            {
                case "asc":
                    return Direction.ASCENDING;
                case "desc":
                    return Direction.DESCENDING;
                default:
                    throw new FirestormException($"Direction {direction} not supported!");
            }
        }

        void GetTest()
        {
            var collectionReference = new FirestormCollectionReference("WTF");
            var text = collectionReference.GetQueryStringCustom(
                new (string fieldName, string operationString, object target)[] {("a", "<=", 1), ("qwe", "==", true)});

            Debug.Log(text);
        }

        void GetTestFull()
        {
            var collectionReference = new FirestormCollectionReference("WTF");
            var text = collectionReference.GetQueryStringCustom(
                new (string fieldName, string operationString, object target)[] {("a", "<=", 1), ("qwe", "==", true)}, 
                new[] {("test", "asc"), ("ar", "desc")}, 
                new[] {"123",},
                10, 
                5,
                new object[] {155, 454}, true, new object[] {"asd", true}, false);

            Debug.Log(text);
        }
        
        private struct RunQuery
        {
            public StructuredQuery structuredQuery;
        }

        private struct StructuredQuery
        {
            // public Projection select;

            //Only one of 3 types of filter allowed here
            public CollectionSelector[] from;

            public Dictionary<string, IFilter> where;
            //public Order[] orderBy;
        }

        private struct Projection
        {
            public FieldReference[] fields;
        }

        private struct Order
        {
            public FieldReference field;
            public string direction;
        }

        private struct Cursor
        {
            public Dictionary<string, object> values;
            public bool before;
        }

        private struct CollectionSelector
        {
            public string collectionId;
            public bool allDescendants;
        }

        private struct CompositeFilter : IFilter
        {
            public string op;
            public FilterForFieldFilter[] filters; //Composite to unary or to composite not supported
        }

        private struct FilterForFieldFilter
        {
            public FieldFilter fieldFilter;
        }

        private struct FieldFilter : IFilter, IComparable<FieldFilter>
        {
            public FieldReference field;
            public string op;
            public Dictionary<string, object> value;

            public int CompareTo(FieldFilter other)
            {
                switch (op)
                {
                    case ">":
                    case "<":
                    case ">=":
                    case "<=":
                        //Range filter have to come first = this instance is lesser
                        return -1;
                    default:
                        return this.field.fieldPath.CompareTo(other.field.fieldPath);
                }
            }
        }

        private struct FieldReference
        {
            public string fieldPath;
        }

        private enum Operator
        {
            OPERATOR_UNSPECIFIED,
            AND, //for composite only
            LESS_THAN,
            LESS_THAN_OR_EQUAL,
            GREATER_THAN,
            GREATER_THAN_OR_EQUAL,
            EQUAL,
            ARRAY_CONTAINS,
            IS_NAN, //not supported
            IS_NULL, //not supported
        }

        private enum Direction
        {
            DIRECTION_UNSPECIFIED,
            ASCENDING,
            DESCENDING,
        }

        private interface IFilter
        {
        }
    }
}