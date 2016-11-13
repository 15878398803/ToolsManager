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
    public partial class FormRecord : Form
    {
        public Form parent;
        public FormRecord()
        {
            InitializeComponent();
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {

        }

        private void FormRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormRecord = null;
        }

        private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "领还明细":
                    break;
                case "现存库存":
                    break;
                case "我的领用":
                    break;
                case "单号事件记录表":
                    break;
            }
        }

        private void FormRecord_Shown(object sender, EventArgs e)
        {

        }
    }
}
