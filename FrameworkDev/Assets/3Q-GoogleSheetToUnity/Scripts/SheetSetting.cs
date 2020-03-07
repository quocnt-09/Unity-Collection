using System.Collections.Generic;
 using UnityEngine;
 
 [CreateAssetMenu(fileName = "SheetSetting", menuName = "3Q/Sheet Setting", order = 1)]
 public class SheetSetting : ScriptableObject
 {
     public string spreadSheetKey = "";
     public string startCell = "A1";
     public string endCell = "Z100";
     public List<string> SheetNames = new List<string>();
 }