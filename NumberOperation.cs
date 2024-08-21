using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class NumberOperation : Form
    {
        public NumberOperation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //read no from textbox1

                string v = textBox1.Text;
                //int no = Convert.ToInt32(v);
                int no = int.Parse(v);

                // check that no is prime or not
                //and display messagein label2
                bool flag = true;
                for (int i = 2; i < no; i++)
                {
                    if (no % i == 0)
                    {
                        // label2.Text = $"{no} is not prime";
                        textBox2.Text = $"{no} is not prime";
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    // label2.Text = $"{no} is prime";
                    textBox2.Text = $"{no} is prime";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid number entered...");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int no = int.Parse(textBox1.Text);
                if (no % 2 == 0)
                {
                    textBox2.Text = $"{no} is Even number";
                }
                else
                {
                    textBox2.Text = $"{no} is odd number";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid number entered...");
            }
            
        }
    }
}
