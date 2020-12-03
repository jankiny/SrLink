using System;
using System.Configuration;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SRLink.Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// 获取AppSettings值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>AppSettings中的value值</returns>
        public static string GetAppString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 生成n位的随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns>随机字符串</returns>
        public static string GenerateRandomString(int length)
        {
            char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string checkCode = string.Empty;
            try
            {
                Random rd = new Random();
                for (int i = 0; i < length; i++)
                {
                    checkCode += constant[rd.Next(36)].ToString().ToUpper();
                }
            }
            catch (Exception)
            {
            }
            return checkCode;
        }
        #region 编码
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            try
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception)
            {
                // ignored
                return string.Empty;
            }
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Decode(string plainText)
        {
            try
            {
                plainText = plainText.Trim()
                    .Replace(Environment.NewLine, "")
                    .Replace("\n", "")
                    .Replace("\r", "")
                    .Replace(" ", "");

                if (plainText.Length % 4 > 0)
                {
                    plainText = plainText.PadRight(plainText.Length + 4 - plainText.Length % 4, '=');
                }

                byte[] data = Convert.FromBase64String(plainText);
                return Encoding.UTF8.GetString(data);
            }
            catch (Exception)
            {
                // ignored
                return string.Empty;
            }
        }

        #endregion

        #region StringHelper

        /// <summary>
        /// 取得存储资源
        /// </summary>
        /// <returns></returns>
        public static string LoadResource(string res)
        {
            string result = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(res))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T FromJson<T>(string strJson)
        {
            try
            {
                T obj = JsonConvert.DeserializeObject<T>(strJson);
                return obj;
            }
            catch (Exception)
            {
                return JsonConvert.DeserializeObject<T>("");
            }
        }

        /// <summary>
        /// 序列化成Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(Object obj)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(obj,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// 保存成json文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int ToJsonFile(Object obj, string filePath)
        {
            int result;
            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    //JsonSerializer serializer = new JsonSerializer();
                    JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
                    //JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };

                    serializer.Serialize(file, obj);
                }
                result = 0;
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }

        #endregion

    }
}
