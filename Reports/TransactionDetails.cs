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
    public partial class TransactionDetails : Form
    {
        public TransactionDetails()
        {
            InitializeComponent();
        }

        private void TransactionDetails_Load(object sender, EventArgs e)
        {
            loadAllData();
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

        private void cmbProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbProName.Text != "")
            {
                loadGridData("select p.proname,s.quantity,s.txndate from Stock s LEFT JOIN Products p on s.proid = p.proId where proname = '" + cmbProName.Text + "' group by p.proname,s.quantity,s.txndate");

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            loadAllData();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }
    }
}