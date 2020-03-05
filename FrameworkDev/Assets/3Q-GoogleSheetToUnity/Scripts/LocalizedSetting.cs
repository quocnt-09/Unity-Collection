using System.Collections.Generic;
 using UnityEngine;
 
 [CreateAssetMenu(fileName = "LocalizationConfig", menuName = "3Q/Localization Setting", order = 1)]
 public class LocalizedSetting : ScriptableObject
 {
     public string spreadSheetKey = "";
     public string startCell = "A1";
     public string endCell = "Z100";
     public List<string> SheetNames = new List<string>();
 }