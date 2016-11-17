using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ToolsManager
{
    public partial class FormMaintain : Form
    {

        int page = 1;
        private int curPage, maxPageNum;
        public FormMaintain()
        {
            InitializeComponent();
        }

        private void FormMaintain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormMaintain = null;
        }

        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            //DataTable datatable = new DataTable();
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "台账报表":
                    await TableToolsList(page);
                    //if (Global.ToolsList!=null)
                    //{

                    //    datatable.Columns.Add("工具标识", typeof(string));
                    //    datatable.Columns.Add("传感器标识", typeof(string));
                    //    datatable.Columns.Add("站点id标识", typeof(string));
                    //    datatable.Columns.Add("科目id标识", typeof(string));
                    //    datatable.Columns.Add("领用人id标识", typeof(string));
                    //    datatable.Columns.Add("工具名称", typeof(string));
                    //    datatable.Columns.Add("工具型号", typeof(string));
                    //    datatable.Columns.Add("工具编号", typeof(string));
                    //    datatable.Columns.Add("工具类别", typeof(string));
                    //    datatable.Columns.Add("出厂日期", typeof(string));
                    //    datatable.Columns.Add("购买日期", typeof(string));
                    //    datatable.Columns.Add("试验日期", typeof(string));
                    //    datatable.Columns.Add("试验周期", typeof(string));
                    //    datatable.Columns.Add("生命周期", typeof(string));
                    //    datatable.Columns.Add("生产厂商", typeof(string));
                    //    datatable.Columns.Add("传感器名称", typeof(string));
                    //    datatable.Columns.Add("科目名称", typeof(string));
                    //    datatable.Columns.Add("下次试验日期", typeof(string));
                    //    datatable.Columns.Add("报废日期", typeof(string));
                    //    datatable.Columns.Add("是否在库", typeof(string));
                    //    datatable.Columns.Add("用户", typeof(string));

                    //    foreach (var tool in Global.ToolsList.list)
                    //    {
                    //        DataRow row = datatable.NewRow();
                    //        row["工具标识"] = tool.tool_id;
                    //        row["传感器标识"] = tool.sensor_id;
                    //        row["站点id标识"] = tool.station_id;
                    //        row["科目id标识"] = tool.class_id;
                    //        row["领用人id标识"] = tool.user_id;
                    //        row["工具名称"] = tool.name;
                    //        row["工具型号"] = tool.model;
                    //        row["工具编号"] = tool.number;
                    //        row["工具类别"] = tool.subject;
                    //        row["出厂日期"] = tool.factory_time;
                    //        row["购买日期"] = tool.buy_time;
                    //        row["试验日期"] = tool.test_time;
                    //        row["试验周期"] = tool.test_cycle;
                    //        row["生命周期"] = tool.life_cycle;
                    //        row["生产厂商"] = tool.vender;
                    //        row["传感器名称"] = tool.sensor_name;
                    //        row["科目名称"] = tool.class_name;
                    //        row["下次试验日期"] = tool.next_test;
                    //        row["报废日期"] = tool.death_time;
                    //        row["是否在库"] = tool.in_depot;
                    //        row["用户"] = tool.user_name;
                    //        datatable.Rows.Add(row);
                    //    }
                    //    dataGridView1.DataSource = datatable;
                    //    dataGridView1.RowHeadersVisible = false;
                    //    }
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

        private void Last_MouseClick(object sender, MouseEventArgs e)
        {
            page--;
            listViewLeft_DoubleClick(null, null);
        }

        private void Next_MouseClick(object sender, MouseEventArgs e)
        {
            page++;
            listViewLeft_DoubleClick(null, null);
        }

        private void First_MouseClick(object sender, MouseEventArgs e)
        {
            page = 1;
            listViewLeft_DoubleClick(null, null);
        }

        async public Task<bool> TableToolsList(int cur)
        {
            if (cur <= 0)
                cur = 1;
            if (await Server.GetToolsList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, cur, Global.PageNum))
            {
                lb_cur.Text = "第" + Global.ToolsList.num.page + "页";
                var sum = Global.ToolsList.num.list_num / Global.PageNum;
                maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                curPage = cur;
                Global.AddComboxNum(comboBox1, maxPageNum);
                dataGridView1.DataSource = Global.ToolsList.list;
                dataGridView1.RowHeadersVisible = false;
            }
            return true;
        }

        async public Task<bool> TableToolsLis(int cur)
        {
            if (cur <= 0)
                cur = 1;
            if (await Server.GetToolsList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, cur, Global.PageNum))
            {
                lb_cur.Text = "第" + Global.ToolsList.num.page + "页";
                var sum = Global.ToolsList.num.list_num / Global.PageNum;
                maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                curPage = cur;
                Global.AddComboxNum(comboBox1, maxPageNum);
                dataGridView1.DataSource = Global.ToolsList.list;
                dataGridView1.RowHeadersVisible = false;
            }
            return true;
        }
    }
}
