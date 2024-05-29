using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_management_system_project.Reports
{
    public partial class AllProDetails : Form
    {
        public AllProDetails()
        {
            InitializeComponent();
        }

        private void AllProDetails_Load(object sender, EventArgs e)
        {
            loadAllData();
            loadGridData("select p.proId,p.proname,p.category,p.unit,p.salespricee,p.purchaseprice,sum(s.quantity) as Quantity from Products p LEFT JOIN Stock s ON p.proId = s.proid group by p.proId,p.proname,p.category,p.unit,p.salespricee,p.purchaseprice");

        }
        public void loadAllData()
        {
            cmbProName.Items.Clear();
            cmbProName.Text = "";
            
             sqlClass.localDataCB("select proname from Products", cmbProName);
        }
        public void loadGridData(string str)
        {
            sqlClass.loadDataGrid(str, dataGridView1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            loadAllData();
            loadGridData("select p.proId,p.proname,p.category,p.unit,p.salespricee,p.purchaseprice,sum(s.quantity) as Quantity from Products p LEFT JOIN Stock s ON p.proId = s.proid group by p.proId,p.proname,p.category,p.unit,p.salespricee,p.purchaseprice");

        }

        private void cmbProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProName.Text != "")
            {
                loadGridData("select p.proId,p.proname,p.category,p.unit,p.salespricee,p.purchaseprice,sum(s.quantity) as Quantity from Products p LEFT JOIN Stock s ON p.proId = s.proid where p.proname='"+ cmbProName.Text +"' group by p.proId,p.proname,p.category,p.unit,p.salespricee,p.purchaseprice");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
