using ReaderB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHFReader
{
    public class CUHFReader
    {

        private static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        //
        //port,COM口号
        //如果串口打开失败，返回-1
        //如果串口打开成功，或者已经打开，返回串口号
        public static int open_port(int port)
        {
            byte fBaud;//波特率
            int openresult = 0x30;//COM打开返回值
            int fOpenComIndex = 0;//与读写器连接的串口句柄
            byte fComAdr = 0xff;

            int i;
            try
            {
                for (i = 6; i >= 0; i--)
                {
                    fBaud = Convert.ToByte(i);//把每种级别的波特率都遍历一遍
                    if (fBaud == 3)
                        continue;
                    openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref fOpenComIndex);

                    if (openresult == 0x35)//串口已经打开，返回串口号
                    {
                        return port;
                    }
                }
            }
            finally
            {
            }
            if ((fOpenComIndex == -1) && (openresult == 0x30))
            {
                return -1;
            }
            return fOpenComIndex;
        }


        public static int close_port(int comportindex)
        {
            return StaticClassReaderB.CloseSpecComPort(comportindex);
        }

        //
        //返回第一个标签，如果没读到的话返回空
        //
        public static String read_com(object openComIndex)
        {
            int fOpenComIndex = (int)openComIndex;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string sEPC;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            int fCmdRet;
            byte fComAdr = 0xff;
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, fOpenComIndex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                m = 0;
                if (CardNum == 0)
                {
                    return null;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)//返回第一个标签
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return null;
                    return sEPC;
                }
            }
            return null;
        }


        //
        //输出
        //
        public static void read_com1(object openComIndex)
        {
            int fOpenComIndex = (int)openComIndex;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string sEPC;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            int fCmdRet;
            byte fComAdr = 0xff;
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, fOpenComIndex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                m = 0;
                if (CardNum == 0)
                {
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)//返回第一个标签
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return;
                    Console.WriteLine(sEPC);
                }
            }
        }
    }
}
