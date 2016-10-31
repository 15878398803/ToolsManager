namespace ToolsManager
{
    partial class FormLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lb_passwd;
            System.Windows.Forms.Label lb_user;
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tx_username = new System.Windows.Forms.TextBox();
            this.tx_password = new System.Windows.Forms.TextBox();
            lb_passwd = new System.Windows.Forms.Label();
            lb_user = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_passwd
            // 
            lb_passwd.AutoSize = true;
            lb_passwd.Dock = System.Windows.Forms.DockStyle.Fill;
            lb_passwd.Font = new System.Drawing.Font("新宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lb_passwd.Location = new System.Drawing.Point(63, 147);
            lb_passwd.Name = "lb_passwd";
            lb_passwd.Size = new System.Drawing.Size(82, 32);
            lb_passwd.TabIndex = 1;
            lb_passwd.Text = "密码：";
            lb_passwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_user
            // 
            lb_user.AutoSize = true;
            lb_user.Dock = System.Windows.Forms.DockStyle.Fill;
            lb_user.Font = new System.Drawing.Font("新宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lb_user.Location = new System.Drawing.Point(63, 115);
            lb_user.Name = "lb_user";
            lb_user.Size = new System.Drawing.Size(82, 32);
            lb_user.TabIndex = 0;
            lb_user.Text = "账号：";
            lb_user.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_login.Location = new System.Drawing.Point(71, 229);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(65, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "登录系统";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_exit.Location = new System.Drawing.Point(188, 229);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(61, 23);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "退出系统";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tx_username, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_login, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_exit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(lb_passwd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(lb_user, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tx_password, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(351, 294);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tx_username
            // 
            this.tx_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_username.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tx_username.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tx_username.Location = new System.Drawing.Point(151, 118);
            this.tx_username.MaxLength = 100;
            this.tx_username.Name = "tx_username";
            this.tx_username.Size = new System.Drawing.Size(136, 26);
            this.tx_username.TabIndex = 0;
            // 
            // tx_password
            // 
            this.tx_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_password.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tx_password.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tx_password.Location = new System.Drawing.Point(151, 150);
            this.tx_password.MaxLength = 100;
            this.tx_password.Name = "tx_password";
            this.tx_password.PasswordChar = '●';
            this.tx_password.Size = new System.Drawing.Size(136, 26);
            this.tx_password.TabIndex = 1;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(351, 294);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录 —— 工器具管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tx_username;
        private System.Windows.Forms.TextBox tx_password;
    }
}

