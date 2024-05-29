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
    public partial class StockUpdate : Form
    {
        public StockUpdate()
        {
            InitializeComponent();
            txtSPrice.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
            txtPPrice.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
            txtUpdateQty.KeyPress += new KeyPressEventHandler(sqlClass.numericOnly);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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

                string curqty = "";
                curqty = sqlClass.getstringfromquery("select sum(quantity) from Stock where proid='" + txtProid.Text + "'", curqty);
                if (curqty != "")
                    txtPresentQty.Text = curqty;
                else
                    txtPresentQty.Text = "0";

            }
            else
            {
                MessageBox.Show("please select Product.");
            }
        }
        public void clear()
        {
            txtProid.Text = "";
            txtProName.Text = "";
            txtProcategory.Text = "";
            txtUnit.Text = "";
            txtSPrice.Text = "";
            txtPPrice.Text = "";
            txtPresentQty.Text = "";
            txtUpdateQty.Text = "";
            txtNewQty.Text = "";
            cmbProName.Text = "";
            cmbProName.Items.Clear();
            sqlClass.localDataCB("select proname from Products", cmbProName);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void StockUpdate_Load(object sender, EventArgs e)
        {
            clear();
        }

        int upqty = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtPresentQty.Text !="" && txtUpdateQty.Text !="")
            {
                txtNewQty.Text = (int.Parse(txtPresentQty.Text) + int.Parse(txtUpdateQty.Text)).ToString();
                upqty =  int.Parse(txtUpdateQty.Text);
            }
            else
            {
                MessageBox.Show("Present and Update quantity can not be Empty.");
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (txtPresentQty.Text != "" && txtUpdateQty.Text != "")
            {
                txtNewQty.Text = (int.Parse(txtPresentQty.Text) - int.Parse(txtUpdateQty.Text)).ToString();
                upqty = 0 - int.Parse(txtUpdateQty.Text);
            }
            else
            {
                MessageBox.Show("Present and Update quantity can not be Empty.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtProid.Text!="" && txtUpdateQty.Text != "")
            {
                sqlClass.ExecutrSQLQuery("insert into Stock(proid,quantity,txndate,username) values('" + txtProid.Text + "'," + upqty + ",'" + DateTime.Today.ToString() + "','" + GlobalData.uname + "')");
                MessageBox.Show("Stock Updated Successfully.");
            }
            else
            {
                MessageBox.Show("Please Select Proper pproduct and/or please Enter quantity.");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
