using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();

            vScrollBar1.Value = panel1.VerticalScroll.Value;
            vScrollBar1.Minimum = panel1.VerticalScroll.Minimum;
            vScrollBar1.Maximum = panel1.VerticalScroll.Maximum;
        }

        private void buttonAddBProject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void AddTaskForm_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
                textBox1.Text = "EnterTaskName";
            if (textBox2.Text.Length == 0)
                textBox2.Text = "EnterTaskDescription";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel attachedFilePanel = new Panel();
            attachedFilePanel.Dock = DockStyle.Top;
            attachedFilePanel.Size = new Size(100, 40);
            panel1.Controls.Add(attachedFilePanel);

            Label attachedFileLabel = new Label();
            attachedFileLabel.Text = "none";
            attachedFileLabel.ForeColor = Color.White;
            attachedFileLabel.Font = new Font(Font, FontStyle.Bold);
            attachedFilePanel.Controls.Add(attachedFileLabel);
            attachedFileLabel.Parent = attachedFilePanel;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.VerticalScroll.Value = vScrollBar1.Value;
        }
    }
}
