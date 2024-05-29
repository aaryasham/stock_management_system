using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Stock_management_system_project
{
     static class CommonMethods
    {
        public static SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stockmanagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public static void ExecutrSQLQuery(string str)
        {
            try
            {
                if (sc.State == ConnectionState.Open)
                    sc.Close();
                sc.Open();
                SqlCommand cmd = new SqlCommand(str, sc);
                cmd.ExecuteNonQuery();
                sc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string getstringfromquery(string str)
        {
            string ret = null;
            try
            {

                if (sc.State == ConnectionState.Open)
                    sc.Close();
                sc.Open();
                SqlCommand cmd = new SqlCommand(str, sc);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    ret = dr[0].ToString();
                dr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }
    }
}
