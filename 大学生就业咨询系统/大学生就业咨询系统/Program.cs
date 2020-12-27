using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大学生就业咨询系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            
            //设置登录窗体先启动，成功后再启动主窗口
            /*
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Login login=new Login();
                if(login.ShowDialog() == DialogResult.OK)
                    Application.Run(new Panel.MainForm());//主窗体
                else
                    Application.Exit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"系统登录",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                Application.Exit();
            }
             */
        }
    }
}
