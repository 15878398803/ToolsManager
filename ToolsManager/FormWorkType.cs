using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormWorkType : Form
    {

        public bool IsUpdate = false;
        public JsonEntity.WorkTypeListItem WorkType;
        public FormWorkType()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = textBox2.Text;
        }

        private void FormWorkType_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if (IsUpdate)
            {
                Text = "修改工作类型";
                button1.Text = "修改";
                textBox1.Text = WorkType.name;
                textBox2.Text = WorkType.work_img;
                var a = Convert.ToInt32(WorkType.is_input);
                comboBox1.SelectedIndex = a > 1 ? 1 : a;
                a = Convert.ToInt32(WorkType.type);
                comboBox2.SelectedIndex = a > 1 ? 1 : a;
                pictureBox1.ImageLocation = textBox2.Text;

            }
            else
            {
                comboBox1.SelectedIndex = comboBox2.SelectedIndex = 0;
            }

        }

        async private void button1_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                if (await Server.UpdateWork(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(WorkType.work_id), textBox1.Text, Convert.ToBoolean(comboBox1.SelectedIndex), textBox2.Text, comboBox2.SelectedIndex))
                {
                    MessageBox.Show("修改工作类型成功");
                }
                else
                {
                    MessageBox.Show("修改工作类型失败");

                }
            }
            else
            {
                if (await Server.InsertWork(Global.LoginInfo.user_id, Global.LoginInfo.user_code, textBox1.Text, Convert.ToBoolean(comboBox1.SelectedIndex), textBox2.Text, comboBox2.SelectedIndex))
                {
                    MessageBox.Show("添加工作类型成功");
                }
                else
                {
                    MessageBox.Show("添加工作类型失败");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        async private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    Debug.WriteLine(openFileDialog1.FileName);
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    if (fs.Length <= 1 * 1024 * 1024)
                    {
                        button3.Enabled = false;
                        button3.Text = "上传中...";
                        string jsonString = await Task.Factory.StartNew(() =>
                        {
                            var t = HttpHelper.GetResponseString(HttpHelper.PostImage("http://" + Global.ServerIp + "/file/picture.api", fs));
                            fs.Close();
                            return t;
                        });
                        button3.Text = "浏览...";
                        JsonEntity.UploadImage UploadImage = JsonHelper.parse<JsonEntity.UploadImage>(jsonString);
                        if (string.IsNullOrWhiteSpace(UploadImage.msg))
                        {
                            if (!string.IsNullOrWhiteSpace(UploadImage.img_url))
                            {
                                textBox2.Text = UploadImage.img_url;
                                pictureBox1.Load(UploadImage.img_url);

                                MessageBox.Show("图片上传完成");
                                return;
                            }
                        }
                        MessageBox.Show("图片上传失败，可能是网络问题，请重试");
                    }
                    else
                    {
                        MessageBox.Show("图片超过1MB，请重新选择。");
                    }

                }
            }

        }
    }
}
