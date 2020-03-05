using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

namespace GoogleSheetsToUnity.Editor
{
    public class GoogleSheetsToUnityEditorWindow : EditorWindow
    {
        const float DarkGray = 0.4f;
        const float LightGray = 0.9f;

        private string folderPath = "Assets/Localizations";
        private string assetFile = "LocalizationSetting.asset";
        private string resourcePath = "Assets/Localizations/Resources";

        GoogleSheetsToUnityConfig config;
        private LocalizedSetting localizedConfig;
        private bool showSecret = false;

        [MenuItem("3Q/Localization/Build Connection")]
        public static void Open()
        {
            GoogleSheetsToUnityEditorWindow win = GetWindow<GoogleSheetsToUnityEditorWindow>("Localization Build Connection");
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            win.Init();
        }

        public static bool Validator(object in_sender, X509Certificate in_certificate, X509Chain in_chain, SslPolicyErrors in_sslPolicyErrors)
        {
            return true;
        }

        public void Init()
        {
            config = (GoogleSheetsToUnityConfig) Resources.Load("GSTU_Config");
            var finds = AssetDatabase.FindAssets("t:LocalizedSetting", null);
            foreach (var item in finds)
            {
                var path = AssetDatabase.GUIDToAssetPath(item);
                localizedConfig = AssetDatabase.LoadAssetAtPath<LocalizedSetting>(path);
            }
        }

        void OnGUI()
        {
            BuildConnection();

            DrawLocalization();
        }

        private void DrawLocalization()
        {
            if (localizedConfig == null)
            {
                GUILayout.Label("Create Localization Setting", EditorStyles.boldLabel);
                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("Create", GUILayout.Height(30)))
                {
                    if (AssetDatabase.IsValidFolder(folderPath))
                    {
                        localizedConfig = CreateInstance<LocalizedSetting>();
                        AssetDatabase.CreateAsset(localizedConfig, $"{folderPath}/{assetFile}");

                        config = CreateInstance<GoogleSheetsToUnityConfig>();
                        AssetDatabase.CreateAsset(config, $"{resourcePath}/GSTU_Config.asset");
                    }
                    else
                    {
                        AssetDatabase.CreateFolder("Assets", "Localizations");
                        AssetDatabase.CreateFolder(folderPath, "Resources");
                        AssetDatabase.CreateFolder(folderPath, "Scripts");

                        localizedConfig = CreateInstance<LocalizedSetting>();
                        AssetDatabase.CreateAsset(localizedConfig, $"{folderPath}/{assetFile}");

                        config = CreateInstance<GoogleSheetsToUnityConfig>();
                        AssetDatabase.CreateAsset(config, $"{resourcePath}/GSTU_Config.asset");
                    }

                    AssetDatabase.SaveAssets();
                }
            }
            else
            {
                DrawSheetConfig();
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
            if (showSecret)
            {
                config.CLIENT_SECRET = EditorGUILayout.TextField("Client Secret Code", config.CLIENT_SECRET);
            }
            else
            {
                config.CLIENT_SECRET = EditorGUILayout.PasswordField("Client Secret Code", config.CLIENT_SECRET);
            }

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

        void DrawSheetConfig()
        {
            GUILayout.Label("");
            GUILayout.Label("Sheet Config Setting", EditorStyles.boldLabel);
            localizedConfig.spreadSheetKey = EditorGUILayout.TextField("Spread sheet key", localizedConfig.spreadSheetKey);

            GUILayout.Label("");
            GUILayout.Label("Sheet Names", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("These sheets below will be downloaded. Let the list blank (remove all items) if you want to download all sheets", MessageType.Info);

            int _removeId = -1;
            for (int i = 0; i < localizedConfig.SheetNames.Count; i++)
            {
                GUILayout.BeginHorizontal();
                localizedConfig.SheetNames[i] = EditorGUILayout.TextField(string.Format("Sheet {0}", i), localizedConfig.SheetNames[i]);
                if (GUILayout.Button("X", EditorStyles.toolbarButton, GUILayout.Width(20)))
                {
                    _removeId = i;
                }

                GUILayout.EndHorizontal();
            }

            if (_removeId >= 0) localizedConfig.SheetNames.RemoveAt(_removeId);
            if (localizedConfig.SheetNames.Count <= 0)
            {
                GUILayout.Label("Download all sheets");
            }
            else
                GUILayout.Label(string.Format("Download {0} sheets", localizedConfig.SheetNames.Count));

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add sheet name"))
            {
                localizedConfig.SheetNames.Add("");
            }

            if (GUILayout.Button("Save Asset"))
            {
                EditorUtility.SetDirty(config);
                EditorUtility.SetDirty(localizedConfig);
                AssetDatabase.SaveAssets();
            }

            GUILayout.EndHorizontal();

            GUILayout.Label("");
            GUILayout.Label("Download & Export data", EditorStyles.boldLabel);
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Export data", GUILayout.Height(30)))
            {
                OnImportClicked();
            }
        }

        private int process = 0;

        float GetProcess()
        {
            return process / 100f;
        }

        private int currentIndex = 0;

        void OnImportClicked()
        {
            if (!AssetDatabase.IsValidFolder(folderPath + "/Resources"))
            {
                AssetDatabase.CreateFolder(folderPath, "Resources");
            }

            if (!AssetDatabase.IsValidFolder(folderPath + "/Scripts"))
            {
                AssetDatabase.CreateFolder(folderPath, "Scripts");
            }

            EditorUtility.ClearProgressBar();
            process = 0;
            currentIndex = 0;
            ExportSheet(localizedConfig.spreadSheetKey, localizedConfig.SheetNames[currentIndex]);
        }

        void ExportSheet(string sheetId, string sheetName)
        {
            Debug.Log($"sheetName: {sheetName}");
            EditorUtility.DisplayProgressBar("Reading From Google Sheet ", $"Sheet: {sheetName}", GetProcess());
            var gstuSearch = new GSTU_Search(sheetId, sheetName, "A1", "Z10000");
            SpreadsheetManager.Read(gstuSearch, ReadSheetCallback);
        }

        void OnCompleteRead()
        {
            currentIndex++;
            if (currentIndex < localizedConfig.SheetNames.Count)
            {
                ExportSheet(localizedConfig.spreadSheetKey, localizedConfig.SheetNames[currentIndex]);
            }
            else
            {
                EditorUtility.ClearProgressBar();
            }
        }

        void ReadSheetCallback(GstuSpreadSheet sheet)
        {
            if (sheet != null)
            {
                Debug.Log($"Total Row Count: {sheet.rows.primaryDictionary.Count}");
                ExportData(sheet, (currentIndex + 1) * (100 / (float) localizedConfig.SheetNames.Count), OnCompleteRead);
            }
        }

        private void ExportData(GstuSpreadSheet sheet, float targetPer, Action complete)
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
                    var jsonPath = $"{Application.dataPath}/Localizations/Resources/[{key}]{sheetName}.json";
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
            var classPath = $"{Application.dataPath}/Localizations/Scripts/{sheetName}Container.cs";
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
                                process = (int) (targetPer * (count / (float) ListValue.Count));
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
            content += " * Author: Quoc Nguyen\n";
            content += " * Email: ntq.quoc@gmail.com\n";
            content += " * * * * * */\n\n";

            content += "using System;\n";
            content += "using Quocnt.SimpleJSON;\n";
            content += "using UnityEngine;\n\n";

            content += "namespace Localization.Extension\n";
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

