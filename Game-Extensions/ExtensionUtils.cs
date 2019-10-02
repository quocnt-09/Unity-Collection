using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace QNT.ExtensionUtil
{
    public static class ExtensionUtils
    {
        #region Encrypt && Decrypt

        public static string Encrypt(string input, string password)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(input);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
                using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() {Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform tr = trip.CreateEncryptor();
                    byte[] result = tr.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }

        public static string Decrypt(string input, string password)
        {
            byte[] data = Convert.FromBase64String(input);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
                using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() {Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform tr = trip.CreateDecryptor();
                    byte[] result = tr.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(result);
                }
            }
        }

        #endregion

        public static string TrimName(string name, string extent = "...", int numCharacter = 8)
        {
            var strName = "";

            strName = name.Length > numCharacter ? $"{name.Substring(0, numCharacter)}{extent}" : name;

            return strName;
        }

        #region ENUM

        public static T ToEnum<T>(this int value)
        {
            return (T) Enum.ToObject(typeof(T), value);
        }

        public static T ToEnum<T>(this string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }

        #endregion

        #region INT

        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static int ToIn(this bool value)
        {
            return value ? 1 : 0;
        }

        public static int ToInt(this string str)
        {
            str = str.Replace(",", "");

            int rs = 0;
            try
            {
                rs = int.Parse(str);
            }
            catch (Exception e)
            {
                Debug.LogError("Parse To Int Error: " + e);
            }

            return rs;
        }

        #endregion

        #region FLOAT

        public static float ToFloat(this string str)
        {
            str = str.Replace(",", "");

            float rs = 0;
            try
            {
                rs = float.Parse(str);
            }
            catch (Exception e)
            {
                Debug.LogError("Parse To Float Error: " + e);
            }

            return rs;
        }

        #endregion

        #region BOOL

        public static bool ToBool(this int value)
        {
            return value == 1 ? true : false;
        }

        public static bool ToBool(this string str)
        {
            bool rs = false;
            try
            {
                rs = bool.Parse(str);
            }
            catch (Exception e)
            {
                Debug.LogError("Parse To Bool Error: " + e);
            }

            return rs;
        }

        #endregion
    }
}