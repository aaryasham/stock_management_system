using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Stock_management_system_project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //retrive,check
            if (txtUsername.Text !="" && txtPassword.Text !="")
            {
                string passw = "";
                passw = sqlClass.getstringfromquery("select password from Login where username = '" + txtUsername.Text+"'",passw);
                if (passw == txtPassword.Text)
                {
                    GlobalData.uname = txtUsername.Text;
                    MessageBox.Show("Welcome!");
                    Form1 f1 = new Form1();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");

                }
            }
            else
            {
                MessageBox.Show("Please enter username and password.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";

        }
        
        private void button1_click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            changepassword ch = new changepassword();
            //ch.Visible = true;
            ch.Show();
            
        }

        /*private void Changebtn_Click(object sender, EventArgs e)
        {
             if(txtUsername != null)
            {
                using ()
            }
        }*/
    }
}
