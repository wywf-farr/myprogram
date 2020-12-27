using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Security.Cryptography;//用来进行加密的一些类

namespace 大学生就业咨询系统
{
    public partial class Login : Form
    {
        private static string UserSort;
        private static string LoginName;         //设置成私有属性可以保证其数据的安全性
        public string loginname
        {
            get
            {
                return LoginName;
            }

        }

        public string UserSt              //只读的共有属性Usert作用是使外界可以访问私有属性UserSort
        {
            get
            {
                return UserSort;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //登录的简单限制
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                textBox2.Focus();
                return;
            }
            //判断用户是否为管理员
            UserSort = UserCheckSort(textBox1.Text.Trim(), textBox2.Text.Trim());
            //MessageBox.Show(UserSort);
            if (UserSort != "")
            {
                //如果是三种用户之一的话,进入主界面 并标注用户类型
                //this.DialogResult = DialogResult.OK;
                Panel.MainForm main = new Panel.MainForm(this);
                this.Hide();
                main.Show();
            }
            else
            {
                //如果不是有效用户,继续显示登录框
                this.Show();
            }
        }

        //此函数的功能是根据输入的用于名和密码来判断用户的类型，并将用户的类型返回
        private string UserCheckSort(string username, string password)
        {
            string usersort = "";
            DataTable t = new DataTable();
            //实例化一个连接的对象
            db_query myconn = new db_query();
            string sqlstr = "select 学号,密码,UserSort from Graduates where 学号='" + username + "'";
            t=myconn.gettable(sqlstr);
            
            // 从数据库中读取数据
            if (t != null)
            {
                // 读出表中第二列的值（即密码）与输入的数据的比较来判断用户的权限
                if (t.Rows[0][1].ToString() == password)
                {
                    usersort = t.Rows[0][2].ToString();//返回用户类别	
                    LoginName = t.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("用户名或者密码有错误，请验证！");
                }
            }
            else
            {
                MessageBox.Show("没有该用户");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            return usersort;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //调用用户注册的窗口
            Form reg = Application.OpenForms["Register"];
            if (reg == null || reg.IsDisposed)
            {
                Users.Register re = new Users.Register();
                re.Show();
            }
            else
            {
                reg.Activate();
                reg.WindowState = FormWindowState.Normal;
            }
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
        Boolean textboxHasText = false;//判断输入框是否有文本
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "学号";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
    }
}
