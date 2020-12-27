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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//DiamondBlue.ssk";
            
        }

        int xf;
        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            save.bh = 0;
            radioButton1.Checked = true;
            panel1.Visible = false;
            xf = 0;
            yht = new Class1().gettable(sqlyh);
            for (int y = 0; y < yht.Rows.Count; y++)
                comboBox1.Items.Add(yht.Rows[y][2].ToString());
        }
        string sqlstr1 = "select 课程名称 from 课程信息 ";
        string sqlstr2 = "select 学分 from 课程信息 ";
        string sqlyh = "select * from 用户信息";
        DataTable yht;
        //开始选课
        private void button1_Click(object sender, EventArgs e)
        {
            
            panel1.Visible = true;
            listBox1.Items.Clear();
            if (radioButton4.Checked == true)
            {
                DataTable t4 = new Class1().gettable(sqlstr1);
                if (t4 != null)
                {
                    for (int i = 0; i < t4.Rows.Count; i++)
                        listBox1.Items.Add(t4.Rows[i][0].ToString());
                }
            }
            else if (radioButton1.Checked == true)
            {
                string zyk = sqlstr1 + "where 课程性质='必修课'";
                DataTable t1 = new Class1().gettable(zyk);
                if (t1 != null)
                {
                    for (int i = 0; i < t1.Rows.Count; i++)
                        listBox1.Items.Add(t1.Rows[i][0].ToString());
                }
            }

            else if (radioButton2.Checked == true)
            {
                string ggk = sqlstr1 + "where 课程性质='公共课'";
                DataTable t2 = new Class1().gettable(ggk);
                if (t2 != null)
                {
                    for (int i = 0; i < t2.Rows.Count; i++)
                        listBox1.Items.Add(t2.Rows[i][0].ToString());
                }
            }

            else if (radioButton3.Checked == true)
            {
                string xxk = sqlstr1 + "where 课程性质='选修课'";
                DataTable t3 = new Class1().gettable(xxk);
                if (t3 != null)
                {
                    for (int i = 0; i < t3.Rows.Count; i++)
                        listBox1.Items.Add(t3.Rows[i][0].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kc = listBox1.Text;
            if (kc == "")
            { MessageBox.Show("请先选中一门课"); return; }

            int i;
            for (i = 0; i < listBox2.Items.Count; i++)
                if (listBox2.Items[i].ToString() == kc) break;
            if (i < listBox2.Items.Count) MessageBox.Show("不能重复选课");
            else
            {
                string kxf = sqlstr2 + "where 课程名称='" + kc + "'";
                DataTable t = new Class1().gettable(kxf);
                int nxf = int.Parse(t.Rows[0][0].ToString());
                xf += nxf;
                listBox2.Items.Add(kc);
            }
            textBox1.Text = xf.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kc = listBox2.Text;
            if (kc.Length == 0) { MessageBox.Show("请先选中所要退的课程"); return; }

            string kxf = sqlstr2 + "where 课程名称='" + kc + "'";
            DataTable dt2 = new Class1().gettable(kxf);
            int nxf = int.Parse(dt2.Rows[0][0].ToString());
            xf -= nxf;
            listBox2.Items.Remove(kc);
            textBox1.Text = xf.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (save.bh==0)
            {
                MessageBox.Show("请先选择学生", "提示");
                //使用lrisSkin4.dll皮肤插件后，第二个参数的长度会出现限制（3）
                return;
            }
            if (xf >= 14)
            {
                textBox1.Text = "";
                new save().getlist(listBox2);
                xf = 0;
            }
            else
            {
                MessageBox.Show("所选学分不能低于14分");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < yht.Rows.Count; i++)
            {
                if (yht.Rows[i][2].ToString() == comboBox1.Text)
                {
                    save.bh = int.Parse(yht.Rows[i][0].ToString());
                    break;
                }
            }
            //MessageBox.Show(save.bh.ToString());
        }
    }
}
