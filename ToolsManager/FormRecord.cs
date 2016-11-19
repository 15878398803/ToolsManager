using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private bool isInit;
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
            if (cur <= 0)
                cur = 1;
            if (await Server.GetReceiveList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, cur, Global.PageNum))
            {
                lb_cur.Text = "第" + Global.ReceiveList.num.page + "页";
                var sum = Global.ReceiveList.num.list_num / Global.PageNum;
                maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                curPage = cur;

                //此处不应该改全局变量里的List来改变显示内容
                //for (int i = 0; i < Global.ReceiveList.list.Count; i++)
                //{
                //    if (Global.ReceiveList.list[i].type == "1")
                //    {
                //        Global.ReceiveList.list[i].return_time = "";
                //        Global.ReceiveList.list[i].return_user_id = "";
                //        Global.ReceiveList.list[i].return_user_name = "";
                //        Global.ReceiveList.list[i].type = "未归还";
                //    }
                //    else
                //    {
                //        Global.ReceiveList.list[i].type = "已归还";
                //    }
                //}

                dataGridView1.DataSource = Global.ReceiveList.list;
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var t = dataGridView1.Rows[i].Cells;
                    if (t[10].Value as string == "1")
                    {
                        var c = new DataGridViewCellStyle(t[10].Style);
                        c.BackColor = Color.Red;
                        c.ForeColor = Color.White;
                        t[10].Style = c;
                        //对value的修改会影响绑定的List，务必注意
                        t[9].Value = t[7].Value = t[14].Value = t[5].Value = "";
                        t[10].Value = "未归还";
                        
                    }
                    else
                    {
                        //对value的修改会影响绑定的List，务必注意
                        t[10].Value = "已归还";
                    }
                }
                dataGridView1.Columns[0].HeaderText = "记录id";
                dataGridView1.Columns[1].HeaderText = "工具id";
                dataGridView1.Columns[2].HeaderText = "站点id";
                dataGridView1.Columns[3].HeaderText = "工作票号id";
                dataGridView1.Columns[4].HeaderText = "领用人id";
                dataGridView1.Columns[5].HeaderText = "归还人id";
                dataGridView1.Columns[6].HeaderText = "领用时间";
                dataGridView1.Columns[7].HeaderText = "归还时间";
                dataGridView1.Columns[8].HeaderText = "领用时是否完好";
                dataGridView1.Columns[9].HeaderText = "归还时是否完好";
                dataGridView1.Columns[10].HeaderText = "是否归还";
                dataGridView1.Columns[11].HeaderText = "工具名称";
                dataGridView1.Columns[12].HeaderText = "工具编号";
                dataGridView1.Columns[13].HeaderText = "领用人名称";
                dataGridView1.Columns[14].HeaderText = "归还人名称";
                dataGridView1.Columns[15].HeaderText = "工作票号";

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    //全部列不可修改
                    dataGridView1.Columns[i].ReadOnly = true;
                    //拉伸列宽来填满表格
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }


            }
            return true;
        }
        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "领还明细":
                    lastTable = "领还明细";
                    //comboBox1.SelectedIndex = 0;
                    await TableReceiveList(1);
                    isInit = true;
                    if (comboBox1.Items.Count != maxPageNum)
                    {
                        Global.AddComboxNum(comboBox1, maxPageNum);
                        comboBox1.SelectedIndex = 0;
                    }
                    isInit = false;
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

        async private void ll_Last_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (lastTable)
            {
                case "领还明细":
                    lastTable = "领还明细";
                    await TableReceiveList(curPage - 1);
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

        async private void ll_Next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (lastTable)
            {
                case "领还明细":
                    lastTable = "领还明细";
                    await TableReceiveList(curPage + 1 > maxPageNum ? maxPageNum : curPage + 1);
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

        async private void ll_First_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (lastTable)
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

        async private void ll_End_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (lastTable)
            {
                case "领还明细":
                    lastTable = "领还明细";
                    await TableReceiveList(comboBox1.Items.Count);
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

        async private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInit)
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

        private void ll_Goto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
