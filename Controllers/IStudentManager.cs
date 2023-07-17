using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.Controllers
{
    interface IStudentManager
    {
        void create(StudentDTO s);
        void update(StudentDTO s);
        void delete(int id );
        bool validate(StudentDTO s);
        string search(int id);
    }
}
