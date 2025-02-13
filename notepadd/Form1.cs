using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepadd
{
    public partial class Form1 : Form

    {
        private PrintDocument printDocument1 = new PrintDocument();
        private bool isDarkMode = false;

        public Form1()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
          richTextBox1.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SaveFileDialog sachin = new SaveFileDialog();
            sachin.Title = "Save File";
            sachin.Filter = "Text Files | *.txt | all files | *.";
            if (sachin.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sachin.FileName, RichTextBoxStreamType.PlainText);
                this.Text = sachin.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sachin = new OpenFileDialog();
            sachin.Title = "Open File";
            sachin.Filter = "Text Files | *.txt | all files | *.";
            if (sachin.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(sachin.FileName, RichTextBoxStreamType.PlainText);
                this.Text = sachin.FileName;    
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new PointF(0, 0));
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            /*if (richTextBox1.SelectedText != "")
             {
                 Clipboard.SetText(richTextBox1.SelectedText);
                 richTextBox1.SelectedText = "";
             }*/
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                FontDialog fontDialog1 = new FontDialog();
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
        }

        private void backcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                isDarkMode = false;
            }
            else
            {
                richTextBox1.BackColor = Color.Black;
                richTextBox1.ForeColor = Color.White;
                isDarkMode = true;
            }
        }
    }
}
