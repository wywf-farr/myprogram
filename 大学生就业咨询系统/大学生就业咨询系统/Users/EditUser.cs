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
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
        }
        string id = new Login().loginname;
        private void button1_Click(object sender, EventArgs e)
        {
            string passwd = textBox2.Text.Trim();
            if (passwd.Length < 5)
            {
                MessageBox.Show("密码不能小于5位!");
                textBox2.Focus();
                return;
            }
            string name = textBox3.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("姓名不能为空!");
                textBox3.Focus();
                return;
            }
            string grade = textBox4.Text.Trim();
            string sex = "";
            if (radioButton2.Checked == true)
                sex = "男";
            else if (radioButton3.Checked == true)
                sex = "女";
            string academy = textBox5.Text.Trim();
            string major = textBox6.Text.Trim();
            string sqlstr = "update Graduates set 密码='" + passwd + "',姓名='" + name + "'";//必填项
            sqlstr += ",性别='" + sex + "',年级='" + grade + "',院校='" + academy + "',专业='" + major + "' where 学号='" + id + "'";//选填项
            new db_query().noquery(sqlstr);
            //MessageBox.Show(sqlstr);
            MessageBox.Show("修改成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            DataTable t;
            string sqlview = "select * from Graduates where 学号='" + id + "'";
            t = new db_query().gettable(sqlview);
            textBox1.Text = t.Rows[0][1].ToString();
            textBox1.ReadOnly = true;
            textBox2.Text = t.Rows[0][2].ToString();
            textBox3.Text = t.Rows[0][4].ToString();
            textBox4.Text = t.Rows[0][6].ToString();
            if (t.Rows[0][5].ToString() == "男")
                radioButton2.Checked = true;
            else if (t.Rows[0][5].ToString() == "女")
                radioButton3.Checked = true;
            else radioButton1.Checked = true;
            textBox5.Text = t.Rows[0][7].ToString();
            textBox6.Text = t.Rows[0][8].ToString();
        }
    }
}
