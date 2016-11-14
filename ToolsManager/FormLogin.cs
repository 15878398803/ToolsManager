using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //async Task<string> test()//模拟异步方法调用
        //{
        //    int i = 0;
        //    Action Act = delegate ()
        //    { Thread.Sleep(1000); i += 1000; };
        //    for (int a = 0; a < 5; a++)
        //    {
        //        await Task.Factory.StartNew(Act);
        //        Debug.WriteLine("等待了" + i.ToString() + "毫秒");
        //    }
        //    return "5000毫秒等待后返回结果";
        //}
        async private void Test()
        {
            //await Server.GetToolsList(2, "8d9dad5db5c07313a4331466ec461f24", 1, 2);
            //await Server.GetSensorList(2, "8d9dad5db5c07313a4331466ec461f24", 1, 2);
            //await Server.AddTool(2, "8d9dad5db5c07313a4331466ec461f24", 3, 4, "5", "6", "7", 8, DateTime.Now.AddYears(1), DateTime.Now.AddMonths(1), DateTime.Now.AddDays(1), 9, 10, "11");
            //await Server.UpdateTool(2, "8d9dad5db5c07313a4331466ec461f24", 10, 3, 4, "5", "6", "7", 8, DateTime.Now.AddYears(1), DateTime.Now.AddMonths(1), DateTime.Now.AddDays(1), 9, 10, "11");
            //await Server.InsertToolClass(2, "8d9dad5db5c07313a4331466ec461f24", "我的类名", "我的备注");
            //await Server.UpdateToolClass(3, "8d9dad5db5c07313a4331466ec461f24", 26, "我的类名new", "我的备注a");
            //await Server.DeleteToolClass(2, "8d9dad5db5c07313a4331466ec461f24", 26);
            //await Server.DeleteTool(2, "8d9dad5db5c07313a4331466ec461f24", 14);
            //await Server.GetDefectList(1);
            //await Server.InsertDefect(2, "8d9dad5db5c07313a4331466ec461f24", 1, "YYQTest", "YYQ");
            //await Server.DeleteDefect(2, "8d9dad5db5c07313a4331466ec461f24", 291);
            //await Server.UpdateDefect(2, "8d9dad5db5c07313a4331466ec461f24", 291,1,"Y","Q");
            await Server.GetUserList(2, "8d9dad5db5c07313a4331466ec461f24", 2, 2);

        }
        async private void btn_login_Click(object sender, EventArgs e)
        {
            Test();
            return;
#if DEBUG
            Debug.WriteLine("使用默认账号yyq登录调试");
            tx_username.Text = "yyq";
            tx_password.Text = "123456";
#endif

            Global.FormLoading.Show();
            var result = await Server.Login(tx_username.Text, tx_password.Text);

            if (result)
            {
                //登录成功
                Global.FormMain.Show();
                Global.FormLogin.Hide();
            }
            else
            {
                //登录失败
            }

            Global.FormLoading.Hide();

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormLogin = null;
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {

        }
    }
}
