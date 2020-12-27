using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大学生就业咨询系统.Panel
{
    public partial class AddJob : Form
    {
        public AddJob()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qy = textBox1.Text.Trim();
            if (qy == "")
            {
                MessageBox.Show("发布企业不能为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            string name = textBox2.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("岗位名称不能为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            string type = textBox3.Text.Trim();
            if (type == "")
            {
                MessageBox.Show("岗位分类不能为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            string salary = textBox4.Text.Trim();
            string phone = textBox5.Text.Trim();
            string remark = richTextBox1.Text.Trim();
            string sqladd = "insert into Job values('" + qy + "','" + name + "','" + type + "','" + salary + "','" + phone + "','" + remark + "')";
            //MessageBox.Show(sqladd);
            new db_query().noquery(sqladd);
            MessageBox.Show("发布成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
