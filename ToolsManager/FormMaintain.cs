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
        int page = 1;
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
            await Server.Login("yyq", "123456");
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "台账报表":
                    await Server.GetToolsList(Convert.ToInt32(Global.LoginInfo.user_id) , Global.LoginInfo.user_code, page, 3);
                    DataTable datatable = new DataTable();
                    datatable.Columns.Add("工具标识", typeof(string));
                    datatable.Columns.Add("传感器标识", typeof(string));
                    datatable.Columns.Add("站点id标识", typeof(string));
                    datatable.Columns.Add("科目id标识", typeof(string));
                    datatable.Columns.Add("领用人id标识", typeof(string));
                    datatable.Columns.Add("工具名称", typeof(string));
                    datatable.Columns.Add("工具型号", typeof(string));
                    datatable.Columns.Add("工具编号", typeof(string));
                    datatable.Columns.Add("工具类别", typeof(string));
                    datatable.Columns.Add("出厂日期", typeof(string));
                    datatable.Columns.Add("购买日期", typeof(string));
                    datatable.Columns.Add("试验日期", typeof(string));
                    datatable.Columns.Add("试验周期", typeof(string));
                    datatable.Columns.Add("生命周期", typeof(string));
                    datatable.Columns.Add("生产厂商", typeof(string));
                    datatable.Columns.Add("传感器名称", typeof(string));
                    datatable.Columns.Add("科目名称", typeof(string));
                    datatable.Columns.Add("下次试验日期", typeof(string));
                    datatable.Columns.Add("报废日期", typeof(string));
                    datatable.Columns.Add("是否在库", typeof(string));
                    datatable.Columns.Add("用户", typeof(string));                   
                    foreach (var tool in Global.ToolsList.list)
                    {
                        DataRow row = datatable.NewRow();
                        row["工具标识"] = tool.tool_id;
                        row["传感器标识"] = tool.sensor_id;
                        row["站点id标识"] = tool.station_id;
                        row["科目id标识"] = tool.class_id;
                        row["领用人id标识"] = tool.user_id;
                        row["工具名称"] = tool.name;
                        row["工具型号"] = tool.model;
                        row["工具编号"] = tool.number;
                        row["工具类别"] = tool.subject;
                        row["出厂日期"] = tool.factory_time;
                        row["购买日期"] = tool.buy_time;
                        row["试验日期"] = tool.test_time;
                        row["试验周期"] = tool.test_cycle;
                        row["生命周期"] = tool.life_cycle;
                        row["生产厂商"] = tool.vender;
                        row["传感器名称"] = tool.sensor_name;
                        row["科目名称"] = tool.class_name;
                        row["下次试验日期"] = tool.next_test;
                        row["报废日期"] = tool.death_time;
                        row["是否在库"] = tool.in_depot;
                        row["用户"] = tool.user_name;
                        datatable.Rows.Add(row);
                    }
                    dataGridView1.DataSource = datatable;
                    dataGridView1.RowHeadersVisible = false;
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
    }
}
