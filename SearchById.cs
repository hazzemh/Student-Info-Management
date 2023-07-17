using Student_Management.Controllers;
using Student_Management.DBServices;
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
    public partial class SearchById : Form
    {
        StudentManager studentManager = new StudentManager();
        public SearchById()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox6.Text);
                string name =studentManager.search(id);
                textBox1.Text = name;

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void SearchById_Load(object sender, EventArgs e)
        {

        }
    }
}
