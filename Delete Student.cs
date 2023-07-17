using Student_Management.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management.DBServices
{
    public partial class Delete_Student : Form
    {
        StudentManager studentManager = new StudentManager();
        public Delete_Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = -1;
            try{ 
                id = int.Parse(textBox6.Text); 
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error");
            }
            studentManager.delete(id);

        }
    }
}
