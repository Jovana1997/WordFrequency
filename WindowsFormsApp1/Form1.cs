using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            Dictionary<string, int> words = new Dictionary<string, int>();
            Counter.WordFrequencyCounter(tbFileName.Text, words);

            Dictionary<string, int> sorted = new Dictionary<string, int>();
            
            if(cbAsending.Checked)
                sorted = words.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            else
                sorted = words.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            dgv.Columns.Add("Key", "Words");
            dgv.Columns.Add("Value", "Frequency");

            foreach(KeyValuePair<string, int> item in sorted)
            {
                dgv.Rows.Add(item.Key, item.Value);
            }
        }
    }
}
