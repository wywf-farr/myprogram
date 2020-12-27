using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace class2
{
    class save
    {
        public static int bh=0;
        public static int x;
        public void getlist(ListBox lb)
        {
            string sqlck = "select * from 选课情况 where 编号='"+bh+"'";
            string sqllm = "select name from syscolumns where id=OBJECT_ID('选课情况')";
            DataTable dtlm = new Class1().gettable(sqllm);

            string setfalse = "update 选课情况 set [" + dtlm.Rows[1][0].ToString() + "]='false'";
            string settrue = "update 选课情况 set ";
            if (new Class1().gettable(sqlck) == null)
            {
                new Class1().noquery("insert into 选课情况(编号) values('"+bh+"')");

            }
            for (int c = 0; c < lb.Items.Count; c++)
            {
                if (dtlm.Rows[1][0].ToString() == lb.Items[c].ToString())
                {
                    lb.Items.Remove(lb.Items[c].ToString());
                    settrue += "[" + dtlm.Rows[1][0].ToString() + "]='true',";
                    break;
                }
            }
            for (int i = 2; i < dtlm.Rows.Count; i++)
            {
                setfalse += "," + dtlm.Rows[i][0].ToString() + "='false'";
                for (int j = 0; j < lb.Items.Count; j++)
                {
                    if (dtlm.Rows[i][0].ToString() == lb.Items[j].ToString())
                    {
                        lb.Items.Remove(lb.Items[j].ToString());
                        settrue += dtlm.Rows[i][0].ToString() + "='true',";
                        break;
                    }
                }
            }
            setfalse += " where 编号='"+bh+"'";
            //MessageBox.Show(setfalse);
            new Class1().noquery(setfalse);
            settrue = settrue.Remove(settrue.Length - 1);
            settrue += " where 编号='"+bh+"'";
            //MessageBox.Show(settrue);
            new Class1().noquery(settrue);
            MessageBox.Show("保存成功");
        }
    }
}
