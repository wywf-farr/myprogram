using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//DiamondGreen.ssk";
        }

        string sqlstr1;
        string sqlstr2;
        string sqlstr3;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入课程代码", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入课程名称", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("请输入课程学分", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            else
            {
                sqlstr1 = "select * from 课程信息 where 课程代码='" + textBox1.Text.Trim() + "'";
                sqlstr2 = "select * from 课程信息 where 课程名称='" + textBox2.Text.Trim() + "'";
                string xz;
                if (radioButton1.Checked == true)
                    xz = "必修课";
                else if (radioButton2.Checked == true)
                    xz = "公共课";
                else xz = "选修课";
                sqlstr3 = "insert into 课程信息(课程代码,课程名称,学分,课程性质) values('";
                sqlstr3 += textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + xz + "')";
                DataTable t1 = new Class1().gettable(sqlstr1);
                DataTable t2 = new Class1().gettable(sqlstr2);
                if (t1 != null)
                {
                    MessageBox.Show("此课程代码已被使用，请换一个", "提示信息");
                    textBox1.Focus();
                }
                else if (t2 != null)
                {
                    MessageBox.Show("此课程名称已被使用，请换一个", "提示信息");
                    textBox2.Focus();
                }
                else
                {
                    string sqlxk = "alter table 选课情况 add " + textBox2.Text.Trim() + " bit";
                    new Class1().noquery(sqlstr3);
                    new Class1().noquery(sqlxk);
                    MessageBox.Show("添加成功");
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
