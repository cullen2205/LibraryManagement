namespace LibraryManagement.Forms
{
    partial class MainFormLibrary
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
            this.buttonChangeInfo = new System.Windows.Forms.Button();
            this.buttonBorrowBook = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.groupBtnNguoiDung = new System.Windows.Forms.GroupBox();
            this.buttonEmployeeManage = new System.Windows.Forms.Button();
            this.buttonGiveBackBook = new System.Windows.Forms.Button();
            this.buttonUserManage = new System.Windows.Forms.Button();
            this.buttonBookManage = new System.Windows.Forms.Button();
            this.groupBoxGui = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.buttonChangeAvatar = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdateInfo = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.groupBtnNguoiDung.SuspendLayout();
            this.groupBoxGui.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonChangeInfo
            // 
            this.buttonChangeInfo.BackColor = System.Drawing.Color.Khaki;
            this.buttonChangeInfo.Location = new System.Drawing.Point(37, 58);
            this.buttonChangeInfo.Name = "buttonChangeInfo";
            this.buttonChangeInfo.Size = new System.Drawing.Size(141, 40);
            this.buttonChangeInfo.TabIndex = 0;
            this.buttonChangeInfo.Text = "Thay đổi thông tin";
            this.buttonChangeInfo.UseVisualStyleBackColor = false;
            this.buttonChangeInfo.Click += new System.EventHandler(this.buttonChangeInfo_Click);
            // 
            // buttonBorrowBook
            // 
            this.buttonBorrowBook.BackColor = System.Drawing.Color.Khaki;
            this.buttonBorrowBook.Location = new System.Drawing.Point(37, 99);
            this.buttonBorrowBook.Name = "buttonBorrowBook";
            this.buttonBorrowBook.Size = new System.Drawing.Size(141, 41);
            this.buttonBorrowBook.TabIndex = 1;
            this.buttonBorrowBook.Text = "Mượn sách";
            this.buttonBorrowBook.UseVisualStyleBackColor = false;
            this.buttonBorrowBook.Click += new System.EventHandler(this.buttonBorrowBook_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Khaki;
            this.buttonLogout.Location = new System.Drawing.Point(37, 19);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(141, 39);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Đăng xuất";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // groupBtnNguoiDung
            // 
            this.groupBtnNguoiDung.Controls.Add(this.buttonEmployeeManage);
            this.groupBtnNguoiDung.Controls.Add(this.buttonGiveBackBook);
            this.groupBtnNguoiDung.Controls.Add(this.buttonUserManage);
            this.groupBtnNguoiDung.Controls.Add(this.buttonBorrowBook);
            this.groupBtnNguoiDung.Controls.Add(this.buttonLogout);
            this.groupBtnNguoiDung.Controls.Add(this.buttonBookManage);
            this.groupBtnNguoiDung.Controls.Add(this.buttonChangeInfo);
            this.groupBtnNguoiDung.Location = new System.Drawing.Point(496, 12);
            this.groupBtnNguoiDung.Name = "groupBtnNguoiDung";
            this.groupBtnNguoiDung.Size = new System.Drawing.Size(211, 324);
            this.groupBtnNguoiDung.TabIndex = 3;
            this.groupBtnNguoiDung.TabStop = false;
            // 
            // buttonEmployeeManage
            // 
            this.buttonEmployeeManage.BackColor = System.Drawing.Color.Khaki;
            this.buttonEmployeeManage.Location = new System.Drawing.Point(37, 217);
            this.buttonEmployeeManage.Name = "buttonEmployeeManage";
            this.buttonEmployeeManage.Size = new System.Drawing.Size(141, 39);
            this.buttonEmployeeManage.TabIndex = 6;
            this.buttonEmployeeManage.Text = "Quản lý nhân viên";
            this.buttonEmployeeManage.UseVisualStyleBackColor = false;
            this.buttonEmployeeManage.Click += new System.EventHandler(this.buttonManageEmployee_Click);
            // 
            // buttonGiveBackBook
            // 
            this.buttonGiveBackBook.BackColor = System.Drawing.Color.Khaki;
            this.buttonGiveBackBook.Location = new System.Drawing.Point(37, 256);
            this.buttonGiveBackBook.Name = "buttonGiveBackBook";
            this.buttonGiveBackBook.Size = new System.Drawing.Size(141, 39);
            this.buttonGiveBackBook.TabIndex = 5;
            this.buttonGiveBackBook.Text = "Trả sách";
            this.buttonGiveBackBook.UseVisualStyleBackColor = false;
            this.buttonGiveBackBook.Click += new System.EventHandler(this.buttonGiveBackBook_Click);
            // 
            // buttonUserManage
            // 
            this.buttonUserManage.BackColor = System.Drawing.Color.Khaki;
            this.buttonUserManage.Location = new System.Drawing.Point(37, 178);
            this.buttonUserManage.Name = "buttonUserManage";
            this.buttonUserManage.Size = new System.Drawing.Size(141, 39);
            this.buttonUserManage.TabIndex = 4;
            this.buttonUserManage.Text = "Quản lý người dùng";
            this.buttonUserManage.UseVisualStyleBackColor = false;
            this.buttonUserManage.Click += new System.EventHandler(this.buttonUserManage_Click);
            // 
            // buttonBookManage
            // 
            this.buttonBookManage.BackColor = System.Drawing.Color.Khaki;
            this.buttonBookManage.Location = new System.Drawing.Point(37, 140);
            this.buttonBookManage.Name = "buttonBookManage";
            this.buttonBookManage.Size = new System.Drawing.Size(141, 39);
            this.buttonBookManage.TabIndex = 3;
            this.buttonBookManage.Text = "Quản lý sách";
            this.buttonBookManage.UseVisualStyleBackColor = false;
            this.buttonBookManage.Click += new System.EventHandler(this.buttonBookManage_Click);
            // 
            // groupBoxGui
            // 
            this.groupBoxGui.Controls.Add(this.dateTimePicker1);
            this.groupBoxGui.Controls.Add(this.textBox9);
            this.groupBoxGui.Controls.Add(this.label10);
            this.groupBoxGui.Controls.Add(this.textBox8);
            this.groupBoxGui.Controls.Add(this.label9);
            this.groupBoxGui.Controls.Add(this.textBox7);
            this.groupBoxGui.Controls.Add(this.label8);
            this.groupBoxGui.Controls.Add(this.buttonChangePassword);
            this.groupBoxGui.Controls.Add(this.buttonChangeAvatar);
            this.groupBoxGui.Controls.Add(this.buttonCancel);
            this.groupBoxGui.Controls.Add(this.buttonUpdateInfo);
            this.groupBoxGui.Controls.Add(this.radioButton2);
            this.groupBoxGui.Controls.Add(this.radioButton1);
            this.groupBoxGui.Controls.Add(this.label7);
            this.groupBoxGui.Controls.Add(this.textBox6);
            this.groupBoxGui.Controls.Add(this.label6);
            this.groupBoxGui.Controls.Add(this.textBox5);
            this.groupBoxGui.Controls.Add(this.label5);
            this.groupBoxGui.Controls.Add(this.textBox4);
            this.groupBoxGui.Controls.Add(this.label4);
            this.groupBoxGui.Controls.Add(this.textBox3);
            this.groupBoxGui.Controls.Add(this.label3);
            this.groupBoxGui.Controls.Add(this.textBox2);
            this.groupBoxGui.Controls.Add(this.label2);
            this.groupBoxGui.Controls.Add(this.textBox1);
            this.groupBoxGui.Controls.Add(this.label1);
            this.groupBoxGui.Controls.Add(this.pictureAvatar);
            this.groupBoxGui.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGui.Name = "groupBoxGui";
            this.groupBoxGui.Size = new System.Drawing.Size(478, 324);
            this.groupBoxGui.TabIndex = 4;
            this.groupBoxGui.TabStop = false;
            this.groupBoxGui.Text = "Menu";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(444, 97);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(24, 20);
            this.dateTimePicker1.TabIndex = 26;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(237, 256);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(231, 20);
            this.textBox9.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Đ/c người bảo hộ";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(237, 230);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(231, 20);
            this.textBox8.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "SDT người bảo hộ";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(237, 204);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(231, 20);
            this.textBox7.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Tên người bảo hộ";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.BackColor = System.Drawing.Color.Khaki;
            this.buttonChangePassword.Location = new System.Drawing.Point(342, 176);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(126, 23);
            this.buttonChangePassword.TabIndex = 19;
            this.buttonChangePassword.Text = "Đổi mật khẩu";
            this.buttonChangePassword.UseVisualStyleBackColor = false;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // buttonChangeAvatar
            // 
            this.buttonChangeAvatar.BackColor = System.Drawing.Color.Khaki;
            this.buttonChangeAvatar.Location = new System.Drawing.Point(6, 193);
            this.buttonChangeAvatar.Name = "buttonChangeAvatar";
            this.buttonChangeAvatar.Size = new System.Drawing.Size(126, 23);
            this.buttonChangeAvatar.TabIndex = 18;
            this.buttonChangeAvatar.Text = "Đổi ảnh đại diện";
            this.buttonChangeAvatar.UseVisualStyleBackColor = false;
            this.buttonChangeAvatar.Click += new System.EventHandler(this.buttonChangeAvatar_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.LightCoral;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonCancel.Location = new System.Drawing.Point(312, 282);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 35);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Huỷ bỏ";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdateInfo
            // 
            this.buttonUpdateInfo.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonUpdateInfo.Location = new System.Drawing.Point(393, 282);
            this.buttonUpdateInfo.Name = "buttonUpdateInfo";
            this.buttonUpdateInfo.Size = new System.Drawing.Size(75, 35);
            this.buttonUpdateInfo.TabIndex = 16;
            this.buttonUpdateInfo.Text = "Cập nhật";
            this.buttonUpdateInfo.UseVisualStyleBackColor = false;
            this.buttonUpdateInfo.Click += new System.EventHandler(this.buttonUpdateInfo_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(290, 178);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Nữ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(237, 178);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Nam";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giới tính";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(237, 149);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(231, 20);
            this.textBox6.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Địa chỉ";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(237, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(231, 20);
            this.textBox5.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số điện thoại";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(237, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(201, 20);
            this.textBox4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày sinh";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(237, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(231, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Họ tên";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(237, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(231, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số CMND";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(237, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(231, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập";
            // 
            // pictureAvatar
            // 
            this.pictureAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureAvatar.Location = new System.Drawing.Point(6, 19);
            this.pictureAvatar.Name = "pictureAvatar";
            this.pictureAvatar.Size = new System.Drawing.Size(126, 168);
            this.pictureAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAvatar.TabIndex = 0;
            this.pictureAvatar.TabStop = false;
            // 
            // MainFormLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(719, 348);
            this.Controls.Add(this.groupBoxGui);
            this.Controls.Add(this.groupBtnNguoiDung);
            this.Name = "MainFormLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện - Chào mừng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormLibrary_FormClosed);
            this.groupBtnNguoiDung.ResumeLayout(false);
            this.groupBoxGui.ResumeLayout(false);
            this.groupBoxGui.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeInfo;
        private System.Windows.Forms.Button buttonBorrowBook;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.GroupBox groupBtnNguoiDung;
        private System.Windows.Forms.Button buttonGiveBackBook;
        private System.Windows.Forms.Button buttonUserManage;
        private System.Windows.Forms.Button buttonBookManage;
        private System.Windows.Forms.GroupBox groupBoxGui;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureAvatar;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Button buttonChangeAvatar;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdateInfo;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonEmployeeManage;
    }
}