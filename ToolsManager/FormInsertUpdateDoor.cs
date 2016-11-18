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
    public partial class FormInsertUpdateDoor : Form
    {
        public bool isUpdate = false;
        public JsonEntity.Door door = null;

        public FormInsertUpdateDoor()
        {
            InitializeComponent();
        }

        private void FormInsertUpdateDoor_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                textBox1.Text = door.name;
                textBox2.Text = door.code;
                textBox3.Text = door.memo;
                Text = "修改门信息";
                button2.Text = "修改";
            }
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                if (await Server.UpdateDoor(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(door.door_id), Global.StationId, textBox1.Text, textBox2.Text, textBox3.Text))
                {
                    MessageBox.Show("修改门信息成功");
                }
                else
                {
                    MessageBox.Show("修改门信息失败");

                }
            }
            else
            {
                if (await Server.InsertDoor(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Global.StationId, textBox1.Text, textBox2.Text, textBox3.Text))

                {
                    MessageBox.Show("门添加成功");
                }
                else
                {
                    MessageBox.Show("门添加失败");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
