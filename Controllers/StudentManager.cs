using Student_Management.DBServices;
using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Student_Management.Controllers
{

    class StudentManager : IStudentManager
    {
        DBConnection dbConnection = new DBConnection();
        public void create(StudentDTO s)
        {
            dbConnection.openConnection();

            string sql = @"INSERT INTO Hazz.dbo.Student (Id , Name , Phone , Address , Age , Gender ,
                           BirthDate) 
                           VALUES (@id , @name , @phone , @address, @age , @gender, @birthdate)";

            SqlCommand command = new SqlCommand(sql, dbConnection.getconnection());

            command.Parameters.AddWithValue("@id", s.Id);
            command.Parameters.AddWithValue("@name", s.Name);
            command.Parameters.AddWithValue("@phone", s.Phone);
            command.Parameters.AddWithValue("@address", s.Address);
            command.Parameters.AddWithValue("@age", s.Age);
            command.Parameters.AddWithValue("@gender", s.Gender);
            command.Parameters.AddWithValue("@birthdate", s.BirthDate);


            int rowsAffected =dbConnection.executeQuery(command);

            if (rowsAffected > 0)
            {
                MessageBox.Show("The Student Created Successfully!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error is happened", "ALERT");
            }

            dbConnection.closeConnection();
        }

        public void delete(int id)
        {
            dbConnection.openConnection();

            string sql = @"DELETE FROM Hazz.dbo.Student
                           WHERE Id = @id ";

            SqlCommand command = new SqlCommand(sql, dbConnection.getconnection());

            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = dbConnection.executeQuery(command);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Student information updated successfully!");
            }
            else
            {
                MessageBox.Show("Error updating student information!");
            }
            dbConnection.closeConnection();
        }

        public string search(int id)
        {
            dbConnection.openConnection();
            string sql = @"EXEC get_student_by_Id @id";
            SqlCommand sqlCommand = new SqlCommand(sql, dbConnection.getconnection());
            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                string name = reader["Name"].ToString();
                string gender = reader["Gender"].ToString();
                dbConnection.closeConnection();
                return name;
            }
            else
            {
                MessageBox.Show("No student found with ID " + id);
            }
            dbConnection.closeConnection();
            return "";
        }

        public void update(StudentDTO s)
        {
            dbConnection.openConnection();

            string sql = @"UPDATE Hazz.dbo.Student
                           SET Name = @name, Phone = @phone, Address = @address, Age = @age, Gender = @gender, BirthDate = @birthdate
                           WHERE ID = @id";

            SqlCommand command = new SqlCommand(sql, dbConnection.getconnection());
            command.Parameters.AddWithValue("@id", s.Id);
            command.Parameters.AddWithValue("@name", s.Name);
            command.Parameters.AddWithValue("@phone", s.Phone);
            command.Parameters.AddWithValue("@address", s.Address);
            command.Parameters.AddWithValue("@age", s.Age);
            command.Parameters.AddWithValue("@gender", s.Gender);
            command.Parameters.AddWithValue("@birthdate", s.BirthDate);

            int rowsAffected = dbConnection.executeQuery(command);

            if (rowsAffected > 0)
            {
                MessageBox.Show("The Student Created Successfully!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error is happened", "ALERT");
            }

            dbConnection.closeConnection();
        }

        public bool validate(StudentDTO s)
        {
            if(s.Id == null || s.Name == null || s.Phone == null || s.Address == null
                || s.Age == null || s.Gender == null || s.BirthDate == null)
            {
                MessageBox.Show("Required Fields are missing!");
                return false;
            }
            else
            {
                if (s.Id < 0)
                {
                    MessageBox.Show("Id must be positive!");
                    return false; 
                }

                foreach (char character in s.Name)
                {
                    if (!Char.IsLetter(character) && !Char.IsWhiteSpace(character))
                    {
                        MessageBox.Show("Name must be in English Letters!");
                        return false;
                    }
                }

                if (s.Phone.Length > 11)
                {
                    MessageBox.Show("Enter a valid number, max. 11 !");
                    return false;
                }

                if (s.Age < 10 || s.Age > 60)
                {
                    MessageBox.Show("Age must be between 10 and 60");
                    return false;
                }
            }

            return true;
        }
    }
}
