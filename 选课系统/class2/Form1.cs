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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)(this));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins//Wave.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f2 = Application.OpenForms["Form2"];
            if (f2 == null || f2.IsDisposed)
            {
                Form2 fm2 = new Form2();
                fm2.Show();
            }
            else
            {
                f2.Activate();
                f2.WindowState = FormWindowState.Normal;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f3 = Application.OpenForms["Form3"];
            if (f3 == null || f3.IsDisposed)
            {
                Form3 fm3 = new Form3();
                fm3.Show();
            }
            else
            {
                f3.Activate();
                f3.WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f4 = Application.OpenForms["Form4"];
            if (f4 == null || f4.IsDisposed)
            {
                Form4 fm4 = new Form4();
                fm4.Show();
            }
            else
            {
                f4.Activate();
                f4.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f5 = Application.OpenForms["Form5"];
            if (f5 == null || f5.IsDisposed)
            {
                Form5 fm5 = new Form5();
                fm5.Show();
            }
            else
            {
                f5.Activate();
                f5.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
