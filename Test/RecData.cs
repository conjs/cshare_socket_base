using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1.Test
{
    public class RecData:IData
    {
        public void onData(GMessage msg)
        {
            Console.WriteLine(msg.protocol);
            Console.WriteLine(Encoding.UTF8.GetString(msg.data));
        }
    }
}
