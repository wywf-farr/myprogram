using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大学生就业咨询系统.Users
{
    public partial class UserView : Form
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            string id = new Login().loginname;
            DataTable t;
            string sqlview = "select * from Graduates where 学号='" + id + "'";
            t = new db_query().gettable(sqlview);
            textBox1.Text = t.Rows[0][1].ToString();
            textBox1.ReadOnly = true;
            textBox2.Text = t.Rows[0][2].ToString();
            textBox2.ReadOnly = true;
            textBox3.Text = t.Rows[0][4].ToString();
            textBox3.ReadOnly = true;
            textBox4.Text = t.Rows[0][6].ToString();
            textBox4.ReadOnly = true;
            if (t.Rows[0][5].ToString() == "男")
                radioButton2.Checked = true;
            else if (t.Rows[0][5].ToString() == "女")
                radioButton3.Checked = true;
            else radioButton1.Checked = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            textBox5.Text = t.Rows[0][7].ToString();
            textBox5.ReadOnly = true;
            textBox6.Text = t.Rows[0][8].ToString();
            textBox6.ReadOnly = true;
        }
    }
}
