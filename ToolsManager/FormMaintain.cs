using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormMaintain : Form
    {
        public FormMaintain()
        {
            InitializeComponent();
        }

        private void FormMaintain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormMaintain = null;
        }

        private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "台账报表":
                    break;
                case "综合管理":
                    break;
                case "预送检表":
                    break;
                case "预报废表":
                    break;
                case "定期检查":
                    break;
                case "送检反馈":
                    break;
                case "逾期记录":
                    break;
                case "增购申请":
                    break;
            }
        }

        private void FormMaintain_Load(object sender, EventArgs e)
        {

        }

        private void FormMaintain_Shown(object sender, EventArgs e)
        {

        }
    }
}
