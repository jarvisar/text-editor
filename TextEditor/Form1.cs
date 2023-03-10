using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;

        private Stack<string> undoStack = new Stack<string>();
        private Stack<string> redoStack = new Stack<string>();

        private TextBox textBox;

        public Form1()
        {
            InitializeComponent();
            CreateMenuStrip();
        }

        private void CreateMenuStrip()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();

            fileToolStripMenuItem.Text = "File";
            openToolStripMenuItem.Text = "Open";
            saveToolStripMenuItem.Text = "Save";
            fontToolStripMenuItem.Text = "Font";
            undoToolStripMenuItem.Text = "Undo";
            redoToolStripMenuItem.Text = "Redo";

            openToolStripMenuItem.Click += new EventHandler(openToolStripMenuItem_Click);
            saveToolStripMenuItem.Click += new EventHandler(saveToolStripMenuItem_Click);
            fontToolStripMenuItem.Click += new EventHandler(fontToolStripMenuItem_Click);
            undoToolStripMenuItem.Click += new EventHandler(undoToolStripMenuItem_Click);
            redoToolStripMenuItem.Click += new EventHandler(redoToolStripMenuItem_Click);

            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;

            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, undoToolStripMenuItem, redoToolStripMenuItem });

            menuStrip.Items.Add(fontToolStripMenuItem);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richrichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
