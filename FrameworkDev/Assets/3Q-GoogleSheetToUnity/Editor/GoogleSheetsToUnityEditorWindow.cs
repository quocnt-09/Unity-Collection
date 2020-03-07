using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Q.Extension;
using UnityEditor;
using UnityEngine;

namespace GoogleSheetsToUnity.Editor
{
    public class GoogleSheetsToUnityEditorWindow : EditorWindow
    {
        private static readonly string exportFolder = "GSTU_Export";

        private readonly string _folderPath = $"Assets/{exportFolder}";
        private readonly string _sheetSettingAsset = "SheetSetting";
        private readonly string _gstuAPIsConfig = "GSTU_Config";
        private readonly string _resourcePath = $"Assets/{exportFolder}/Resources";

        private GoogleSheetsToUnityConfig config;
        private SheetSetting _sheetSetting;
        private QueueAction _queue;
        private bool showSecret = false;
        private Vector2 scrollPosition;
        private bool expandAll;
        private float process = 0;
        private bool isBuildText;

        [MenuItem("3Q/Google Sheet To Unity")]
        public static void Open()
        {
            var win = GetWindow<GoogleSheetsToUnityEditorWindow>("GSTU Build Connection");
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            win.Init();
        }

        private static bool Validator(object in_sender, X509Certificate in_certificate, X509Chain in_chain, SslPolicyErrors in_sslPolicyErrors)
        {
            return true;
        }

        public void Init()
        {
            config = (GoogleSheetsToUnityConfig) Resources.Load(_gstuAPIsConfig);
            var finds = AssetDatabase.FindAssets($"t:{_sheetSettingAsset}", null);
            foreach (var item in finds)
            {
                var path = AssetDatabase.GUIDToAssetPath(item);
                _sheetSetting = AssetDatabase.LoadAssetAtPath<SheetSetting>(path);
            }

            if (_queue == null)
            {
                _queue = new QueueAction();
            }
        }

        private void OnEnable()
        {
            if (_queue == null)
            {
                _queue = new QueueAction();
            }
        }

        public void OnGUI()
        {
            BuildConnection();

            DrawLocalization();
        }

        private void DrawLocalization()
        {
            if (_sheetSetting == null)
            {
                GUILayout.Label("Create GSTU Setting", EditorStyles.boldLabel);
                GUI.backgroundColor = Color.red;
                if (!GUILayout.Button("Create", GUILayout.Height(30))) return;

                if (AssetDatabase.IsValidFolder(_folderPath))
                {
                    _sheetSetting = CreateInstance<SheetSetting>();
                    AssetDatabase.CreateAsset(_sheetSetting, $"{_folderPath}/{_sheetSettingAsset}.asset");

                    config = CreateInstance<GoogleSheetsToUnityConfig>();
                    AssetDatabase.CreateAsset(config, $"{_resourcePath}/{_gstuAPIsConfig}.asset");
                }
                else
                {
                    //create export folder
                    AssetDatabase.CreateFolder("Assets", exportFolder);

                    //create export resource folder
                    AssetDatabase.CreateFolder(_folderPath, "Resources");

                    //create export scripts folder
                    AssetDatabase.CreateFolder(_folderPath, "Scripts");

                    //
                    _sheetSetting = CreateInstance<SheetSetting>();
                    AssetDatabase.CreateAsset(_sheetSetting, $"{_folderPath}/{_sheetSettingAsset}.asset");

                    config = CreateInstance<GoogleSheetsToUnityConfig>();
                    AssetDatabase.CreateAsset(config, $"{_resourcePath}/{_gstuAPIsConfig}.asset");
                }

                AssetDatabase.SaveAssets();
            }
            else
            {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition);
                GUILayout.Label("");
                GUILayout.Label("Google Sheet Config", EditorStyles.boldLabel);
                for (int i = 0; i < _sheetSetting.GoogleSheets.Count; i++)
                {
                    DrawSheetConfig(i + 1, _sheetSetting.GoogleSheets[i]);
                    GUI.backgroundColor = Color.white;
                }

                GUILayout.EndScrollView();

                GUILayout.BeginHorizontal();

                if (GUILayout.Button("Add Google Sheet"))
                {
                    _sheetSetting.GoogleSheets.Add(new SheetConfig());
                }

                if (GUILayout.Button("Expand"))
                {
                    expandAll = !expandAll;
                    for (int i = 0; i < _sheetSetting.GoogleSheets.Count; i++)
                    {
                        _sheetSetting.GoogleSheets[i].isExpand = expandAll;
                    }
                }

                GUI.backgroundColor = Color.yellow;
                if (GUILayout.Button("Save Asset"))
                {
                    EditorUtility.SetDirty(config);
                    EditorUtility.SetDirty(_sheetSetting);
                    AssetDatabase.SaveAssets();
                }

                GUI.backgroundColor = Color.white;
                GUILayout.EndHorizontal();

                GUILayout.Label("");
                GUILayout.Label("Download & Export data", EditorStyles.boldLabel);
                GUI.backgroundColor = Color.green;
                if (GUILayout.Button("Export data", GUILayout.Height(30)))
                {
                    OnImportClicked();
                }

                GUILayout.Label("", GUILayout.Height(110));
            }
        }

        private void BuildConnection()
        {
            if (config == null)
            {
                Debug.LogError("Error: no config file");
                return;
            }

            GUILayout.Label("API Config Setting", EditorStyles.boldLabel);

            config.CLIENT_ID = EditorGUILayout.TextField("Client ID", config.CLIENT_ID);

            GUILayout.BeginHorizontal();
            config.CLIENT_SECRET = showSecret ? EditorGUILayout.TextField("Client Secret Code", config.CLIENT_SECRET) : EditorGUILayout.PasswordField("Client Secret Code", config.CLIENT_SECRET);

            showSecret = GUILayout.Toggle(showSecret, "Show");
            GUILayout.EndHorizontal();

            config.PORT = EditorGUILayout.IntField("Port number", config.PORT);

            GUI.backgroundColor = Color.yellow;
            if (GUILayout.Button("Build Connection", GUILayout.Height(30)))
            {
                GoogleAuthrisationHelper.BuildHttpListener();
            }

            GUI.backgroundColor = Color.white;

            EditorUtility.SetDirty(config);
        }

        public void DrawSheetConfig(int index, SheetConfig sheetConfig)
        {
            GUI.backgroundColor = sheetConfig.isExpand ? index % 2 == 0 ? Color.cyan : Color.green : Color.white;
            sheetConfig.isExpand = EditorGUILayout.BeginFoldoutHeaderGroup(sheetConfig.isExpand, $"Google Sheet {index}: {sheetConfig.spreadSheetKey}");
            GUI.backgroundColor = Color.white;
            if (sheetConfig.isExpand)
            {
                GUILayout.Label("Sheet Config Setting", EditorStyles.helpBox);
                sheetConfig.spreadSheetKey = EditorGUILayout.TextField("Spread sheet key", sheetConfig.spreadSheetKey);

                GUILayout.Label("Sheet Names", EditorStyles.helpBox);

                int removeId = -1;
                for (int i = 0; i < sheetConfig.sheetNames.Count; i++)
                {
                    GUILayout.BeginHorizontal();

                    GUILayout.Label($"Sheet {i}:", GUILayout.Width(60));
                    sheetConfig.sheetNames[i].name = EditorGUILayout.TextField(sheetConfig.sheetNames[i].name);

                    GUILayout.Label("Start Cell:", GUILayout.Width(65));
                    sheetConfig.sheetNames[i].startCell = EditorGUILayout.TextField(sheetConfig.sheetNames[i].startCell, GUILayout.Width(70));

                    GUILayout.Label("End Cell:", GUILayout.Width(65));
                    sheetConfig.sheetNames[i].endCell = EditorGUILayout.TextField(sheetConfig.sheetNames[i].endCell, GUILayout.Width(70));

                    GUILayout.Label("Text:", GUILayout.Width(30));
                    sheetConfig.sheetNames[i].buildText = GUILayout.Toggle(sheetConfig.sheetNames[i].buildText, "", GUILayout.Width(20));

                    GUI.backgroundColor = Color.red;
                    if (GUILayout.Button("X", EditorStyles.miniButton, GUILayout.Width(40)))
                    {
                        if (EditorUtility.DisplayDialog("Note!", $"You will remove sheet {sheetConfig.sheetNames[i].name}. Are you sure?", "Oke", "No"))
                        {
                            removeId = i;
                        }
                    }

                    GUI.backgroundColor = Color.white;
                    GUILayout.EndHorizontal();
                }

                if (removeId >= 0) sheetConfig.sheetNames.RemoveAt(removeId);
                GUILayout.Label(sheetConfig.sheetNames.Count <= 0 ? "Download all sheets" : $"Download {sheetConfig.sheetNames.Count} sheets");

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Add sheet name", GUILayout.Width(150)))
                {
                    sheetConfig.sheetNames.Add(new SheetName {name = "", buildText = false});
                }

                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("X", GUILayout.Width(40)))
                {
                    if (EditorUtility.DisplayDialog("Note!", $"You will remove google sheet. Are you sure?", "Oke", "No"))
                    {
                        _sheetSetting.GoogleSheets.Remove(sheetConfig);
                    }
                }

                GUI.backgroundColor = Color.white;
                GUILayout.EndHorizontal();
            }

            GUILayout.Label("");
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        float GetProcess()
        {
            return process;
        }

        void OnImportClicked()
        {
            _queue = new QueueAction();
            if (!AssetDatabase.IsValidFolder(_folderPath + "/Resources"))
            {
                AssetDatabase.CreateFolder(_folderPath, "Resources");
            }

            if (!AssetDatabase.IsValidFolder(_folderPath + "/Scripts"))
            {
                AssetDatabase.CreateFolder(_folderPath, "Scripts");
            }

            EditorUtility.ClearProgressBar();

            foreach (var ggSheet in _sheetSetting.GoogleSheets)
            {
                foreach (var sheet in ggSheet.sheetNames)
                {
                    var sheetName = sheet.name;
                    var startCell = sheet.startCell;
                    var endCell = sheet.endCell;
                    var buildText = sheet.buildText;

                    _queue.AddQueue(new Action<string, string, string, string, bool>(ExportSheet), new object[] {ggSheet.spreadSheetKey, sheetName, startCell, endCell, buildText});
                }
            }

            _queue.NextAction(true);
        }

        private void ExportSheet(string sheetId, string sheetName, string startCell, string endCell, bool buildText)
        {
            isBuildText = buildText;
            Debug.Log($"sheetName: {sheetName}");
            EditorUtility.DisplayProgressBar("Reading From Google Sheet ", $"Sheet: {sheetName}", GetProcess());
            var gstuSearch = new GSTU_Search(sheetId, sheetName, startCell, endCell);
            SpreadsheetManager.Read(gstuSearch, ReadSheetCallback);
        }

        void ReadSheetCallback(GstuSpreadSheet sheet)
        {
            EditorUtility.ClearProgressBar();
            process = 0;
            if (sheet != null)
            {
                Debug.Log($"Total Row Count: {sheet.rows.primaryDictionary.Count}");
                if (isBuildText)
                {
                    BuildText(sheet, OnCompleteRead);
                }
                else
                {
                    ExportData(sheet, OnCompleteRead);
                }
            }
        }

        private void OnCompleteRead()
        {
            EditorUtility.ClearProgressBar();
            _queue.Done(true);
        }

        struct DataType
        {
            public string _type;
            public string _name;

            public DataType(string n, string t)
            {
                _name = n;
                _type = t;
            }
        }

        private void ExportData(GstuSpreadSheet sheet, Action complete)
        {
            var sheetName = sheet.sheetName;
            var jsonPath = $"{Application.dataPath}/{exportFolder}/Resources/{sheetName}.json";
            var jsonString = "";

            bool isBuildKey = false;
            var dataTypes = new List<DataType>();
            var listBuildKeys = new Dictionary<string, List<object>>();
            //var listBuildArr = new Dictionary<string, List<List<object>>>();
            var listKeys = new List<string>();

            foreach (var key in sheet.columns.secondaryKeyLink.Keys)
            {
                var listValue = sheet.columns.GetValueFromSecondary(key);

                if (key.ToLower().Contains("[key]") || key.ToLower().Contains("[arr]"))
                {
                    isBuildKey = key.ToLower().Contains("[key]");
                    foreach (var text in listValue)
                    {
                        var kk = text.value;
                        if (!kk.Equals(key))
                        {
                            listKeys.Add(kk);
                            if (!listBuildKeys.ContainsKey(kk))
                            {
                                listBuildKeys.Add(kk, new List<object>());
                            }
                        }
                    }
                }
                else
                {
                    var slip = key.Split(':');
                    var typeName = slip[0];
                    var type = slip[1];
                    dataTypes.Add(new DataType(typeName, type));

                    var countKey = 0;
                    foreach (var text in listValue)
                    {
                        if (!text.value.Equals(key))
                        {
                            var value = text.value;
                            var keyData = listKeys[countKey];
                            countKey++;
                            if (listBuildKeys.TryGetValue(keyData, out var listValues))
                            {
                                listValues.Add(value);
                            }
                        }
                    }
                }
            }

            jsonString = "{\n";
            if (isBuildKey)
            {
                foreach (var key in listBuildKeys)
                {
                    jsonString += "\t\"" + key.Key + "\": {\n";
                    for (var i = 0; i < dataTypes.Count; i++)
                    {
                        var dataType = dataTypes[i];
                        var txtValue = "";
                        switch (dataType._type.ToLower())
                        {
                            case "str":
                            case "string":
                                txtValue = "\"" + key.Value[i] + "\"";
                                break;
                            default:
                                txtValue = key.Value[i].ToString();
                                break;
                        }

                        jsonString += "\t\t\"" + dataType._name + "\": " + txtValue + ",\n";
                    }

                    jsonString = jsonString.Substring(0, jsonString.Length - 2);
                    jsonString += "\n\t},\n";
                }
            }
            else
            {
                foreach (var key in listBuildKeys)
                {
                    jsonString += "\t\"" + key.Key + "\": [\n";

                    var numRow = key.Value.Count / dataTypes.Count;
                    for (int r = 0; r < numRow; r++)
                    {
                        jsonString += "\t\t{\n";
                        for (var c = 0; c < dataTypes.Count; c++)
                        {
                            var dataType = dataTypes[c];
                            var txtValue = "";
                            switch (dataType._type.ToLower())
                            {
                                case "str":
                                case "string":
                                    txtValue = "\"" + key.Value[c*numRow+r] + "\"";
                                    break;
                                default:
                                    txtValue = key.Value[c*numRow+r].ToString();
                                    break;
                            }

                            jsonString += "\t\t\t\"" + dataType._name + "\": " + txtValue + ",\n";
                        }
                        jsonString = jsonString.Substring(0, jsonString.Length - 2);
                        jsonString += "\n\t\t},\n";
                    }

                    jsonString = jsonString.Substring(0, jsonString.Length - 2);
                    jsonString += "\n\t],\n";
                }
            }
            jsonString = jsonString.Substring(0, jsonString.Length - 2);
            jsonString += "\n}";
            File.WriteAllText(jsonPath, jsonString);
            complete?.Invoke();
        }

        private void BuildText(GstuSpreadSheet sheet, Action complete)
        {
            var sheetName = sheet.sheetName;
            int count = 0;

            //Export Json file
            var stringValues = new List<string>();
            int countkey = 0;
            foreach (var key in sheet.columns.secondaryKeyLink.Keys)
            {
                if (!key.Equals("key") && !key.Contains("[") && !key.Contains("]"))
                {
                    var jsonPath = $"{Application.dataPath}/{exportFolder}/Resources/[{key}]{sheetName}.json";
                    var jsonString = "{\n" + "\t\"" + key + "\": [\n";

                    var ListValue = sheet.columns.GetValueFromSecondary(key);
                    var textValue = "";
                    foreach (var text in ListValue)
                    {
                        if (!text.value.Equals(key))
                        {
                            textValue += "\t\t\"" + text.value + "\",\n";
                            if (countkey == 0)
                            {
                                stringValues.Add(text.value);
                            }
                        }
                    }

                    jsonString += textValue;
                    jsonString += "\t]" + "\n}";
                    File.WriteAllText(jsonPath, jsonString);

                    countkey++;
                }
            }

            //Export class
            var classPath = $"{Application.dataPath}/{exportFolder}/Scripts/{sheetName}Container.cs";
            var classContent = ClassContent(sheetName);
            var ListKey = "";
            var ListLanguage = "";

            foreach (var key in sheet.columns.secondaryKeyLink.Keys)
            {
                if (!key.Contains("[") && !key.Contains("]"))
                {
                    if (key.Equals("key"))
                    {
                        var ListValue = sheet.columns.GetValueFromSecondary(key);
                        foreach (var text in ListValue)
                        {
                            if (!text.value.Equals(key))
                            {
                                ListKey += "\t\t\t" + text.value + ",\t\t//" + stringValues[count] + "\n";
                                process = count / (float) ListValue.Count;
                                count++;
                                EditorUtility.DisplayProgressBar("Reading From Google Sheet ", $"Sheet: {sheetName}/{text.value} - {count}/{ListValue.Count}", GetProcess());
                            }
                        }
                    }
                    else
                    {
                        ListLanguage += "\t\t\t\tcase \"" + key + "\":\n";
                        ListLanguage += "\t\t\t\t\tfileName = \"[" + key + "]" + sheetName + "\";\n";
                        ListLanguage += "\t\t\t\t\tbreak;\n\n";
                    }
                }
            }

            classContent = classContent.Replace("<ListKey>", ListKey);
            classContent = classContent.Replace("<ListLanguage>", ListLanguage);
            File.WriteAllText(classPath, classContent);
            complete?.Invoke();
        }

        string ClassContent(string sheetName)
        {
            var content = " /* * * * * *\n";
            content += " * Author: QuocNT\n";
            content += " * Email: ntq.quoc@gmail.com\n";
            content += " * * * * * */\n\n";

            content += "using System;\n";
            content += "using Q.SimpleJSON;\n";
            content += "using UnityEngine;\n\n";

            content += "namespace Q.GSTU.Extension\n";
            content += "{\n";

            //enum
            content += "\tpublic enum " + sheetName + "Key\n";
            content += "\t{\n";
            content += "<ListKey>";
            content += "\t}\n\n";

            //class
            content += "\tpublic static class " + sheetName + "Container\n";
            content += "\t{\n";
            content += "\t\tprivate static string[] ListText;\n";
            content += "\t\tprivate static int maxLength;\n\n";

            #region LoadText

            content += "\t\tpublic static void LoadText(string language)\n";
            content += "\t\t{\n";
            //content
            content += "\t\t\tvar fileName = \"\";\n";
            content += "\t\t\tswitch (language)\n";
            content += "\t\t\t{\n";
            content += "<ListLanguage>\n";
            content += "\t\t\t}\n\n";

            content += "\t\t\ttry\n";
            content += "\t\t\t{\n";
            content += "\t\t\t\tvar jsonString = (Resources.Load(fileName) as TextAsset)?.text;\n";
            content += "\t\t\t\tvar nodes = JSON.Parse(jsonString);\n";
            content += "\t\t\t\tvar texts = (JSONArray) nodes[language];\n";
            content += "\t\t\t\tmaxLength = texts.Count;\n";
            content += "\t\t\t\tListText = new string[maxLength];\n\n";

            content += "\t\t\t\tvar i = 0;\n";
            content += "\t\t\t\tforeach (var text in texts)\n";
            content += "\t\t\t\t{\n";
            content += "\t\t\t\t\tListText[i] = text.Value;\ti++;\n";
            content += "\t\t\t\t}\n";

            content += "\t\t\t}\n";
            content += "\t\t\tcatch (Exception e)\n";
            content += "\t\t\t{\n";
            content += "\t\t\t\tDebug.LogError($\"" + sheetName + " can not load json file: {fileName} => err: {e}\");\n";
            content += "\t\t\t}\n";
            //end content
            content += "\t\t}\n\n";

            #endregion

            #region GetText

            content += "\t\tpublic static string GetText(" + sheetName + "Key key)\n";
            content += "\t\t{\n";
            //content
            content += "\t\t\ttry\n";
            content += "\t\t\t{\n";
            content += "\t\t\t\tif ((int) key < maxLength)\n";
            content += "\t\t\t\t{\n";
            content += "\t\t\t\t\treturn ListText[(int) key];\n";
            content += "\t\t\t\t}\n";
            content += "\t\t\t}\n";
            content += "\t\t\tcatch (Exception e)\n";
            content += "\t\t\t{\n";
            content += "\t\t\t\tDebug.LogError($\"" + sheetName + " not exits key: {key} => err: {e}\");\n";
            content += "\t\t\t}\n\n";
            content += "\t\t\treturn key.ToString();\n";
            //end content
            content += "\t\t}\n";

            #endregion

            content += "\t}\n";
            content += "}";
            return content;
        }
    }
}