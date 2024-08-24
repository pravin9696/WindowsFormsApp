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

namespace WindowsFormsApp
{
    public partial class StudentReg : Form
    {
        public StudentReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void StudentReg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int roll=int.Parse(txtRoll.Text);
            string name=txtName.Text;
            string gender;
            string langs="";
            DateTime dob=dtpDOB.Value;

            if (rdbMale.Checked)
            {
                gender = "Male";
            }
            else if(rdbFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                gender = "TransGender";
            }

            
            if (chkEnglish.Checked)
            {
                langs +=","+ chkEnglish.Text;
            }
            if (chkHindi.Checked)
            {
                langs += "," + chkHindi.Text;
            }
            if (chkMarathi.Checked)
            {
                langs += "," + chkMarathi.Text;
            }

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=SchoolMgt;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblStudReg values(@roll,@name,@gender,@lang,@dob,@lgid)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roll", roll);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@lang", langs);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@lgid", 3);
            int n=cmd.ExecuteNonQuery();
            if (n>0)
            {
                MessageBox.Show("Registration done....");
            }
            else
            {
                MessageBox.Show("not registered!!!!");
            }
            con.Close();















            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clear all record from all controlls
            txtRoll.Clear();
            txtName.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            rdbTrans.Checked = false;

            chkEnglish.Checked= false;
            chkHindi.Checked = false;
            chkMarathi.Checked = false;

            dtpDOB.Value = DateTime.Now;

            button1.Enabled = true;
        }
    }
}
