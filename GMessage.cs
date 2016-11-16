using System;
using System.Collections.Generic;

using System.Text;


namespace ConsoleApplication1
{
    public class GMessage
    {
        public GMessage() { }
        public GMessage(int protocol,byte[] data) {
            this.protocol = protocol;
            this.data = data;
        }
        public int protocol
        {
            get;
            set;
        }
        public byte[] data
        {
            get;
            set;
        }
        
    }
}
