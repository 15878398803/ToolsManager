using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            if (Properties.Settings.Default.第一次运行)
            {
                FormLocal f = new FormLocal();
                f.TopMost = true;
                f.Show();
                this.Hide();
                return;
            }
            Text = Properties.Settings.Default.供电局名称 + " - " + Properties.Settings.Default.站点名称 + " - " + "智能物联工器具管理系统";
            label_main.Text = Properties.Settings.Default.供电局名称;
            label_sub.Text = "(" + Properties.Settings.Default.站点名称 + ")";

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
            //await Server.GetUserList(2, "8d9dad5db5c07313a4331466ec461f24", 2, 2);
            //await Server.InsertUser(2, "8d9dad5db5c07313a4331466ec461f24", 1, "名", "班", "OPEN", "用户名", "passwd", "7");
            //await Server.UpdateUser(2, "8d9dad5db5c07313a4331466ec461f24", 1, "名", "班", "OPEN", "用户名a", "passwd", "7", 18);
            //await Server.InsertWork(2, "8d9dad5db5c07313a4331466ec461f24","名",true, "http://www.baidu.com/img/bd_logo1.png", 1);
            //await Server.UpdateWork(2, "8d9dad5db5c07313a4331466ec461f24", 8,"名a", false, "http://www.baidu.com/img/bd_logo1.png", 2);
            //await Server.DeleteWork(2, "8d9dad5db5c07313a4331466ec461f24", 9);
            //await Server.GetTaskList(2, "befdf52430eb27e3b87cfe03a24f4b70",1, 2);
            //await Server.UpdateTask(2, "befdf52430eb27e3b87cfe03a24f4b70", 1, 2,"t1","Team",1,"mem");
            //await Server.GetDoorL0ist("a");
            //await Server.InsertDoor(2, "befdf52430eb27e3b87cfe03a24f4b70", 3, "yyqdoor", "T213", "memo");
            //await Server.DeleteDoor(2, "befdf52430eb27e3b87cfe03a24f4b70", 1011);
            //await Server.GetOpenDoorList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 1);

            //await Server.GetReceiveList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 10);
            //await Server.GetTaskList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 3);
            //await Server.GetTaskList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 2, 3);
            //await Server.GetReadyTestTools(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Global.StationId);
            //await Server.GetReadyDeathTools(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Global.StationId);

            //var f = new FormInsertUpdateToolClass();
            //await Server.GetToolClasses();
            //f.isUpdate = true;
            //f.toolclass = Global.ToolClass[22];
            //f.Show();
            //await Server.UpdateStation(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 4, "YYQ", "123");

            //var f = new FormInsertUpdateTools();
            //await Server.GetToolsList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 20);
            //await Server.GetToolClasses();
            ////f.isUpdateTool = true;
            //f.updateTool = Global.ToolsList.list[0];
            //f.Show();



            //var f = new FormInsertUpdateUser();
            //await Server.GetUserList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 10);
            //f.updateUserItems = Global.UserList.list[9];
            //f.UpdateUser = true;
            //f.Show();

            //var f = new FormUpdateInsertDefect();
            //f.IsUpdate = true;
            //await Server.GetDefectList(2);
            //f.Defect = Global.DefectList[0];
            //f.Show();

            //var f = new FormWorkType();
            //await Server.GetWorkTypeList();
            ////f.IsUpdate = true;
            ////f.WorkType = Global.WorkTypeList[0];
            //f.Show();

            //var f = new FormInsertUpdateStations();

            //await Server.GetStationList();
            //f.isUpdate = true;
            //f.station = Global.StationList[0];
            ////f.WorkType = Global.WorkTypeList[0];
            //f.Show();
            var f = new FormUpdateTask();
            await Server.GetTaskList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 20);
            f.tasklist = Global.TaskList.list[0];
            f.Show();

        }
        async private void btn_login_Click(object sender, EventArgs e)
        {

            //超级密码为123465
            if (tx_username.Text == "admin")
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(tx_password.Text));
                if (BitConverter.ToString(output).Replace("-", "").ToUpper() == Properties.Settings.Default.pwd.Trim())
                {
                    FormLocal f = new FormLocal();
                    f.TopMost = true;
                    f.Show();
                    this.Hide();
                    return;
                }
            }
            //Global.FormLoading.Show();
#if DEBUG
            //Debug.WriteLine("使用默认账号yyq登录调试");
            tx_username.Text = "yyqq";
            tx_password.Text = "123456";
#endif
            var result = await Server.Login(tx_username.Text, tx_password.Text);

            if (result)
            {
                Test();

                //登录成功
                //Global.FormRecord.Show();


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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0004_登录矩形框_移动反馈;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0005_登录矩形框;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0003_登录矩形框_点击反馈;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0005_登录矩形框;

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0000__退_出___点击反馈;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0001__退_出__移动反馈;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0002__退_出_;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0002__退_出_;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tx_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(null, null);
            }
        }
    }
}
