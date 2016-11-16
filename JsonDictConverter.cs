using Newtonsoft.Json;
using System.Collections.Generic;
namespace ConsoleApplication1
{
    public class JsonDictConverter
    {
        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
        }
        /// <summary>
        /// 将Dictionary序列化为json数据
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public string DictionaryToJson(Dictionary<string, object> dic)
        {
            return JsonConvert.SerializeObject(dic);          
        }
    }
}
