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
    public partial class ProductUpdateDelete : Form
    {
        
        public ProductUpdateDelete()
        {
            InitializeComponent();
            txtSPrice.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
            txtPPrice.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ProductUpdateDelete_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void cmbProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProName.Text != "")
            {
                string str = "select proid,proname,category,unit,salespricee,purchaseprice from Products where proname ='" + cmbProName.Text + "'";

                sqlClass.retriveData(str, txtProid, 0);
                sqlClass.retriveData(str, txtProName, 1);
                sqlClass.retriveData(str, txtProcategory, 2);
                sqlClass.retriveData(str, txtUnit, 3);
                sqlClass.retriveData(str, txtSPrice, 4);
                sqlClass.retriveData(str, txtPPrice, 5);
            }
            else
            {
                MessageBox.Show("please select Product.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProid.Text != "" && txtProName.Text != "" && txtProcategory.Text != "" && txtUnit.Text != "" && txtSPrice.Text != "" && txtPPrice.Text != "")
            {
                sqlClass.ExecutrSQLQuery("update Products set proname ='" + txtProName.Text + "',category ='" + txtProcategory.Text + "',unit='" + txtUnit.Text + "',salespricee ='" + txtSPrice.Text + "',purchaseprice='" + txtPPrice.Text + "' where proid ='" + txtProid.Text + "'");
                MessageBox.Show("Record Updated Successfully");
                clear();
            }
            else
            {
                MessageBox.Show("please fill all records");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtProid.Text != "")
            {
                sqlClass.ExecutrSQLQuery("delete from Products where proid ='"+ txtProid.Text +"'");
                MessageBox.Show("Record deleted successfully");
                clear();
            }
            else
            {
                MessageBox.Show("please select a product to delete");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           clear();

        }
        public void clear()
        {
            txtProid.Text = "";
            txtProName.Text = "";
            txtProcategory.Text = "";
            txtUnit.Text = "";
            txtSPrice.Text = "";
            txtPPrice.Text = "";
            cmbProName.Text = "";
            cmbProName.Items.Clear();
            sqlClass.localDataCB("select proname from Products", cmbProName);
        }
    }
}
