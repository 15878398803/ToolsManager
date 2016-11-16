using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormRecord : Form
    {
        private string lastTable;
        private int curPage, maxPageNum;
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
        async public Task<bool> TableReceiveList(int cur)
        {
            if (await Server.GetReceiveList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, cur, Global.PageNum))
            {
                lb_cur.Text = "第" + Global.ReceiveList.num.page + "页";
                var sum = Global.ReceiveList.num.list_num / Global.PageNum;
                maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                curPage = cur;
                Global.AddComboxNum(comboBox1, maxPageNum);

                dataGridView1.DataSource = Global.ReceiveList.list;
            }
            return true;
        }
        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "领还明细":
                    lastTable = "领还明细";
                    await TableReceiveList(1);
                    break;
                case "现存库存":
                    lastTable = "现存库存";
                    break;
                case "我的领用":
                    lastTable = "我的领用";
                    break;
                case "单号事件记录表":
                    lastTable = "单号事件记录表";
                    break;
            }
        }

        private void FormRecord_Shown(object sender, EventArgs e)
        {

        }

        async private void ll_Goto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (lastTable)
            {
                case "领还明细":
                    lastTable = "领还明细";
                    await TableReceiveList(comboBox1.SelectedIndex + 1);
                    break;
                case "现存库存":
                    lastTable = "现存库存";
                    break;
                case "我的领用":
                    lastTable = "我的领用";
                    break;
                case "单号事件记录表":
                    lastTable = "单号事件记录表";
                    break;
            }
        }
    }
}
