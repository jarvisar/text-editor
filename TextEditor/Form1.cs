using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private TextBox textBox;

        public Form1()
        {
            InitializeComponent();
            CreateMenuStrip();
            CreateTextBox();
        }

        private void CreateTextBox()
        {
            textBox = new TextBox();
            textBox.Dock = DockStyle.Fill;
            this.Controls.Add(textBox);
        }

        private void CreateMenuStrip()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();

            fileToolStripMenuItem.Text = "File";
            openToolStripMenuItem.Text = "Open";
            saveToolStripMenuItem.Text = "Save";

            openToolStripMenuItem.Click += new EventHandler(openToolStripMenuItem_Click);
            saveToolStripMenuItem.Click += new EventHandler(saveToolStripMenuItem_Click);

            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string fileText = File.ReadAllText(fileName);
                textBox1.Text = fileText;
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
