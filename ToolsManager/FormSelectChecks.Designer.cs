namespace ToolsManager
{
    partial class FormSelectChecks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectChecks));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ll_End = new System.Windows.Forms.LinkLabel();
            this.ll_Next = new System.Windows.Forms.LinkLabel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ll_Last = new System.Windows.Forms.LinkLabel();
            this.ll_First = new System.Windows.Forms.LinkLabel();
            this.lb_cur = new System.Windows.Forms.Label();
            this.lb_sum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择工作任务：";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(741, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "查看定期检查记录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(119, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(660, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "获取工作票列表";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(848, 317);
            this.dataGridView1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ll_End);
            this.flowLayoutPanel1.Controls.Add(this.ll_Next);
            this.flowLayoutPanel1.Controls.Add(this.comboBox2);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.ll_Last);
            this.flowLayoutPanel1.Controls.Add(this.ll_First);
            this.flowLayoutPanel1.Controls.Add(this.lb_cur);
            this.flowLayoutPanel1.Controls.Add(this.lb_sum);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(146, 365);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(508, 24);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // ll_End
            // 
            this.ll_End.AutoSize = true;
            this.ll_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_End.Location = new System.Drawing.Point(474, 0);
            this.ll_End.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_End.Name = "ll_End";
            this.ll_End.Size = new System.Drawing.Size(29, 26);
            this.ll_End.TabIndex = 3;
            this.ll_End.TabStop = true;
            this.ll_End.Text = "末页";
            this.ll_End.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_End.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_End_LinkClicked);
            // 
            // ll_Next
            // 
            this.ll_Next.AutoSize = true;
            this.ll_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ll_Next.Location = new System.Drawing.Point(423, 0);
            this.ll_Next.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_Next.Name = "ll_Next";
            this.ll_Next.Size = new System.Drawing.Size(41, 26);
            this.ll_Next.TabIndex = 0;
            this.ll_Next.TabStop = true;
            this.ll_Next.Text = "下一页";
            this.ll_Next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_Next.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Next_LinkClicked);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(367, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(48, 20);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(332, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "跳至";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ll_Last
            // 
            this.ll_Last.AutoSize = true;
            this.ll_Last.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Last.Location = new System.Drawing.Point(283, 0);
            this.ll_Last.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_Last.Name = "ll_Last";
            this.ll_Last.Size = new System.Drawing.Size(41, 26);
            this.ll_Last.TabIndex = 1;
            this.ll_Last.TabStop = true;
            this.ll_Last.Text = "上一页";
            this.ll_Last.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_Last.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Last_LinkClicked);
            // 
            // ll_First
            // 
            this.ll_First.AutoSize = true;
            this.ll_First.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_First.Location = new System.Drawing.Point(232, 0);
            this.ll_First.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_First.Name = "ll_First";
            this.ll_First.Size = new System.Drawing.Size(41, 26);
            this.ll_First.TabIndex = 2;
            this.ll_First.TabStop = true;
            this.ll_First.Text = "第一页";
            this.ll_First.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_First.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_First_LinkClicked);
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_cur.Location = new System.Drawing.Point(163, 0);
            this.lb_cur.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_cur.Name = "lb_cur";
            this.lb_cur.Size = new System.Drawing.Size(59, 26);
            this.lb_cur.TabIndex = 7;
            this.lb_cur.Text = "当前第0页";
            this.lb_cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_sum
            // 
            this.lb_sum.AutoSize = true;
            this.lb_sum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_sum.Location = new System.Drawing.Point(118, 0);
            this.lb_sum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_sum.Name = "lb_sum";
            this.lb_sum.Size = new System.Drawing.Size(35, 26);
            this.lb_sum.TabIndex = 6;
            this.lb_sum.Text = "共0页";
            this.lb_sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSelectChecks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 400);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectChecks";
            this.Text = "请选择";
            this.Load += new System.EventHandler(this.FormSelectChecks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel ll_End;
        private System.Windows.Forms.LinkLabel ll_Next;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel ll_Last;
        private System.Windows.Forms.LinkLabel ll_First;
        private System.Windows.Forms.Label lb_cur;
        private System.Windows.Forms.Label lb_sum;
    }
}