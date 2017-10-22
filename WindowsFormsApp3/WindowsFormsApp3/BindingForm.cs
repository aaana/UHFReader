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
    public partial class BindingForm : Form 
    {
        public BindingForm()
        {
            InitializeComponent();
        }

        private MainForm _mainForm;
        private string _epc;

        public BindingForm(MainForm mainform, string epc):this()
        {
            _mainForm = mainform;
            _epc = epc;
        }

        private List<int> selectedSortEntries = new List<int>();

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex >= 0)
            {                
                string selectedStr = leftListBox.Text;
                rightListBox.Items.Add(selectedStr);
                leftListBox.Items.RemoveAt(leftListBox.SelectedIndex);
                selectedSortEntries.Add( Convert.ToInt32(selectedStr.Substring(selectedStr.Length-1,1)));
                Console.WriteLine(Utils.listToString(selectedSortEntries));
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (rightListBox.SelectedIndex >= 0)
            {
                string selectedStr = rightListBox.Text;
                leftListBox.Items.Add(selectedStr);
                rightListBox.Items.RemoveAt(rightListBox.SelectedIndex);
                selectedSortEntries.Remove(Convert.ToInt32(selectedStr.Substring(selectedStr.Length - 1, 1)));
                Console.WriteLine(Utils.listToString(selectedSortEntries));
                
            }
        }

        private void BindingForm_Load(object sender, EventArgs e)
        {
            leftListBox.Sorted = true;
            epcLabel.Text = _epc;
        }

        private void conformBtn_Click(object sender, EventArgs e)
        {
            if(selectedSortEntries.Count == 0)
            {
                MessageBox.Show("请选择分拣口","Warning");
                return;
            }
            _mainForm.addBinding(_epc, selectedSortEntries);
            Dispose();
           
        }

    }
}
