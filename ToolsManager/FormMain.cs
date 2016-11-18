﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Text = Properties.Settings.Default.供电局名称 + " - " + Properties.Settings.Default.站点名称 + " - " + "智能物联工器具管理系统";
        }
        /// <summary>
        /// 打开各个功能窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            switch (listView1.SelectedItems[0].Text)
            {
                case "领还记录":

                    Global.FormRecord.Show();
                    Global.FormRecord.Focus();
                    break;
                case "维护管理":

                    Global.FormMaintain.Show();
                    Global.FormMaintain.Focus();

                    break;
                case "业务报表":

                    Global.FormReport.Show();
                    Global.FormReport.Focus();

                    break;
                case "子系统":

                    Global.FormSubsystem.Show();
                    Global.FormSubsystem.Focus();

                    break;
                case "个人设置":

                    Global.FormSettings.Show();
                    Global.FormSettings.Focus();

                    break;
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormMain = null;
            Global.FormLogin.Show();

        }

        private void FormMain_Shown(object sender, EventArgs e)
        {

        }
    }
}
