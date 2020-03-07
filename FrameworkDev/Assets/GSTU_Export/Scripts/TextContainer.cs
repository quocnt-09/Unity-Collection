 /* * * * * *
 * Author: QuocNT
 * Email: ntq.quoc@gmail.com
 * * * * * */

using System;
using Q.SimpleJSON;
using UnityEngine;

namespace Q.GSTU.Extension
{
	public enum TextKey
	{
			PREPARE_ATTACK_0,		//Available loot:
			PREPARE_ATTACK_1,		//Defeat:
			PREPARE_ATTACK_2,		//Battle starts in:
			PREPARE_ATTACK_3,		//Hold both sides to start attacking
			PREPARE_ATTACK_4,		//End Battle
			PREPARE_ATTACK_5,		//Next
			PREPARE_ATTACK_6,		//ENGAGE
			BASE_BATTLE_2,		//Battle starts
	}

	public static class TextContainer
	{
		private static string[] ListText;
		private static int maxLength;

		public static void LoadText(string language)
		{
			var fileName = "";
			switch (language)
			{
				case "en":
					fileName = "[en]Text";
					break;

				case "vi":
					fileName = "[vi]Text";
					break;

				case "fr":
					fileName = "[fr]Text";
					break;

				case "de":
					fileName = "[de]Text";
					break;

				case "pt":
					fileName = "[pt]Text";
					break;

				case "es":
					fileName = "[es]Text";
					break;

				case "zh":
					fileName = "[zh]Text";
					break;

				case "ja":
					fileName = "[ja]Text";
					break;

				case "ko":
					fileName = "[ko]Text";
					break;

				case "ru":
					fileName = "[ru]Text";
					break;


			}

			try
			{
				var jsonString = (Resources.Load(fileName) as TextAsset)?.text;
				var nodes = JSON.Parse(jsonString);
				var texts = (JSONArray) nodes[language];
				maxLength = texts.Count;
				ListText = new string[maxLength];

				var i = 0;
				foreach (var text in texts)
				{
					ListText[i] = text.Value;	i++;
				}
			}
			catch (Exception e)
			{
				Debug.LogError($"Text can not load json file: {fileName} => err: {e}");
			}
		}

		public static string GetText(TextKey key)
		{
			try
			{
				if ((int) key < maxLength)
				{
					return ListText[(int) key];
				}
			}
			catch (Exception e)
			{
				Debug.LogError($"Text not exits key: {key} => err: {e}");
			}

			return key.ToString();
		}
	}
}