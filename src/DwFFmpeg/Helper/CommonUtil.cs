using System;
using System.Text.Json;

namespace DwFFmpeg
{
    public static class CommonUtil
    {
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object obj)
        {
            T value = default;
            try { value = (T)Convert.ChangeType(obj, typeof(T)); }
            catch { }
            return value;
        }

        /// <summary>
        /// json转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string json, string path = null, JsonSerializerOptions options = null)
        {
            var root = JsonDocument.Parse(json).RootElement;
            if (!string.IsNullOrEmpty(path)) root = root.GetProperty(path);
            var r = root.GetRawText();
            return JsonSerializer.Deserialize<T>(root.GetRawText(), options); ;
        }
    }
}
