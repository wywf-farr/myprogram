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
    public partial class MainForm : Form
    {
        public string titlename = "大学生就业咨询";
        Login login = new Login();
        private int index = 0;
        public MainForm(Login fm1)
        {
            InitializeComponent();
            this.login = fm1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (new Login().UserSt == "True")
                this.Text = titlename + "（管理员）";
            else
            {
                this.Text = titlename + "（普通用户）";
                企业信息管理ToolStripMenuItem.Enabled = false;
                毕业生信息管理ToolStripMenuItem.Enabled = false;
            }
            //点击岗位检索前先隐藏
            dataGridView1.Visible=false;
            groupBox1.Visible = false;
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出", "验证消息", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Show();
        }

        private void 基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fview = Application.OpenForms["UserView"];
            if (fview == null || fview.IsDisposed)
            {
                Users.UserView uview = new Users.UserView();
                uview.Show();
            }
            else
            {
                fview.Activate();
                fview.WindowState = FormWindowState.Normal;
            }
        }

        private void 信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fedit = Application.OpenForms["EditUser"];
            if (fedit == null || fedit.IsDisposed)
            {
                Users.EditUser uedit = new Users.EditUser();
                uedit.Show();
            }
            else
            {
                fedit.Activate();
                fedit.WindowState = FormWindowState.Normal;
            }
        }

        private void 企业信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 岗位检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "岗位参数查询";
            groupBox1.Visible = true;
            dataGridView1.Visible = true;
            radioButton1.Checked = true;
            comboBox1.Visible = false;
            dataGridView1.ReadOnly = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
            comboBox1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button1.Visible = false;
            comboBox1.Visible = true;
            sqlstr = "select 岗位分类 from Job group by 岗位分类";
            comboBox1.Items.Clear();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable t1 = new db_query().gettable(sqlstr);
            for (int i = 0; i < t1.Rows.Count; i++)
                comboBox1.Items.Add(t1.Rows[i][0].ToString());
            groupBox1.BackColor = Color.Transparent;
        }
        private string sqlstr = "";
        private void button1_Click(object sender, EventArgs e)
        {
            sqlstr = "select * from Job";
            if (textBox1.Text.Trim() != "")
                sqlstr += " where 岗位名称 like '%'+'"+textBox1.Text.Trim()+"'+'%'";
            //MessageBox.Show(sqlstr);
            dataGridView1.DataSource = new db_query().gettable(sqlstr);
            dataGridView1.AllowUserToAddRows = false;//去掉datasource的最后一行空白
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlstr = "select * from Job where 岗位分类='" + comboBox1.Text + "'";
            dataGridView1.DataSource = new db_query().gettable(sqlstr);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void 毕业生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            string sqlstr = "select 学号,密码,姓名,性别,年级,院校,专业 from Graduates";
            DataTable t = new db_query().gettable(sqlstr);
            dataGridView1.Visible = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = t;
            dataGridView1.AllowUserToAddRows = false;
        }
        private int status = 0;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            status++;
            if (status == 1)
            {
                if (e.ColumnIndex == 0)
                {
                    MessageBox.Show("岗位ID不能修改！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    dataGridView1.CurrentCell.Value = strval;
                    return;
                }
                string strcolumn1 = dataGridView1.Columns[e.ColumnIndex].HeaderText;//得到列标题
                string strvalue1 = dataGridView1.CurrentCell.Value.ToString();//得到数据
                string strid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//得到所选行第一列的数据
                if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strinsert = "update Job set " + strcolumn1 + "='" + strvalue1 + "' where ID='" + strid + "'";
                    new db_query().noquery(strinsert);
                }
                else
                    dataGridView1.CurrentCell.Value = strval;
            }
            status = 0;
        }
        private string strval;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            strval = dataGridView1.CurrentCell.Value.ToString();
        }

        private void 发布岗位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form faj = Application.OpenForms["AddJob"];
            if (faj == null || faj.IsDisposed)
            {
                AddJob aj = new AddJob(); ;
                aj.Show();
            }
            else
            {
                faj.Activate();
                faj.WindowState = FormWindowState.Normal;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strrow = dataGridView1.CurrentCell.Value.ToString();
            string destr = "delete Job where ID='" + strrow + "'";
            dataGridView1.Rows.RemoveAt(index);
            MessageBox.Show(destr);
            new db_query().noquery(destr);
            MessageBox.Show("岗位已删除");
        }

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

    }
}
