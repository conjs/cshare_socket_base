using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

/*
 //DataContractJsonSerializer serializer = new DataContractJsonSerializer(jsonObject.GetType());
               //using (MemoryStream m = new MemoryStream())
               //{
               //    serializer.WriteObject(m, jsonObject);
               //    StringBuilder sb = new StringBuilder();
               //    sb.Append(Encoding.UTF8.GetString(m.ToArray()));
               //    Console.WriteLine(sb.ToString());
               //}
 * 
 [DataContract] class
 [DataMember] field
 
 private Person getPerson(string str)
        {
           DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
           using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
           {
               Person jsonObject = (Person)ser.ReadObject(ms);
               return jsonObject;
           }
        }
 */
namespace ConsoleApplication1
{
    
    /**
     * 
     */
    public class SocketHelper
    {
        private Socket socket;
        private IConnect connect;
        private IDisconnect disconnect;
        private IData idata;

        private SocketHelper(IConnect connect,IDisconnect disconnect,IData data,SocketParam param)
        {
            this.connect = connect;
            this.disconnect = disconnect;
            this.idata = data;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(param.ip), param.port);            
            IAsyncResult result = socket.BeginConnect(endpoint, new AsyncCallback(ConnectCallback), socket);
            
            bool success = result.AsyncWaitHandle.WaitOne(param.timeout, true);
            if (!success)
            {
                //超时  
                Closed(disconnect);
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(ReceiveSorket));
                thread.IsBackground = true;
                thread.Start();
            }
        }


        public bool send(byte[] content,int protocol)
        {
            if (socket == null && socket.Connected)
                return false;
            ByteBuffer buffer = ByteBuffer.Allocate(content.Length + 8);
            buffer.WriteInt(content.Length + 4);
            buffer.WriteInt(protocol);
            buffer.WriteBytes(content);
            socket.Send(buffer.ToArray());
            return true;
        }

        private void ConnectCallback(IAsyncResult asyncConnect)
        {
            this.connect.connectSuccess();
        }

        private void ReceiveSorket()
        {
            //在这个线程中接受服务器返回的数据  
            byte[] recData = new byte[1024*16];
            while (true)
            {
                if (!socket.Connected)
                {
                    //与服务器断开连接跳出循环  
                    socket.Close();
                    break;
                }
                try
                {
                    byte[] lengthBytes = Receive(socket, 4);
                    int head = TypeConvert.getInt(lengthBytes, false);  // 先收内容长度
                    byte[] strBytes = Receive(socket, head);

                    int proto = TypeConvert.getInt(SubByte(strBytes, 0, 4),false);

                    byte[] subData = new byte[strBytes.Length-4];// strBytes.Skip(4).ToArray(); C#3.0不支持此写法
                    Buffer.BlockCopy(strBytes, 4, subData, 0, subData.Length);

                    idata.onData(new GMessage(proto, subData));
                }
                catch (Exception e)
                {
                    socket.Close();
                    break;
                }
            }
        }

        private byte[] Receive(Socket socket, int length)
        {
            byte[] bytes = new byte[length];
            socket.Receive(bytes);
            return bytes;
        }

        /// <summary>  
        /// 截取字节数组  
        /// </summary>  
        /// <param name="srcBytes">要截取的字节数组</param>  
        /// <param name="startIndex">开始截取位置的索引</param>  
        /// <param name="length">要截取的字节长度</param>  
        /// <returns>截取后的字节数组</returns>  
        private byte[] SubByte(byte[] srcBytes, int startIndex, int length)
        {
            System.IO.MemoryStream bufferStream = new System.IO.MemoryStream();
            byte[] returnByte = new byte[] { };
            if (srcBytes == null) { return returnByte; }
            if (startIndex < 0) { startIndex = 0; }
            if (startIndex < srcBytes.Length)
            {
                if (length < 1 || length > srcBytes.Length - startIndex) { length = srcBytes.Length - startIndex; }
                bufferStream.Write(srcBytes, startIndex, length);
                returnByte = bufferStream.ToArray();
                bufferStream.SetLength(0);
                bufferStream.Position = 0;
            }
            bufferStream.Close();
            bufferStream.Dispose();
            return returnByte;
        }  


        //关闭Socket  
        public void Closed(IDisconnect disconnect)
        {
            if (socket != null && socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            disconnect.disconnect();
            socket = null;
        }
    }
}
