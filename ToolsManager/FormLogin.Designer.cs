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
            System.Windows.Forms.Label lb_user;
            System.Windows.Forms.Label lb_passwd;
            this.tx_username = new System.Windows.Forms.TextBox();
            this.tx_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            lb_user = new System.Windows.Forms.Label();
            lb_passwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_user
            // 
            lb_user.AutoSize = true;
            lb_user.Location = new System.Drawing.Point(43, 39);
            lb_user.Name = "lb_user";
            lb_user.Size = new System.Drawing.Size(41, 12);
            lb_user.TabIndex = 0;
            lb_user.Text = "账号：";
            // 
            // lb_passwd
            // 
            lb_passwd.AutoSize = true;
            lb_passwd.Location = new System.Drawing.Point(45, 80);
            lb_passwd.Name = "lb_passwd";
            lb_passwd.Size = new System.Drawing.Size(41, 12);
            lb_passwd.TabIndex = 1;
            lb_passwd.Text = "密码：";
            // 
            // tx_username
            // 
            this.tx_username.Location = new System.Drawing.Point(81, 33);
            this.tx_username.MaxLength = 100;
            this.tx_username.Name = "tx_username";
            this.tx_username.Size = new System.Drawing.Size(100, 21);
            this.tx_username.TabIndex = 2;
            // 
            // tx_password
            // 
            this.tx_password.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tx_password.Location = new System.Drawing.Point(81, 77);
            this.tx_password.MaxLength = 100;
            this.tx_password.Name = "tx_password";
            this.tx_password.PasswordChar = '●';
            this.tx_password.Size = new System.Drawing.Size(100, 21);
            this.tx_password.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(12, 132);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "登录系统";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(133, 132);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "退出系统";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 185);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tx_password);
            this.Controls.Add(this.tx_username);
            this.Controls.Add(lb_passwd);
            this.Controls.Add(lb_user);
            this.Name = "FormLogin";
            this.Text = "登录 —— 工器具管理系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_username;
        private System.Windows.Forms.TextBox tx_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_exit;
    }
}

