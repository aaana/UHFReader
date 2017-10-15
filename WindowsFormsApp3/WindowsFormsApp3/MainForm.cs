using System;
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
    public partial class MainForm : Form
    {
        Dictionary<string, List<int>> bindingDictionary = new Dictionary<string, List<int>>();

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            bindListView.FullRowSelect = true;
        }

        private void startDressLineBtn_Click(object sender, EventArgs e)
        {
            //打开服装线上的三个读写器，并启动三个线程进行监控
        }

        private void stopDressLineBtn_Click(object sender, EventArgs e)
        {
            //关闭读写器和线程
        }

        //绑定epc和分拣口
        private void bindBtn_Click(object sender, EventArgs e)
        {
            string epc = tagTextBox.Text;
            if (epc == "")
            {
                Console.WriteLine("未检测到服装");
                MessageBox.Show("未检测到服装", "Warning");
                return;
            }
            if (bindingDictionary.ContainsKey(epc))
            {
                Console.WriteLine("该服装已绑定");
                MessageBox.Show("该服装已绑定", "Warning");
                return;
            }
            //
            List<int> entries = new List<int>();
            string sortingEntries = "";
            for (int i = 0; i < bindCheckedListBox.Items.Count; i++)
            {
                if (bindCheckedListBox.GetItemChecked(i))
                {
                    entries.Add(i + 1);
                    sortingEntries = sortingEntries + (i + 1) + ",";
                }

            }
            if (sortingEntries.Length > 0)
            {
                sortingEntries = sortingEntries.Substring(0, sortingEntries.Length - 1);
            }
            else
            {
                Console.WriteLine("请选择分拣口");
                MessageBox.Show("请选择分拣口", "Warning");
                return;
            }
            if (MessageBox.Show("确认绑定#" + epc + "\n到" + sortingEntries + "分拣口吗？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindingDictionary.Add(epc, entries);
                ListViewItem item = new ListViewItem(epc);
                item.SubItems.Add(sortingEntries);
                bindListView.Items.Add(item);
            }
        }

        //全选
        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked)
            {
                for (int j = 0; j < bindCheckedListBox.Items.Count; j++)
                    bindCheckedListBox.SetItemChecked(j, true);
            }
            else
            {
                for (int j = 0; j < bindCheckedListBox.Items.Count; j++)
                    bindCheckedListBox.SetItemChecked(j, false);
            }
        }

        //清除绑定
        private void clearBindBtn_Click(object sender, EventArgs e)
        {
            if (bindListView.SelectedItems.Count > 0)
            {
                Console.WriteLine(bindListView.SelectedItems[0].SubItems[0].Text);

                bindingDictionary.Remove(bindListView.SelectedItems[0].SubItems[0].Text);
                bindListView.SelectedItems[0].Remove();
                //bindListView.Items.Remove(bindListView.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("请选中一件服装");
            }
        }

        private void bindListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //

    }
}
