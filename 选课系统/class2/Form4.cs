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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//MP10.ssk";
        }

        DataTable xkt;
        DataTable yht;
        private void Form4_Load(object sender, EventArgs e)
        {
            string sqlyh = "select * from 用户信息";
            yht = new Class1().gettable(sqlyh);
            for (int i = 0; i < yht.Rows.Count; i++)
                comboBox1.Items.Add(yht.Rows[i][2].ToString());
            panel1.Visible = false;
            panel1.BackColor = Color.Transparent;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            panel1.Visible = true;
            if (yht != null)
            {
                for (int i = 0; i < yht.Rows.Count; i++)
                    if (comboBox1.Text == yht.Rows[i][2].ToString())
                        save.bh = int.Parse(yht.Rows[i][0].ToString());
            }
            string sqlxk = "select * from 选课情况 where 编号='"+save.bh+"'";//取出某学生的选课情况
            xkt = new Class1().gettable(sqlxk);
            if (xkt == null)
            {
                MessageBox.Show("该生还未选课");
                return;
            }
            int kcNO=0;
            for (int j = 1; j < xkt.Columns.Count; j++)
                if (xkt.Rows[0][j].ToString() == true.ToString())
                {
                    kcNO++;
                    richTextBox1.Text += kcNO + " " + xkt.Columns[j].ColumnName + '\n';
                }
            textBox1.Text = kcNO.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save.x = 1;
            Form7 f7 = new Form7();
            f7.ShowDialog();
            richTextBox1.Clear();
            string sqlxk = "select * from 选课情况 where 编号='" + save.bh + "'";
            xkt = new Class1().gettable(sqlxk);
            if (xkt == null)
            {
                MessageBox.Show("该生还未选课");
                return;
            }
            int kcNO = 0;
            for (int j = 1; j < xkt.Columns.Count; j++)
                if (xkt.Rows[0][j].ToString() == true.ToString())
                {
                    kcNO++;
                    richTextBox1.Text += kcNO + " " + xkt.Columns[j].ColumnName + '\n';
                }
            textBox1.Text = kcNO.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save.x = 2;
            Form7 f7 = new Form7();
            f7.ShowDialog();
            richTextBox1.Clear();
            string sqlxk = "select * from 选课情况 where 编号='" + save.bh + "'";
            xkt = new Class1().gettable(sqlxk);
            if (xkt == null)
            {
                MessageBox.Show("该生还未选课");
                return;
            }
            int kcNO = 0;
            for (int j = 1; j < xkt.Columns.Count; j++)
                if (xkt.Rows[0][j].ToString() == true.ToString())
                {
                    kcNO++;
                    richTextBox1.Text += kcNO + " " + xkt.Columns[j].ColumnName + '\n';
                }
            textBox1.Text = kcNO.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
