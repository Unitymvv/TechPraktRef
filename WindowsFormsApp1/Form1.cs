using ClassLibrary1;
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
            listBox1.AllowDrop = true;
            listBox1.DragDrop += new DragEventHandler(listBox1_DragDrop);
            listBox1.DragEnter += new DragEventHandler(listBox1_DragEnter);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (!listBox1.Items.Contains(file))
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void Archive_Click(object sender, EventArgs e)
        {
            GzarArchiver.CreateArchive(listBox1);
        }

        private void Unzip_Click(object sender, EventArgs e)
        {
            GzarArchiver.ExtractArchive(listBox1);
        }

        private void ClearFile_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void AddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    if (!listBox1.Items.Contains(file))
                    {
                        listBox1.Items.Add(file);
                    }
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int selectedIndex = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(selectedIndex);
            }
        }

        private void Encode_Click(object sender, EventArgs e)
        {
            XOREncryption.ProcessFiles(listBox1);
        }

        private void Decode_Click(object sender, EventArgs e)
        {
            XOREncryption.DecodeFiles(listBox1);
        }
    }
}
