using Newtonsoft.Json;
using System;
using System.IO;

namespace Kit.Utils
{
    public class Json
    {
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
            catch
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
            catch
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
            catch
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
            catch
            {
                result = -1;
            }
            return result;
        }
    }
}
