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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xh = textBox1.Text.Trim();
            if (xh == "")
            {
                MessageBox.Show("学号不能为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            string passwd = textBox2.Text.Trim();
            if (passwd.Length < 5)
            {
                MessageBox.Show("密码不能小于5位!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            string name = textBox3.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("姓名不能为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            string grade = textBox4.Text.Trim();
            string sex="";
            if (radioButton2.Checked == true)
                sex = "男";
            else if (radioButton3.Checked == true)
                sex = "女";
            string academy = textBox5.Text.Trim();
            string major = textBox6.Text.Trim();
            string sqlstr="insert into Graduates values('"+xh+"','"+passwd+"',0,'"+name+"'";//必填项
            sqlstr += ",'" + sex + "','" + grade + "','" + academy + "','" + major + "')";//选填项
            new db_query().noquery(sqlstr);
            MessageBox.Show("保存成功", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

    }
}
