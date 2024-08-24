using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userid=txtUserId.Text;
            string pass = txtPassword.Text;

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=SchoolMgt;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblLogin where   userid = @userid and password = @pass";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                MessageBox.Show("Welcome..");
                NumberOperation obj = new NumberOperation();
                obj.MdiParent = this.MdiParent;
                obj.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid user id or password!!!");
            }

            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentReg srobj = new StudentReg();
            srobj.MdiParent = this.MdiParent;
            srobj.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button5.Enabled = true;
        }
    }
}
