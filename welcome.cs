using Student_Management.DBServices;
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
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            createWindow cw = new createWindow();
            cw.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateWindow uw = new UpdateWindow();
            uw.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Student dw = new Delete_Student();
            dw.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentsInfo sw = new StudentsInfo();
            sw.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchById sw = new SearchById();
            sw.Show();
        }
    }
}
