using Student_Management.Controllers;
using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management
{
    public partial class createWindow : Form
    {
        StudentManager studentManager = new StudentManager();
        public createWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentDTO student = new StudentDTO();
            try
            {
                student.Id = int.Parse(textBox6.Text);
                student.Name = textBox7.Text;
                student.Phone = textBox8.Text;
                student.Address = textBox9.Text;
                student.Age = int.Parse(textBox10.Text);
                if (radioButton1.Checked)
                {
                    student.Gender = "male";
                }
                else
                {
                    student.Gender = "female";
                }
                student.BirthDate = dateTimePicker1.Value;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message, "Error");
            }

            bool success = studentManager.validate(student);

            if(success)
            studentManager.create(student);

        }
    }
}
