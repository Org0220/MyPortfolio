using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class AdminForm : Form
    {
        private Admin admin;
        private Menu menu;
        public AdminForm(Admin admin, Menu menu)
        {
            this.menu = menu;
            this.admin = admin;
            InitializeComponent();
            welcomeL.Text = "Welcome back, " + admin.name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void elementsL_Click(object sender, EventArgs e)
        {

        }

        private void Course_CheckedChanged(object sender, EventArgs e)
        {
            displayL.Text = "";
            teacherTB.Text = "";
            nameTB.Text = "";
            if (Course.Checked == true)
            {
                teacherL.Visible = true;
                teacherTB.Visible = true;

            }
            else
            {
                teacherL.Visible = false;
                teacherTB.Visible = false;
            }
        }

        private void studentRB_CheckedChanged(object sender, EventArgs e)
        {
            displayL.Text = "";
            teacherTB.Text = "";
            nameTB.Text = "";
        }

        private void teacherRB_CheckedChanged(object sender, EventArgs e)
        {
            displayL.Text = "";
            teacherTB.Text = "";
            nameTB.Text = "";
        }
        private void PasswordRB_CheckedChanged(object sender, EventArgs e)
        {
            displayL.Text = "";
            if (PasswordRB.Checked == true)
            {
                addB.Text = "Change";
                nameL.Text = "ID:";
                teacherL.Text = "New Password:";
                teacherL.Visible = true;
                teacherTB.Visible = true;

            } else
            {
                addB.Text = "Add";
                nameL.Text = "Name:";
                teacherL.Text = "Teacher:";
                teacherL.Visible = false;
                teacherTB.Visible = false;
            }
            teacherTB.Text = "";
            nameTB.Text = "";
        }
        private void addB_Click(object sender, EventArgs e)
        {
            
            if (teacherTB.Text.Contains(" "))
            {
                errorL.Text = "password can't contain spaces";
                return;
            }
            errorL.Text = "";
            if (nameTB.Text != "")
            {
                errorL.Text = "";
                if (studentRB.Checked == true)
                {
                    Student student = new Student(nameTB.Text);
                    FinalProject.Menu.students.Add(student);
                    FinalProject.Menu.SerializeAll();
                }
                else if (teacherRB.Checked == true)
                {
                    Teacher teacher = new Teacher(nameTB.Text);
                    FinalProject.Menu.teachers.Add(teacher);
                    FinalProject.Menu.SerializeAll();
                } else if(PasswordRB.Checked == true)
                {
                    foreach (Teacher teacher in FinalProject.Menu.teachers)
                    {
                        if (teacher.Id == nameTB.Text)
                        {
                            
                            teacher.Password = teacherTB.Text;
                            return;
                        }
                    }
                    foreach (Student student in FinalProject.Menu.students) { 
                        if (student.Id == nameTB.Text)
                        {
                            student.Password = teacherTB.Text;
                        }
                    }
                }
                else
                {

                    Boolean teacherFound = false;
                    int teacherIndex = 0;
                    if (teacherTB.Text == "")
                        errorL.Text = "Please input a teacher ID!";
                    else
                    {
                        foreach (Teacher teacher in FinalProject.Menu.teachers)
                        {
                            if (teacher.Id == teacherTB.Text)
                            {
                                teacherFound = true;
                            }
                            else if (!teacherFound)
                            {
                                teacherIndex++;
                            }
                        }
                        if (teacherFound)
                        {
                            Teacher teacher = (Teacher)FinalProject.Menu.teachers[teacherIndex];
                            Course course = new Course(nameTB.Text, new ArrayList(), teacher, 5);
                            
                            FinalProject.Menu.courses.Add(course);
                            teacher.TeachingCourses.Add(course);
                        }
                        else
                            errorL.Text = "Teacher not found!";
                    }
                }
            }
            FinalProject.Menu.SerializeAll();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void displayB_Click(object sender, EventArgs e)
        {
            displayL.Text = "";
            if (studentRB.Checked == true)
            {
                ArrayList students = (FinalProject.Menu.students);
                foreach (Student student in students)
                {
                    displayL.Text += "Student: " + student.Id + "\n     Name: " + student.name + "\n";
                }
            }
            else if (teacherRB.Checked == true)
            {
                ArrayList teachers = (FinalProject.Menu.teachers);
                foreach (Teacher teacher in teachers)
                {
                    displayL.Text += "Teacher: " + teacher.Id + "\n     Name: " + teacher.name + "\n";
                    
                }
            }
            else if(PasswordRB.Checked == true)
            {
                ArrayList teachers = (FinalProject.Menu.teachers);
                ArrayList students = (FinalProject.Menu.students);
                foreach(Teacher teacher in teachers)
                {
                    displayL.Text += teacher.Id + ": " + teacher.Password + "\n";
                }
                foreach (Student student in students)
                {
                    displayL.Text += student.Id + ": " + student.Password + "\n";
                }
            }
            else
            {
                ArrayList courses = (FinalProject.Menu.courses);
                foreach (Course course in courses)
                {
                    displayL.Text += "Course: " + course.Id + "\n     Name: " + course.Name + "\n     Teacher: "
                        + course.Teacher.name + "\n";
                    foreach (Student student in course.Studnets)
                        displayL.Text += "     " + student.Id + ": " + student.name + "\n";
                    
                }
            }
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menu.Visible = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            menu.Close();
            this.Close();
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
