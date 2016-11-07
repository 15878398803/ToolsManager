using System;
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
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            switch (listView1.SelectedItems[0].Index)
            {
                case 0:
                    if (Global.formRecord == null)
                    {
                        Global.formRecord = new FormRecord();
                        Global.formRecord.TopMost = true;
                        Global.formRecord.Show();
                    }
                    break;
                case 1:
                    if (Global.formMaintain == null)
                    {
                        Global.formMaintain = new FormMaintain();
                        Global.formMaintain.TopMost = true;
                        Global.formMaintain.Show();
                    }
                    break;
                case 2:
                    if (Global.formReport == null)
                    {
                        Global.formReport = new FormReport();
                        Global.formReport.TopMost = true;
                        Global.formReport.Show();
                    }
                    break;
                case 3:
                    if (Global.formSubsystem == null)
                    {
                        Global.formSubsystem = new FormSubsystem();
                        Global.formSubsystem.TopMost = true;
                        Global.formSubsystem.Show();
                    }
                    break;
                case 4:
                    if (Global.formSettings == null)
                    {
                        Global.formSettings = new FormSettings();
                        Global.formSettings.TopMost = true;
                        Global.formSettings.Show();
                    }
                    break;
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formLogin.Show();
            this.Dispose();
        }
    }
}
