using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1.Test
{
    class Connector : IConnect
    {
        public void connectSuccess()
        {
            Console.WriteLine("connect success");
        }
    }
}
