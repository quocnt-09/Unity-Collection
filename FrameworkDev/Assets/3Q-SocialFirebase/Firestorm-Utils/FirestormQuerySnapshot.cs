using System;
using System.Collections.Generic;
using Q.LitJson;

namespace Q.Firebase
{
    [Serializable]
    public struct FirestormQuerySnapshot
    {
        private List<FirestormDocumentSnapshot> documents;
        public IEnumerable<FirestormDocumentSnapshot> Documents => documents;
        public int Count => documents.Count;

        public FirestormQuerySnapshot(string collectionJson)
        {
            documents = new List<FirestormDocumentSnapshot>();
            var jo = JsonMapper.ToObject(collectionJson);
            if (jo.ContainsKey("documents"))
            {
                foreach (JsonData tk in jo["documents"])
                {
                    documents.Add(new FirestormDocumentSnapshot(tk.ToJson()));
                }
            }
            else if (jo.Count == 0)
            {
                return;
            }
            else
            {
                throw new FirestormException($"Did not expect non-empty and not having documents at root..");
            }
        }
    }
}