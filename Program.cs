using System;
using System.Text;

using System.IO;
using System.Collections.Generic;
using ConsoleApplication1.Test;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //Console.WriteLine("abc");
            //Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("name", "abcb");
            //dict.Add("age", 20);
            //string json = new JsonDictConverter().DictionaryToJson(dict);
            //Console.WriteLine(json);

            //dict = new JsonDictConverter().JsonToDictionary(json);
            //Console.WriteLine(dict);
            
            SocketParam param = new SocketParam();
            param.ip = "10.100.70.17";
            param.port = 20000;
            param.timeout = 10000;
            SocketHelper helper = new SocketHelper(new Connector(),new Disconnector(),new RecData(),param);
            byte[] data = Encoding.UTF8.GetBytes("{\"openid\":\"czw12\"}");
            
            helper.send(data, 2);

            data = Encoding.UTF8.GetBytes("{\"openid\":\"czw12\",\"name\":\"张小五\",\"general\":1,\"army\":1}");
            helper.send(data, 1);


         
            Console.ReadKey();
            /*
            Console.WriteLine(BitConverter.IsLittleEndian);
            var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            

           string str = "";
           StreamReader sr = new StreamReader("d:\\json.txt", Encoding.Default);
           String line;
           while ((line = sr.ReadLine()) != null)
           {
               str = line;
           }
            string target = "{\"state\":1,\"data\":{\"name\":\"崔中伟\",\"age\":30}}";
            Console.WriteLine(string.Equals(str, target));

           DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
           using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
           {
               Person jsonObject = (Person)ser.ReadObject(Class1.csms);
               Console.WriteLine(jsonObject);


               DataContractJsonSerializer serializer = new DataContractJsonSerializer(jsonObject.GetType());
               using (MemoryStream m = new MemoryStream())
               {
                   serializer.WriteObject(m, jsonObject);
                   StringBuilder sb = new StringBuilder();
                   sb.Append(Encoding.UTF8.GetString(m.ToArray()));
                   Console.WriteLine(sb.ToString());
               }
               Console.ReadKey();
           }  */
        }


    }
}
