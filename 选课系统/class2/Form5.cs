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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//Vista2_color3.ssk";
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            string sqlkc = "select * from 课程信息";
            string sqlxm = "select * from 用户信息";
            DataTable dt1 = new Class1().gettable(sqlkc);
            for (int i = 0; i < dt1.Rows.Count; i++)
                comboBox1.Items.Add(dt1.Rows[i][1].ToString());
            DataTable dt2 = new Class1().gettable(sqlxm);
            for (int j = 0; j < dt2.Rows.Count; j++)
                comboBox2.Items.Add(dt2.Rows[j][2].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlstr1;
            string sqlstr2 = "select * from 选课情况";
            DataTable t=new Class1().gettable(sqlstr2);
            if (t == null)
                textBox2.Text = "0";
            else
                textBox2.Text = t.Rows.Count.ToString();

            if (comboBox1.Text == "C++面向对象程序设计")
                sqlstr1 = "select * from 选课情况 where [" + comboBox1.Text + "]='true'";
            else
                sqlstr1 = "select * from 选课情况 where " + comboBox1.Text + "='true'";
            DataTable t2=new Class1().gettable(sqlstr1);
            if (t2 == null)
            {
                textBox1.Text = "0";
                MessageBox.Show("该门课还未有人选","提示信息");
                listBox1.Items.Clear();
                return;
            }
            else
                textBox1.Text = t2.Rows.Count.ToString();
            listBox1.Items.Clear();
            for (int i = 0; i < t2.Rows.Count; i++)
            {
                DataTable nt = new Class1().gettable("select * from 用户信息 where 编号='" + t2.Rows[i][0].ToString() + "'");
                listBox1.Items.Add(nt.Rows[0][2].ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cm2=comboBox2.Text;
            string sqlstr1 = "select * from 用户信息 where 姓名='" + cm2 + "'";
            DataTable t1 = new Class1().gettable(sqlstr1);
            int sqlbh = int.Parse(t1.Rows[0][0].ToString());
            string sqlstr2 = "select * from 选课情况 where 编号='" + sqlbh + "'";
            DataTable t2 = new Class1().gettable(sqlstr2);
            int xf=0;
            int chooseNO=0;
            if (t2 == null)
            {
                MessageBox.Show("该生还未选课");
                return;
            }
            listBox2.Items.Clear();
            
            for (int m = 1; m < t2.Columns.Count; m++)
            {
                string sqlxf = "select * from 课程信息 where 课程名称='" + t2.Columns[m].ColumnName + "'";
                if (t2.Rows[0][m].ToString() == true.ToString())
                {
                    chooseNO++;
                    DataTable xft = new Class1().gettable(sqlxf);
                    xf += int.Parse(xft.Rows[0][2].ToString());
                    listBox2.Items.Add(t2.Columns[m].ColumnName);
                }
            }
            textBox3.Text = chooseNO.ToString();
            textBox4.Text = xf.ToString();
            //MessageBox.Show(sqlstr2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
