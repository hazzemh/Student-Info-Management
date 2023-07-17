using Student_Management.DBServices;
using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management
{
    public partial class StudentsInfo : Form
    {
        DBConnection dbConnection = new DBConnection();
        private List<StudentDTO> students;
        public StudentsInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConnection.openConnection();

            string sql = @"SELECT *
                           FROM Hazz.dbo.Student";

            SqlCommand command = new SqlCommand(sql, dbConnection.getconnection());

            dbConnection.executeQuery(command);

            SqlDataReader reader = command.ExecuteReader();

            students = new List<StudentDTO>();

            while (reader.Read())
            {
                StudentDTO student = new StudentDTO();
                student.Id =(int)reader["Id"];
                student.Name = (string)reader["Name"];
                student.Phone = (string)reader["Phone"];
                student.Address = (string)reader["Address"];
                student.Age = (int)reader["Age"];
                student.Gender = (string)reader["Gender"];
                student.BirthDate = (DateTime)reader["BirthDate"];

                students.Add(student);
            }

            listBox1.Items.Clear();
            foreach(StudentDTO student in students)
            {
                listBox1.Items.Add(student.Id + " - " + student.Name);
            }

            dbConnection.closeConnection();
        }
    }
}
