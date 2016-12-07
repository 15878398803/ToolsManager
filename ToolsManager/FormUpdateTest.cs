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
    public partial class FormUpdateTest : Form
    {
        public JsonEntity.ReadyToolsItem tool = null;
        public FormUpdateTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItems.Count == 0)
            {
                if (MessageBox.Show("此工具是否完好无损？", "检查", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //await Server.UpdateTestList(Global.LoginInfo.user_id,Global.LoginInfo.user_code,)
                }else
                {
                    MessageBox.Show("请选择检查出来的缺陷");
                    return;
                }
            }else
            {

            }
        }

        async private void FormUpdateTest_Load(object sender, EventArgs e)
        {
            if (tool == null)
            {
                MessageBox.Show("选择要检查的工器具");
                Close();
            }
            else
            {

                await Server.GetDefectList(Convert.ToInt32(tool.class_id));
                checkedListBox1.Items.Clear();
                foreach (var i in Global.DefectList)
                {
                    checkedListBox1.Items.Add(i.defect_id + "|" + i.defect_name, false);
                }
            }
        }
    }
}
