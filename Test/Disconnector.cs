using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1.Test
{
    class Disconnector:IDisconnect
    {
        public void disconnect()
        {
            Console.WriteLine("disconnect ");
        }
    }
}
