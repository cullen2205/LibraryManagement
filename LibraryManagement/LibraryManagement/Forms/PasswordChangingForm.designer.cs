namespace LibraryManagement.Forms
{
    partial class PasswordChangingForm
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
            if (disposing && (components != null))
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
            this.OldPasswordTextbox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.NewPasswordTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.LoginInforGroupBox = new System.Windows.Forms.GroupBox();
            this.RepeatNewPasswordTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginInforGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OldPasswordTextbox
            // 
            this.OldPasswordTextbox.Location = new System.Drawing.Point(94, 45);
            this.OldPasswordTextbox.Name = "OldPasswordTextbox";
            this.OldPasswordTextbox.PasswordChar = '⏺';
            this.OldPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.OldPasswordTextbox.TabIndex = 2;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(16, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(190, 26);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Thay đổi mật khẩu";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Enabled = false;
            this.UsernameTextbox.Location = new System.Drawing.Point(94, 19);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(100, 20);
            this.UsernameTextbox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(6, 48);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(67, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Mật khẩu cũ";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(6, 22);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(81, 13);
            this.UsernameLabel.TabIndex = 5;
            this.UsernameLabel.Text = "Tên đăng nhập";
            // 
            // NewPasswordTextbox
            // 
            this.NewPasswordTextbox.Location = new System.Drawing.Point(94, 71);
            this.NewPasswordTextbox.Name = "NewPasswordTextbox";
            this.NewPasswordTextbox.PasswordChar = '⏺';
            this.NewPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.NewPasswordTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mật khẩu mới";
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.LightCoral;
            this.CancelButton.Location = new System.Drawing.Point(38, 133);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.BackColor = System.Drawing.Color.LightGreen;
            this.AcceptButton.Location = new System.Drawing.Point(119, 133);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 6;
            this.AcceptButton.Text = "Xác nhận";
            this.AcceptButton.UseVisualStyleBackColor = false;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // LoginInforGroupBox
            // 
            this.LoginInforGroupBox.Controls.Add(this.RepeatNewPasswordTextbox);
            this.LoginInforGroupBox.Controls.Add(this.label2);
            this.LoginInforGroupBox.Controls.Add(this.UsernameLabel);
            this.LoginInforGroupBox.Controls.Add(this.CancelButton);
            this.LoginInforGroupBox.Controls.Add(this.AcceptButton);
            this.LoginInforGroupBox.Controls.Add(this.PasswordLabel);
            this.LoginInforGroupBox.Controls.Add(this.UsernameTextbox);
            this.LoginInforGroupBox.Controls.Add(this.NewPasswordTextbox);
            this.LoginInforGroupBox.Controls.Add(this.OldPasswordTextbox);
            this.LoginInforGroupBox.Controls.Add(this.label1);
            this.LoginInforGroupBox.Location = new System.Drawing.Point(12, 53);
            this.LoginInforGroupBox.Name = "LoginInforGroupBox";
            this.LoginInforGroupBox.Size = new System.Drawing.Size(205, 168);
            this.LoginInforGroupBox.TabIndex = 0;
            this.LoginInforGroupBox.TabStop = false;
            this.LoginInforGroupBox.Text = "Thông tin đăng nhập";
            // 
            // RepeatNewPasswordTextbox
            // 
            this.RepeatNewPasswordTextbox.Location = new System.Drawing.Point(94, 97);
            this.RepeatNewPasswordTextbox.Name = "RepeatNewPasswordTextbox";
            this.RepeatNewPasswordTextbox.PasswordChar = '⏺';
            this.RepeatNewPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.RepeatNewPasswordTextbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nhập lại";
            // 
            // PasswordChangingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(230, 233);
            this.Controls.Add(this.LoginInforGroupBox);
            this.Controls.Add(this.TitleLabel);
            this.Name = "PasswordChangingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordChangingForm_FormClosing);
            this.LoginInforGroupBox.ResumeLayout(false);
            this.LoginInforGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OldPasswordTextbox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox NewPasswordTextbox;
        private System.Windows.Forms.Label label1;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.Button CancelButton;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.Button AcceptButton;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.GroupBox LoginInforGroupBox;
        private System.Windows.Forms.TextBox RepeatNewPasswordTextbox;
        private System.Windows.Forms.Label label2;
    }
}