using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        string filename=string.Empty,prevfilecontent=string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savedata();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "open --notepad";
            od.Filter = "TextFiles|*.txt";
            od.DefaultExt = "txt";
            od.InitialDirectory = "C:\\drashti\\notepad";
            od.ShowDialog();    
            if(od.FileName!="")
            {
                richTextBox1.LoadFile(od.FileName);
                filename = od.FileName;
                prevfilecontent=richTextBox1.Text;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != string.Empty)
            {
                string currentfilecontent = richTextBox1.Text;
                if (prevfilecontent != currentfilecontent)
                {
                    richTextBox1.SaveFile(filename);
                    cleardata();
                    currentfilecontent = string.Empty;
                }
                else
                {
                    cleardata();
                    currentfilecontent = string.Empty;
                }
            }
            else if (richTextBox1.Text.Length > 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to save?", "Notepad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    savedata();
                    cleardata();
                }
                else
                {
                    cleardata();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filename = string.Empty;
            savedata();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd=new ColorDialog();
            cd.ShowDialog();
            richTextBox1.ForeColor = cd.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd=new FontDialog();
            fd.ShowDialog();
            richTextBox1.Font = fd.Font;
        }
        private void cleardata()
        {
            richTextBox1.Text= string.Empty;
            filename = string.Empty;
            prevfilecontent = string.Empty;
        }

        private void savedata()
        {
            if(filename==string.Empty)
            {
                SaveFileDialog sd=new SaveFileDialog();
                sd.Title = "save --notepad";
                sd.Filter = "TextFiles|*.txt";
                sd.DefaultExt = "txt";
                sd.InitialDirectory = "C:\\drashti\\notepad";
                sd.ShowDialog();
                if(sd.FileName!="")
                {
                    richTextBox1.SaveFile(sd.FileName);
                    filename = sd.FileName;
                    prevfilecontent = richTextBox1.Text;
                }
            }
            else
            {
                richTextBox1.SaveFile(filename);
            }
        }
    }
}
