using ReaderB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private byte fComAdr = 0xff; //当前操作的ComAdr
        private byte fComAdr3 = 0xff; //当前操作的ComAdr
        private byte fBaud;
        private byte fBaud3;
        private int fCmdRet = 30; //所有执行指令的返回值
        private int fCmdRet3 = 30; //所有执行指令的返回值
        private int fOpenComIndex; //打开的串口索引号
        private int fOpenComIndex3; //打开的串口索引号
        private bool fIsInventoryScan;
        private bool fIsInventoryScan3;
        private int frmcomportindex;
        private int frmcomportindex3;

        public Form1()
        {
            InitializeComponent();
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private void InitComList()//设置参数类型，以供选择
        {
            int i = 0;
            ComboBox_COM.Items.Clear();
            ComboBox_COM.Items.Add(" AUTO");
            for (i = 1; i < 13; i++)
                ComboBox_COM.Items.Add(" COM" + Convert.ToString(i));
            ComboBox_COM.SelectedIndex = 0;

            ComboBox_baud2.Items.Clear();
            ComboBox_baud2.Items.Add("9600bps");
            ComboBox_baud2.Items.Add("19200bps");
            ComboBox_baud2.Items.Add("38400bps");
            ComboBox_baud2.Items.Add("57600bps");
            ComboBox_baud2.Items.Add("115200bps");
            ComboBox_baud2.SelectedIndex = 0;

            i = 0;
            ComboBox3_COM.Items.Clear();
            ComboBox3_COM.Items.Add(" AUTO");
            for (i = 1; i < 13; i++)
                ComboBox3_COM.Items.Add(" COM" + Convert.ToString(i));
            ComboBox3_COM.SelectedIndex = 0;

            ComboBox_baud3.Items.Clear();
            ComboBox_baud3.Items.Add("9600bps");
            ComboBox_baud3.Items.Add("19200bps");
            ComboBox_baud3.Items.Add("38400bps");
            ComboBox_baud3.Items.Add("57600bps");
            ComboBox_baud3.Items.Add("115200bps");
            ComboBox_baud3.SelectedIndex = 0;
        }

        public void ChangeSubItem(ListViewItem ListItem, int subItemIndex, string ItemText)//对读到的标签进行处理相应
        {
            if (subItemIndex == 1)
            {
                if (ItemText == "")
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    if (ListItem.SubItems[subItemIndex + 2].Text == "")
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                    }
                    else
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    }
                }
                else
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 2].Text = "1";
                }
                else
                {
                    ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                }
            }
            if (subItemIndex == 2)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                }
            }

        }

        private void Inventory()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan = true;
            ListViewItem aListItem = new ListViewItem();
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                m = 0;
                if (CardNum == 0)
                {
                    fIsInventoryScan = false;
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return;
                    isonlistview = false;
                    for (i = 0; i < ListView1_EPC.Items.Count; i++)     //判断是否在Listview列表内
                    {
                        if (sEPC == ListView1_EPC.Items[i].SubItems[1].Text)
                        {
                            aListItem = ListView1_EPC.Items[i];
                            ChangeSubItem(aListItem, 1, sEPC);
                            isonlistview = true;
                        }
                    }
                    if (!isonlistview)
                    {
                        aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add(frmcomportindex.ToString());
                        s = sEPC;
                        ChangeSubItem(aListItem, 1, s);
                        s = (sEPC.Length / 2).ToString().PadLeft(2, '0');
                        ChangeSubItem(aListItem, 2, s);
                    }
                }
            }

            fIsInventoryScan = false;

        }

        private void Inventory3()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan3 = true;
            ListViewItem aListItem = new ListViewItem();
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            fCmdRet3 = StaticClassReaderB.Inventory_G2(ref fComAdr3, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex3);
            if ((fCmdRet3 == 1) | (fCmdRet3 == 2) | (fCmdRet3 == 3) | (fCmdRet3 == 4) | (fCmdRet3 == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                m = 0;
                if (CardNum == 0)
                {
                    fIsInventoryScan3 = false;
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return;
                    isonlistview = false;
                    for (i = 0; i < ListView3_EPC.Items.Count; i++)     //判断是否在Listview列表内
                    {
                        if (sEPC == ListView3_EPC.Items[i].SubItems[1].Text)
                        {
                            aListItem = ListView3_EPC.Items[i];
                            ChangeSubItem(aListItem, 1, sEPC);
                            isonlistview = true;
                        }
                    }
                    if (!isonlistview)
                    {
                        aListItem = ListView3_EPC.Items.Add((ListView3_EPC.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add(frmcomportindex3.ToString());
                        s = sEPC;
                        ChangeSubItem(aListItem, 1, s);
                        s = (sEPC.Length / 2).ToString().PadLeft(2, '0');
                        ChangeSubItem(aListItem, 2, s);
                    }
                }
            }

            fIsInventoryScan3 = false;
            fIsInventoryScan = false;

        }

        private void Timer_Test__Tick_1(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            Inventory();
        }
        private void Timer_Test_3_Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan3)
                return;
            Inventory3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Timer_Test_.Enabled = !Timer_Test_.Enabled;
            if (!Timer_Test_.Enabled)
            {
                button2.Text = "查询标签";
            }
            else
            {
                button2.Text = "停止";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Timer_Test_3.Enabled = !Timer_Test_3.Enabled;
            if (!Timer_Test_3.Enabled)
            {
                button3.Text = "查询标签";
            }
            else
            {
                button3.Text = "停止";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fOpenComIndex = -1;
            fOpenComIndex3 = -1;
            fComAdr = 0;
            fComAdr3 = 0;
            fBaud = 5;
            fBaud3 = 5;
            InitComList();
            fIsInventoryScan = false;
            fIsInventoryScan3 = false;
            button2.Enabled = false;//没有连接串口不给予读取
            button3.Enabled = false;//没有连接串口不给予读取
            ComboBox_baud2.SelectedIndex = 3;
            ComboBox_baud3.SelectedIndex = 3;
        }

        private void OpenPort_Click(object sender, EventArgs e)
        {
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            if (Edit_CmdComAddr.Text == "")
                Edit_CmdComAddr.Text = "FF";
            fComAdr = Convert.ToByte(Edit_CmdComAddr.Text, 16); // $FF;
            try
            {
                if (ComboBox_COM.SelectedIndex == 0)//Auto
                {
                    fBaud = Convert.ToByte(ComboBox_baud2.SelectedIndex);
                    if (fBaud > 2)
                        fBaud = Convert.ToByte(fBaud + 2);
                    openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref fComAdr, fBaud, ref frmcomportindex);
                    fOpenComIndex = frmcomportindex;
                    if (openresult == 0)
                    {
                        button2.Enabled = true;
                        if ((fCmdRet == 0x35) | (fCmdRet == 0x30))
                        {
                            button2.Enabled = false;
                            MessageBox.Show("串口通讯错误", "信息提示");
                            StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                        }
                    }
                }
                else
                {
                    temp = ComboBox_COM.SelectedItem.ToString();
                    temp = temp.Trim();
                    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                    for (i = 6; i >= 0; i--)
                    {
                        fBaud = Convert.ToByte(i);
                        if (fBaud == 3)
                            continue;
                        openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                        fOpenComIndex = frmcomportindex;
                        if (openresult == 0x35)
                        {
                            MessageBox.Show("串口已打开", "信息提示");
                            return;
                        }
                        if (openresult == 0)
                        {
                            button2.Enabled = true;
                            if ((fCmdRet == 0x35) || (fCmdRet == 0x30))
                            {
                                button2.Enabled = false;
                                MessageBox.Show("串口通讯错误", "信息提示");
                                StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                                return;
                            }
                            break;
                        }

                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if ((fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30))
            {
                ComboBox_AlreadyOpenCOM.Items.Add("COM" + Convert.ToString(fOpenComIndex));
                ComboBox_AlreadyOpenCOM.SelectedIndex = ComboBox_AlreadyOpenCOM.SelectedIndex + 1;
                button2.Enabled = true;
            }
            if ((fOpenComIndex == -1) && (openresult == 0x30))
                MessageBox.Show("串口通讯错误", "信息提示");

            if ((ComboBox_AlreadyOpenCOM.Items.Count != 0) & (fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30) & (fCmdRet == 0))
            {
                temp = ComboBox_AlreadyOpenCOM.SelectedItem.ToString();
                frmcomportindex = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
            }
        }

        private void OpenPort3_Click(object sender, EventArgs e)
        {
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            if (Edit3_CmdComAddr.Text == "")
                Edit3_CmdComAddr.Text = "FF";
            fComAdr3 = Convert.ToByte(Edit3_CmdComAddr.Text, 16); // $FF;
            try
            {
                if (ComboBox3_COM.SelectedIndex == 0)//Auto
                {
                    fBaud3 = Convert.ToByte(ComboBox_baud3.SelectedIndex);
                    if (fBaud3 > 2)
                        fBaud3 = Convert.ToByte(fBaud3 + 2);
                    openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref fComAdr3, fBaud3, ref frmcomportindex3);
                    fOpenComIndex3 = frmcomportindex3;
                    if (openresult == 0)
                    {
                        button3.Enabled = true;
                        if ((fCmdRet3 == 0x35) | (fCmdRet3 == 0x30))
                        {
                            button3.Enabled = false;
                            MessageBox.Show("串口通讯错误", "信息提示");
                            StaticClassReaderB.CloseSpecComPort(frmcomportindex3);
                        }
                    }
                }
                else
                {
                    temp = ComboBox3_COM.SelectedItem.ToString();
                    temp = temp.Trim();
                    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                    for (i = 6; i >= 0; i--)
                    {
                        fBaud = Convert.ToByte(i);
                        if (fBaud == 3)
                            continue;
                        openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr3, fBaud3, ref frmcomportindex3);
                        fOpenComIndex3 = frmcomportindex3;
                        if (openresult == 0x35)
                        {
                            MessageBox.Show("串口已打开", "信息提示");
                            return;
                        }
                        if (openresult == 0)
                        {
                            button3.Enabled = true;
                            if ((fCmdRet3 == 0x35) || (fCmdRet3 == 0x30))
                            {
                                button3.Enabled = false;
                                MessageBox.Show("串口通讯错误", "信息提示");
                                StaticClassReaderB.CloseSpecComPort(frmcomportindex3);
                                return;
                            }
                            break;
                        }

                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if ((fOpenComIndex3 != -1) & (openresult != 0X35) & (openresult != 0X30))
            {
                ComboBox3_AlreadyOpenCOM.Items.Add("COM" + Convert.ToString(fOpenComIndex3));
                ComboBox3_AlreadyOpenCOM.SelectedIndex = ComboBox3_AlreadyOpenCOM.SelectedIndex + 1;
                button3.Enabled = true;
            }
            if ((fOpenComIndex3 == -1) && (openresult == 0x30))
                MessageBox.Show("串口通讯错误", "信息提示");

            if ((ComboBox3_AlreadyOpenCOM.Items.Count != 0) & (fOpenComIndex3 != -1) & (openresult != 0X35) & (openresult != 0X30) & (fCmdRet == 0))
            {
                temp = ComboBox3_AlreadyOpenCOM.SelectedItem.ToString();
                frmcomportindex = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
            }
        }
    }
}
