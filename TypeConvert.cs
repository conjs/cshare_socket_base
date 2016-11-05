﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TypeConvert
    {

        public TypeConvert()
        {
        }

        public static byte[] getBytes(short s, bool asc)
        {
            byte[] buf = new byte[2];
            if (asc)
            {
                for (int i = buf.Length - 1; i >= 0; i--)
                {
                    buf[i] = (byte)(s & 0x00ff);
                    s >>= 8;
                }
            }
            else
            {
                for (int i = 0; i < buf.Length; i++)
                {

                    buf[i] = (byte)(s & 0x00ff);
                    s >>= 8;
                }
            }
            return buf;
        }
        public static byte[] getBytes(int s, bool asc)
        {
            byte[] buf = new byte[4];
            if (asc)
                for (int i = buf.Length - 1; i >= 0; i--)
                {
                    buf[i] = (byte)(s & 0x000000ff);
                    s >>= 8;
                }
            else
                for (int i = 0; i < buf.Length; i++)
                {
                    buf[i] = (byte)(s & 0x000000ff);
                    s >>= 8;
                }
            return buf;
        }

        public static byte[] getBytes(long s, bool asc)
        {
            byte[] buf = new byte[8];
            if (asc)
                for (int i = buf.Length - 1; i >= 0; i--)
                {
                    buf[i] = (byte)(s & 0x00000000000000ff);
                    s >>= 8;
                }
            else
                for (int i = 0; i < buf.Length; i++)
                {
                    buf[i] = (byte)(s & 0x00000000000000ff);
                    s >>= 8;
                }
            return buf;
        }
        public static short getShort(byte[] buf, bool asc)
        {
            if (buf == null)
            {
                //throw new IllegalArgumentException("byte array is null!");  
            }
            if (buf.Length > 2)
            {
                //throw new IllegalArgumentException("byte array size > 2 !");  
            }
            short r = 0;
            if (asc)
                for (int i = buf.Length - 1; i >= 0; i--)
                {
                    r <<= 8;
                    r |= (short)(buf[i] & 0x00ff);
                }
            else
                for (int i = 0; i < buf.Length; i++)
                {
                    r <<= 8;
                    r |= (short)(buf[i] & 0x00ff);
                }
            return r;
        }
        public static int getInt(byte[] buf, bool asc)
        {
            if (buf == null)
            {
                // throw new IllegalArgumentException("byte array is null!");  
            }
            if (buf.Length > 4)
            {
                //throw new IllegalArgumentException("byte array size > 4 !");  
            }
            int r = 0;
            if (asc)
                for (int i = buf.Length - 1; i >= 0; i--)
                {
                    r <<= 8;
                    r |= (buf[i] & 0x000000ff);
                }
            else
                for (int i = 0; i < buf.Length; i++)
                {
                    r <<= 8;
                    r |= (buf[i] & 0x000000ff);
                }
            return r;
        }
        //public static long getLong(byte[] buf, bool asc)
        //{
        //    if (buf == null)
        //    {
        //        //throw new IllegalArgumentException("byte array is null!");  
        //    }
        //    if (buf.Length > 8)
        //    {
        //        //throw new IllegalArgumentException("byte array size > 8 !");  
        //    }
        //    long r = 0;
        //    if (asc)
        //        for (int i = buf.Length - 1; i >= 0; i--)
        //        {
        //            r <<= 8;
        //            r |= (buf[i] & 0x00000000000000ff);
        //        }
        //    else
        //        for (int i = 0; i < buf.Length; i++)
        //        {
        //            r <<= 8;
        //            r |= (buf[i] & 0x00000000000000ff);
        //        }
        //    return r;
        //}
    }  
}
