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
    public partial class changepassword : Form
    {
        public changepassword()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //retrive,check
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                string query = "update Login set password = '" + txtPassword.Text + "' where username = '" + txtUsername.Text+"'";
                sqlClass.ExecutrSQLQuery(query);
                MessageBox.Show("Passwprd Updated successfully");
            }
            else
            {
                MessageBox.Show("Please enter username and password.");
            }
        }
    }
}
