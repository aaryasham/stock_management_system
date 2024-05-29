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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            product_addition pa = new product_addition();
            pa.ShowDialog();
        }

        private void updateOrDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductUpdateDelete pd = new ProductUpdateDelete();
            pd.ShowDialog();
        }

        private void stockUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockUpdate su = new StockUpdate();
            su.Show();

        }

        private void allProductsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.AllProDetails ap = new Reports.AllProDetails();
            ap.ShowDialog();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.TransactionDetails td = new Reports.TransactionDetails();   
            td.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
