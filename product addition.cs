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
    public partial class product_addition : Form
    {
        public product_addition()
        {
            InitializeComponent();
            txtSPrice.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
            txtPPrice.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtProName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProcategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProName.Text != "" && txtProcategory.Text != "" && txtUnit.Text != "" && txtSPrice.Text != "")
            {
                sqlClass.ExecutrSQLQuery("insert into Products(proname,category,unit,salespricee,purchaseprice) values('" + txtProName.Text + "','" + txtProcategory.Text + "','" + txtUnit.Text + "','" + txtSPrice.Text + "','" + txtPPrice.Text + "')");
                MessageBox.Show("Record inserted Successfully.");
               
            }
            else
            {
                MessageBox.Show("Please Fill All the Values.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProName.Text = "";
            txtProcategory.Text = "";
            txtUnit.Text = "";
            txtSPrice.Text = "";
            txtPPrice.Text = "";
        }

        private void product_addition_Load(object sender, EventArgs e)
        {

        }
    }
}
