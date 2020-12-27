using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace class2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//OneBlue.ssk";
            groupBox1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }


        string sqlstr1;
        string sqlstr2 = "select name from syscolumns where id=OBJECT_ID('课程信息')";
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable t1=new Class1().gettable(sqlstr2);
            for (int i = 0; i < t1.Rows.Count; i++)
                comboBox1.Items.Add(t1.Rows[i][0].ToString());
            groupBox1.Visible = false;
            dataGridView1.Visible = false;
            groupBox1.BackColor = Color.Transparent;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (textBox1.Text != "")
                sqlstr1 =  "select * from 课程信息 where " + comboBox1.Text + " like '%'+'" + textBox1.Text + "'+'%'";
            else sqlstr1 = "select * from 课程信息";
            //MessageBox.Show(str1);
            dataGridView1.DataSource = new Class1().gettable(sqlstr1);
        }

        int index = 0;
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)//鼠标右键
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;//选定一行
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];//每次只选定一行
                contextMenuStrip1.Show(dataGridView1, e.Location);//右键列表显示在datagridview控件上
                contextMenuStrip1.Show(Cursor.Position);//右键快捷列表显示在鼠标停留位置
                index = e.RowIndex;

            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strrow = dataGridView1.CurrentCell.Value.ToString();
            string destr1 = "delete 课程信息 where 课程代码='" + strrow + "'";
            string strcolumn = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string destr2 = "alter table 选课情况 drop column " + strcolumn;
            dataGridView1.Rows.RemoveAt(index);
            new Class1().noquery(destr1);
            new Class1().noquery(destr2);
            MessageBox.Show("已删除");
        }

        int dc = 0;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dc++;
            if (dc == 1)
            {
                if (e.ColumnIndex == 0)
                {
                    MessageBox.Show("课程代码不能修改");
                    dataGridView1.CurrentCell.Value = strval;
                    return;
                }
                string strcolumn1 = dataGridView1.Columns[e.ColumnIndex].HeaderText;//得到列标题
                string strvalue1 = dataGridView1.CurrentCell.Value.ToString();//得到数据
                string strid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//得到所选行第一列的数据
                if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strinsert = "update 课程信息 set " + strcolumn1 + "='" + strvalue1 + "' where 课程代码='" + strid + "'";
                    string strinsert2 = "exec sp_rename '[选课情况].[" + strval + "]','" + strvalue1 + "'";
                    new Class1().noquery(strinsert);
                    new Class1().noquery(strinsert2);
                }
                else
                    dataGridView1.CurrentCell.Value = strval;
            }
            dc = 0;
        }

        string strval;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            strval = dataGridView1.CurrentCell.Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
