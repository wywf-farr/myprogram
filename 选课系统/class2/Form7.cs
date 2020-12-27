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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//MidsummerColor2.ssk";
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string sqlxk = "select * from 选课情况 where 编号='" + save.bh + "'";
            DataTable t = new Class1().gettable(sqlxk);
            if(t==null)
            {
                MessageBox.Show("该生还未选课");
                button1.Visible = true;
                button2.Visible = false;
                DataTable kct = new Class1().gettable("select name from syscolumns where id=OBJECT_ID('选课情况')") ;
                if (kct != null)
                {
                    for (int i = 1; i < kct.Rows.Count; i++)
                        listBox1.Items.Add(kct.Rows[i][0].ToString());
                }
                return;
            }
            if (save.x == 1)
            {
                for (int i = 1; i < t.Columns.Count; i++)
                    if (t.Rows[0][i].ToString() != true.ToString())
                        listBox1.Items.Add(t.Columns[i].ColumnName);
                button1.Visible = true;
                button2.Visible = false;

            }
            else
            {
                for (int i = 1; i < t.Columns.Count; i++)
                    if (t.Rows[0][i].ToString() == true.ToString())
                        listBox1.Items.Add(t.Columns[i].ColumnName);
                button1.Visible = false;
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kc = listBox1.Text;
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("课程已选完");
                return;
            }
            if (kc == "")
            {
                MessageBox.Show("请先选中一门课");
                return;
            }
            listBox1.Items.Remove(kc);
            string sqlstr = "update 选课情况 set " + kc + "='true' where 编号='" + save.bh + "'";
            if (kc == "C++面向对象程序设计")
            {
                sqlstr = "update 选课情况 set [" + kc + "]='true' where 编号='" + save.bh + "'";
            }
            new Class1().noquery(sqlstr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kc = listBox1.Text;
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("课程已退完");
                return;
            }
            if (kc == "")
            {
                MessageBox.Show("请先选中一门课");
                return;
            }
            listBox1.Items.Remove(kc);
            string sqlstr = "update 选课情况 set " + kc + "='false' where 编号='" + save.bh + "'";
            if (kc == "C++面向对象程序设计")
            {
                sqlstr = "update 选课情况 set [" + kc + "]='false' where 编号='" + save.bh + "'";
            }
            new Class1().noquery(sqlstr);
        }
    }
}
