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
    public partial class Form1 : Form
    {
        public int selectedProject = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelWork.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelWork.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.projectManager.projects.Length < 7 && textBox2.Text.Length < 10 && textBox2.Text.Length > 2
                && !Program.projectManager.NameExistCheck(Program.projectManager.projects.Length - 1, textBox2.Text))
            {
                Program.projectManager.AddProject(textBox2.Text, textBox1.Text);
                label2.Text = Program.projectManager.projects[Program.projectManager.projects.Length - 1].name;

                Panel ProjectPanel = new Panel();
                ProjectPanel.Name = $"ProjectPanel{Program.projectManager.projects[Program.projectManager.projects.Length - 1].name}";
                ProjectPanel.Dock = DockStyle.Top;
                panel5.Controls.Add(ProjectPanel);

                Button ProjectSelect = new Button();
                ProjectSelect.FlatStyle = FlatStyle.Flat;
                ProjectSelect.ForeColor = Color.White;
                ProjectSelect.Name = $"ProjectSelectButton{Program.projectManager.projects.Length - 1}";
                ProjectSelect.Text = Program.projectManager.projects[Program.projectManager.projects.Length - 1].name;
                ProjectSelect.Font = button1.Font;
                ProjectSelect.Size = button1.Size;
                panel5.Controls.Add(ProjectSelect);
                ProjectSelect.Parent = ProjectPanel;
                ProjectSelect.Click += new EventHandler(SelectProject);
                ProjectSelect.Location = new Point(30, 0);

                Button DeleteProjectButton = new Button();
                DeleteProjectButton.FlatStyle = FlatStyle.Flat;
                DeleteProjectButton.ForeColor = Color.Red;
                DeleteProjectButton.Text = "-";
                DeleteProjectButton.Name = $"DeleteProjectButton{Program.projectManager.projects.Length - 1}";
                DeleteProjectButton.Font = button1.Font;
                DeleteProjectButton.Size = new Size(60,60);
                panel5.Controls.Add(DeleteProjectButton);
                DeleteProjectButton.Parent = ProjectPanel;
                DeleteProjectButton.Location = new Point(270,0);
                DeleteProjectButton.Click += new EventHandler(RemoveProject);

                selectedProject = Program.projectManager.projects.Length - 1;
            }
            else if(Program.projectManager.projects.Length > 6)
            {
                MessageBox.Show("The maximum number of projects has been reached!");
            }
            else if(textBox2.Text.Length > 9)
            {
                MessageBox.Show("The project name mustn't exceed 10 characters!");
            }
            else if(textBox2.Text.Length < 3)
            {
                MessageBox.Show("Project name must contain at least 3 characters!");
            }
            else
            {
                MessageBox.Show("A project with the same name already exists!");
            }

            textBox2.Text = "EnterProjectName";
            textBox1.Text = "EnterProjectDescription";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void SelectProject(object sender, EventArgs e)
        {
            selectedProject = int.Parse(((Button)sender).Name[((Button)sender).Name.Length - 1].ToString());
            label2.Text = Program.projectManager.projects[selectedProject].name.ToString();
        }

        private void RemoveProject(object sender, EventArgs e)
        {
            panel5.Controls.Remove(((Button)sender).Parent);
            int deletedProject = int.Parse(((Button)sender).Name[((Button)sender).Name.Length - 1].ToString());

            if (deletedProject < Program.projectManager.projects.Length - 1)
            {
                Program.projectManager.RemoveProject(deletedProject);
            }
            else
            {
                Array.Resize(ref Program.projectManager.projects, Program.projectManager.projects.Length - 1);
            }

            selectedProject = 0;

            if (Program.projectManager.projects.Length > 1 && deletedProject != Program.projectManager.projects.Length - 1)
            {
                for (int i = deletedProject; i < Program.projectManager.projects.Length; i++)
                {
                    Button but = Controls.Find($"ProjectSelectButton{i + 1}", true).First() as Button;
                    but.Name = $"ProjectSelectButton{i}";
                }
                label2.Text = Program.projectManager.projects[0].name.ToString();
            }
            else
                ClearAll();
        }

        public void ClearAll()
        {
            label2.Text = "ProjectName";
        }

        private void buttonAddAProject_Click(object sender, EventArgs e)
        {
            AddTaskForm taskForm = new AddTaskForm();
            taskForm.Show();
        }
    }
}