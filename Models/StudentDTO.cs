using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.Models
{
    class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public StudentDTO()
        {

        }
        public StudentDTO(int id , string name , string phone , string address , int age , string gender , DateTime date)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Age = age;
            this.Gender = gender;
            this.BirthDate = date;
        }
    }
}
