using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace class2
{
    class Class1
    {
        string cnstr = "server=(local);database=选课数据库;uid=aa;pwd=abc123;";
        public void noquery(string str1)
        {
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(str1, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable gettable(string str2)
        {
            SqlConnection cn = new SqlConnection(cnstr);
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                SqlDataAdapter myda = new SqlDataAdapter(str2, cn);
                myda.Fill(ds);
                DataTable t = ds.Tables[0];
                if (t.Rows.Count != 0)
                    return t;
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
