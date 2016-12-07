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
    public partial class FormReport : Form
    {
        private string lastTable;
        /// <summary>
        /// 当前页码
        /// </summary>
        private int maxPageNum;
        /// <summary>
        /// 标记位，防止comboBox1的comboBox1_SelectedIndexChanged误触发
        /// </summary>
        private int page = 0;

        private DataGridViewCellStyle color_danger = new DataGridViewCellStyle();

        public FormReport()
        {
            InitializeComponent();
            color_danger.BackColor = Color.Red;
            color_danger.ForeColor = Color.White;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listViewLeft.Items)
            {
                //Debug.WriteLine(i.Text);
                if (i.Text == "工作类别" && Global.LoginInfo.role == 2)
                {
                    i.Remove();
                }
                if (i.Text == "缺陷类别" && Global.LoginInfo.role == 2)
                {
                    i.Remove();
                }
                if (i.Text == "员工权限" && Global.LoginInfo.role == 2)
                {
                    i.Remove();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormReport = null;
        }

        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            label1.Text = listViewLeft.SelectedItems[0].Text;
            ll_First.Text = "第一页";
            if (sender != null)
                page = 0;
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "购买计划":
                    lastTable = "购买计划";
                    await BuyList();
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    await ReadDeathList(page + 1);
                    break;
                //case "局报废汇总":
                //    lastTable = "局报废汇总";
                //    await ReadDeathList(page + 1);
                //    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别";
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    await ReadUserList(page + 1);
                    break;
            }
        }

        private void FormReport_Shown(object sender, EventArgs e)
        {

        }

        async private void 添加NToolStripButton_Click(object sender, EventArgs e)
        {
            switch (lastTable)
            {
                case "申购计划":
                    FormInsertUpdateBuy buy = new FormInsertUpdateBuy();
                    buy.ShowDialog();
                    await BuyList();
                    break;
                case "局申购汇总":
                    break;
                case "报废记录":
                    break;
                case "局报废汇总":
                    break;
                case "工作类别":
                    var f = new FormWorkType();
                    f.ShowDialog();
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    var t = new FormUpdateInsertDefect();
                    t.ShowDialog();
                    await ReadDefectsList(page);
                    listViewLeft_DoubleClick(null, null);
                    break;
                case "员工权限":
                    var a = new FormInsertUpdateUser();
                    a.ShowDialog();
                    await ReadUserList(page);
                    listViewLeft_DoubleClick(null, null);
                    break;
            }
        }

        async private void 修改OToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                switch (lastTable)
                {
                    case "申购计划":
                        FormInsertUpdateBuy buy = new FormInsertUpdateBuy();
                        buy.isUpdate = true;
                        buy.BuyListItem = Global.BuyList.Find(t => t.buyplan_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);
                        buy.ShowDialog();
                        await BuyList();
                        break;
                    case "局申购汇总":
                        dataGridView1.DataSource = null;

                        break;
                    case "报废记录":
                        dataGridView1.DataSource = null;

                        break;
                    case "局报废汇总":
                        dataGridView1.DataSource = null;

                        break;
                    case "工作类别":
                        await Server.GetWorkTypeList();
                        var f = new FormWorkType();
                        f.IsUpdate = true;
                        f.WorkType = Global.WorkTypeList.Find(t => t.work_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);
                        f.ShowDialog();
                        await WorkTypeList();
                        break;
                    case "缺陷类别":
                        var d = new FormUpdateInsertDefect();
                        d.IsUpdate = true;
                        if (page != 0)
                        {
                            d.Defect = Global.DefectList.Find(t => t.defect_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);
                            d.ShowDialog();
                        }

                        //                       await ReadDefectsList(page);
                        listViewLeft_DoubleClick(null, null);
                        break;
                    case "员工权限":
                        await Server.GetUserList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, page, 100);
                        var c = new FormInsertUpdateUser();
                        c.UpdateUser = true;
                        c.updateUserItems = Global.UserList.list.Find(t => t.user_id == dataGridView1.SelectedRows[0].Cells[8].Value as string);
                        c.ShowDialog();
                        listViewLeft_DoubleClick(null, null);
                        break;
                }
            }
            else
            {
                MessageBox.Show("请先选择要修改的数据");
            }
        }

        async private void 删除DToolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                switch (lastTable)
                {
                    case "申购计划":
                        var buy = Global.BuyList.Find(t => t.buyplan_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);

                        if (MessageBox.Show("您确定要删除选中的 " + buy.name + " 的增购计划吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (await Server.DeleteBuyPlan(Global.LoginInfo.user_id, Global.LoginInfo.user_code, buy.buyplan_id))
                            {
                                MessageBox.Show("删除 " + buy.name + " 的增购计划成功");
                                await BuyList();
                            }

                        }
                        break;
                    case "局申购汇总":
                        break;
                    case "报废记录":
                        break;
                    case "局报废汇总":
                        break;
                    case "工作类别":

                        var worktype = Global.WorkTypeList.Find(t => t.work_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);

                        if (MessageBox.Show("您确定要删除工作类别 " + worktype.name + " 吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (await Server.DeleteWork(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(worktype.work_id)))
                            {
                                MessageBox.Show("删除工作类别 " + worktype.name + " 成功");
                                await WorkTypeList();
                            }

                        }
                        break;
                    case "缺陷类别":
                        //                       var toolDefect = Global.WorkTypeList.Find(t => t.work_id == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value as string);
                        if (page != 0)
                        {
                            if (MessageBox.Show("您确定要删除工作类别 " + dataGridView1.SelectedRows[0].Cells[2].Value as string + " 吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (await Server.DeleteDefect(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)))
                                {
                                    MessageBox.Show("删除工作类别 " + dataGridView1.SelectedRows[0].Cells[0].Value as string + " 成功");
                                    //   await WorkTypeList();
                                }
                                listViewLeft_DoubleClick(null, null);
                            }

                        }



                        //}
                        //                        DeleteDefect

                        break;
                    case "员工权限":
                        break;
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的数据");
            }
        }

        private void 刷新toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listViewLeft.SelectedItems.Count > 0)
                listViewLeft_DoubleClick(null, null);
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                Excel.DataGridViewToExcelCSV(dataGridView1);
            }
        }

        private void ll_Next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (page < maxPageNum)
            {
                page++;
                listViewLeft_DoubleClick(null, null);
            }

        }

        private void ll_End_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                page = Global.ToolClass.Count;
                listViewLeft_DoubleClick(null, null);
            }
            catch
            {

            }

        }

        private void ll_Last_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (page > 0)
            {
                page--;
                listViewLeft_DoubleClick(null, null);
            }

        }

        private void ll_First_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = 0;
            listViewLeft_DoubleClick(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = Convert.ToInt32(comboBox1.Text);
            listViewLeft_DoubleClick(null, null);
        }

        async public Task<bool> WorkTypeList()
        {
            page = 0;
            maxPageNum = 1;
            comboBox1.Items.Clear();
            comboBox1.Items.Add(1);
            if (await Server.GetWorkTypeList())
            {
                if (Global.WorkTypeList.Count == 0)
                {
                    MessageBox.Show("暂无任何工作类别");
                    return true;
                }
                flowLayoutPanel1.Enabled = true;
                lb_cur.Text = "第1页";
                lb_sum.Text = "共1页";
                foreach (var w in Global.WorkTypeList)
                {
                    switch (w.is_input)
                    {
                        case "1":
                            w.is_input = "有输入框";
                            break;
                        case "0":
                            w.is_input = "无输入框";
                            break;
                    }
                    switch (w.type)
                    {
                        case "0":
                            w.type = "全部用户可用";
                            break;
                        case "1":
                            w.type = "站点管理员可用";
                            break;
                    }
                    switch (w.special)
                    {
                        case "0":
                            w.special = "普通工作";
                            break;
                        case "1":
                            w.special = "已建任务";
                            break;
                        case "2":
                            w.special = "定期检查";
                            break;
                    }

                }
                dataGridView1.DataSource = Global.WorkTypeList;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                    var t = dataGridView1.Rows[i].Cells;
                }

                dataGridView1.Columns[0].HeaderText = "任务类型id标识";
                dataGridView1.Columns[1].HeaderText = "任务类型名称";
                dataGridView1.Columns[2].HeaderText = "是否有输入框";
                dataGridView1.Columns[3].HeaderText = "使用权限";
                dataGridView1.Columns[4].HeaderText = "工作类别";
                dataGridView1.Columns[5].HeaderText = "类型图片";

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
        async public Task<bool> ReadDefectsList(int page)
        {
            ll_First.Text = "首页";
            if (page == 0)
            {
                int x = 1;
                maxPageNum = 1;
                await Server.GetToolClasses();
                if (Global.ToolClass.Count == 0)
                {
                    MessageBox.Show("暂无任何工具类别");
                    return false;
                }
                foreach (var toolc in Global.ToolClass)
                {

                    toolc.page_num = x;
                    x++;
                }

                lb_cur.Text = "第" + 0 + "页";
                lb_sum.Text = "共" + Global.ToolClass.Count + "页";
                if (Global.ToolClass.Count != comboBox1.Items.Count)
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i <= Global.ToolClass.Count; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                dataGridView1.DataSource = Global.ToolClass;
                dataGridView1.RowHeadersVisible = false;
                if (Global.ToolClass.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "页码";
                    dataGridView1.Columns[1].HeaderText = "科目id标识";
                    dataGridView1.Columns[2].HeaderText = "科目名称";
                    dataGridView1.Columns[3].HeaderText = "备注";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                        var t = dataGridView1.Rows[i].Cells;

                    }
                }

            }
            else
            {
                //                int list_num = Global.ToolClass.Count;
                //                maxPageNum = (list_num / 100) + 1;
                int y = 1;
                foreach (var toolc in Global.ToolClass)
                {

                    toolc.page_num = y;
                    y++;
                }
                await Server.GetDefectList(Convert.ToInt32(Global.ToolClass.Find(t => t.page_num == page).class_id));
                maxPageNum = Global.ToolClass.Count;
                ;
                lb_cur.Text = "第" + page + "页";
                lb_sum.Text = "共" + Global.ToolClass.Count + "页";
                if (Global.ToolClass.Count != comboBox1.Items.Count)
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i <= Global.ToolClass.Count; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                dataGridView1.DataSource = Global.DefectList;
                dataGridView1.RowHeadersVisible = false;
                if (Global.DefectList.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "缺陷id 标识";
                    dataGridView1.Columns[1].HeaderText = "科目id标识";
                    dataGridView1.Columns[2].HeaderText = "缺陷名称";
                    dataGridView1.Columns[3].HeaderText = "备注";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                        var t = dataGridView1.Rows[i].Cells;

                    }
                }

            }
            return true;
        }
        async public Task<bool> ReadUserList(int page)
        {
            int x = 1;
            await Server.GetStationList();
            await Server.GetUserList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, page, 100);
            if (Global.UserList.list == null)
            {
                MessageBox.Show("获取用户列表失败，无权限");
                return false;
            }
            maxPageNum = ( Global.UserList.num.list_num / Convert.ToInt32(Global.UserList.num.page_num) ) + 1;
            //               int list_num = Global.ToolsList.list.Count;
            lb_cur.Text = "第" + page + "页";
            lb_sum.Text = "共" + maxPageNum + "页";
            maxPageNum--;
            if (maxPageNum != comboBox1.Items.Count)
            {
                Global.AddComboxNum(comboBox1, maxPageNum);
            }
            foreach (var user in Global.UserList.list)
            {
                user.num = x.ToString();
                x++;
                var k = Global.StationList.Find(t => t.station_id == Convert.ToInt32(user.station_id));
                user.station_id = k == null ? "其他" : k.name;
                switch (user.role)
                {
                    case "1":
                        user.role = "1|普通专员";
                        break;
                    case "2":
                        user.role = "2|站点管理员";
                        break;
                    case "3":
                        user.role = "3|局管理员";
                        break;
                    default:
                        user.role = "其他";
                        break;
                }

            }
            dataGridView1.DataSource = Global.UserList.list;
            dataGridView1.RowHeadersVisible = false;
            if (Global.UserList.num.list_num > 0)
            {
                dataGridView1.Columns[0].HeaderText = "序号";
                dataGridView1.Columns[1].HeaderText = "用户姓名";
                dataGridView1.Columns[2].HeaderText = "用户生产班组";
                dataGridView1.Columns[3].HeaderText = "用户名 （工号）";
                dataGridView1.Columns[4].HeaderText = "用户角色";
                dataGridView1.Columns[5].HeaderText = "初始密码";
                dataGridView1.Columns[6].HeaderText = "站点id标识";
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                    var t = dataGridView1.Rows[i].Cells;

                }
            }
            return true;
        }
        async public Task<bool> ReadDeathList(int page)
        {
            int x = 1;
            if (await Server.GetDeathList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, page, Global.PageNum))
            {
                await Server.GetStationList();
                if (Global.DeathList.list == null)
                {
                    return false;
                }
                lb_cur.Text = "第" + page + "页";
                maxPageNum = ( Convert.ToInt32(Global.DeathList.num.list_num) / Convert.ToInt32(Global.DeathList.num.page_num) ) + 1;
                lb_sum.Text = "共" + maxPageNum + "页";
                if (maxPageNum != comboBox1.Items.Count)
                {
                    comboBox1.Items.Clear();
                    for (int i = 1; i <= maxPageNum; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                foreach (var death in Global.DeathList.list)
                {
                    var s = Global.StationList.Find(t => t.station_id == Convert.ToInt32(death.station_id));
                    if (s != null)
                    {
                        death.station_id = s.name + "(" + death.station_id + ")";
                    }
                    else
                    {
                        death.station_id = "其他" + "(" + death.station_id + ")";
                    }
                    death.num = x.ToString();
                    x++;
                }
                //foreach (var t in Global.TaskList.list)
                //{
                //    if (t.type_complete == "1")
                //        t.type_complete = "是";
                //    else
                //        t.type_complete = "否";
                //    t.work_id = Global.WorkTypeList.Find(x => x.work_id == t.work_id).name;
                //}
                dataGridView1.DataSource = Global.DeathList.list;
                if (Global.DeathList.list.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "序号";
                    dataGridView1.Columns[1].HeaderText = "报废记录id标识";
                    dataGridView1.Columns[2].HeaderText = "类别id标识";
                    dataGridView1.Columns[3].HeaderText = "类别名称";
                    dataGridView1.Columns[4].HeaderText = "报废时间";
                    dataGridView1.Columns[5].HeaderText = "工具名称";
                    dataGridView1.Columns[6].HeaderText = "工具型号";
                    dataGridView1.Columns[7].HeaderText = "工具编号";
                    dataGridView1.Columns[8].HeaderText = "工具科目";
                    dataGridView1.Columns[9].HeaderText = "出厂时间";
                    dataGridView1.Columns[10].HeaderText = "购买时间";
                    dataGridView1.Columns[11].HeaderText = "生命周期";
                    dataGridView1.Columns[12].HeaderText = "报废原因";
                    dataGridView1.Columns[13].HeaderText = "站点id标识";
                    dataGridView1.Columns[14].HeaderText = "备注";

                    if (Global.LoginInfo.station_id != "0")
                        dataGridView1.Columns[13].Visible = false;
                    else
                        dataGridView1.Columns[13].Visible = true;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                        var t = dataGridView1.Rows[i].Cells;

                    }
                }
            }
            return true;
        }
        async public Task<bool> BuyList()
        {

            if (await Server.GetBuyList(Global.LoginInfo.user_id, Global.LoginInfo.user_code))
            {
                lb_cur.Text = "第1页";
                lb_sum.Text = "共1页";
                comboBox1.Items.Clear();
                if (Global.BuyList == null)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("无定期检查记录");
                    return true;
                }
                dataGridView1.DataSource = Global.BuyList;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    var t = dataGridView1.Rows[i].Cells;
                    var type = t[7].Value.ToString();
                    if (type == "1")
                    {
                        t[7].Value = "手动添加";
                    }
                    else if (type == "2")
                    {
                        t[7].Value = "报废换新";
                    }
                }
                if (Global.BuyList.Count >= 0)
                {
                    dataGridView1.Columns[0].HeaderText = "增购计划ID";
                    dataGridView1.Columns[1].HeaderText = "站点ID";
                    dataGridView1.Columns[2].HeaderText = "传感器ID";
                    dataGridView1.Columns[3].HeaderText = "传感器名称";
                    dataGridView1.Columns[4].HeaderText = "工具名称";
                    dataGridView1.Columns[5].HeaderText = "工具型号";
                    dataGridView1.Columns[6].HeaderText = "工具编号";
                    dataGridView1.Columns[7].HeaderText = "类别";

                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
            return true;
        }
    }
}
