namespace LibraryManagement.Forms
{
    partial class ManageBook
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
            this.dataGridView1_Info = new System.Windows.Forms.DataGridView();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamXuatBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaXuatBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiHanTuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuongDanAnhDaiDien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6_Exit = new System.Windows.Forms.Button();
            this.button5_Cancel = new System.Windows.Forms.Button();
            this.button3_Edit = new System.Windows.Forms.Button();
            this.button4_Delete = new System.Windows.Forms.Button();
            this.button2_AddNew = new System.Windows.Forms.Button();
            this.textBox0_Search = new System.Windows.Forms.TextBox();
            this.button1_Refresh = new System.Windows.Forms.Button();
            this.button0_Find = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chooseTypeBook = new System.Windows.Forms.CheckedListBox();
            this.button8_AddNewTypeBook = new System.Windows.Forms.Button();
            this.button7_Save = new System.Windows.Forms.Button();
            this.button1_ChangeAvatar = new System.Windows.Forms.Button();
            this.dataGridView2_DSTheLoai = new System.Windows.Forms.DataGridView();
            this.TenTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1_Avatar = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_Info)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_DSTheLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1_Info
            // 
            this.dataGridView1_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_Info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSach,
            this.TenSach,
            this.TacGia,
            this.NamXuatBan,
            this.Gia,
            this.NhaXuatBan,
            this.GioiHanTuoi,
            this.DuongDanAnhDaiDien});
            this.dataGridView1_Info.Location = new System.Drawing.Point(6, 49);
            this.dataGridView1_Info.Name = "dataGridView1_Info";
            this.dataGridView1_Info.ReadOnly = true;
            this.dataGridView1_Info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1_Info.Size = new System.Drawing.Size(785, 389);
            this.dataGridView1_Info.TabIndex = 0;
            this.dataGridView1_Info.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_Info_RowEnter);
            // 
            // MaSach
            // 
            this.MaSach.DataPropertyName = "MaSach";
            this.MaSach.HeaderText = "Mã sách";
            this.MaSach.Name = "MaSach";
            this.MaSach.ReadOnly = true;
            // 
            // TenSach
            // 
            this.TenSach.DataPropertyName = "TenSach";
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            // 
            // TacGia
            // 
            this.TacGia.DataPropertyName = "TacGia";
            this.TacGia.HeaderText = "Tác giả";
            this.TacGia.Name = "TacGia";
            this.TacGia.ReadOnly = true;
            // 
            // NamXuatBan
            // 
            this.NamXuatBan.DataPropertyName = "NamXuatBan";
            this.NamXuatBan.HeaderText = "Năm xuất bản";
            this.NamXuatBan.Name = "NamXuatBan";
            this.NamXuatBan.ReadOnly = true;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            // 
            // NhaXuatBan
            // 
            this.NhaXuatBan.DataPropertyName = "NhaXuatBan";
            this.NhaXuatBan.HeaderText = "Nhà xuất bản";
            this.NhaXuatBan.Name = "NhaXuatBan";
            this.NhaXuatBan.ReadOnly = true;
            // 
            // GioiHanTuoi
            // 
            this.GioiHanTuoi.DataPropertyName = "GioiHanTuoi";
            this.GioiHanTuoi.HeaderText = "Giới hạn tuổi";
            this.GioiHanTuoi.Name = "GioiHanTuoi";
            this.GioiHanTuoi.ReadOnly = true;
            // 
            // DuongDanAnhDaiDien
            // 
            this.DuongDanAnhDaiDien.DataPropertyName = "DuongDanAnhDaiDien";
            this.DuongDanAnhDaiDien.HeaderText = "Đường dẫn ảnh đại diện";
            this.DuongDanAnhDaiDien.Name = "DuongDanAnhDaiDien";
            this.DuongDanAnhDaiDien.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6_Exit);
            this.groupBox1.Controls.Add(this.button5_Cancel);
            this.groupBox1.Controls.Add(this.button3_Edit);
            this.groupBox1.Controls.Add(this.button4_Delete);
            this.groupBox1.Controls.Add(this.button2_AddNew);
            this.groupBox1.Controls.Add(this.textBox0_Search);
            this.groupBox1.Controls.Add(this.button1_Refresh);
            this.groupBox1.Controls.Add(this.button0_Find);
            this.groupBox1.Controls.Add(this.dataGridView1_Info);
            this.groupBox1.Location = new System.Drawing.Point(341, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 447);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // button6_Exit
            // 
            this.button6_Exit.BackColor = System.Drawing.Color.Khaki;
            this.button6_Exit.Location = new System.Drawing.Point(811, 323);
            this.button6_Exit.Name = "button6_Exit";
            this.button6_Exit.Size = new System.Drawing.Size(64, 53);
            this.button6_Exit.TabIndex = 8;
            this.button6_Exit.Text = "Về menu";
            this.button6_Exit.UseVisualStyleBackColor = false;
            this.button6_Exit.Click += new System.EventHandler(this.button6_Exit_Click);
            // 
            // button5_Cancel
            // 
            this.button5_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.button5_Cancel.Location = new System.Drawing.Point(810, 262);
            this.button5_Cancel.Name = "button5_Cancel";
            this.button5_Cancel.Size = new System.Drawing.Size(64, 53);
            this.button5_Cancel.TabIndex = 7;
            this.button5_Cancel.Text = "Huỷ bỏ";
            this.button5_Cancel.UseVisualStyleBackColor = false;
            this.button5_Cancel.Click += new System.EventHandler(this.button5_Cancel_Click);
            // 
            // button3_Edit
            // 
            this.button3_Edit.BackColor = System.Drawing.Color.Khaki;
            this.button3_Edit.Location = new System.Drawing.Point(810, 144);
            this.button3_Edit.Name = "button3_Edit";
            this.button3_Edit.Size = new System.Drawing.Size(64, 53);
            this.button3_Edit.TabIndex = 6;
            this.button3_Edit.Text = "Sửa";
            this.button3_Edit.UseVisualStyleBackColor = false;
            this.button3_Edit.Click += new System.EventHandler(this.button3_Edit_Click);
            // 
            // button4_Delete
            // 
            this.button4_Delete.BackColor = System.Drawing.Color.Khaki;
            this.button4_Delete.Location = new System.Drawing.Point(810, 203);
            this.button4_Delete.Name = "button4_Delete";
            this.button4_Delete.Size = new System.Drawing.Size(64, 53);
            this.button4_Delete.TabIndex = 5;
            this.button4_Delete.Text = "Xoá";
            this.button4_Delete.UseVisualStyleBackColor = false;
            this.button4_Delete.Click += new System.EventHandler(this.button4_Delete_Click);
            // 
            // button2_AddNew
            // 
            this.button2_AddNew.BackColor = System.Drawing.Color.Khaki;
            this.button2_AddNew.Location = new System.Drawing.Point(811, 85);
            this.button2_AddNew.Name = "button2_AddNew";
            this.button2_AddNew.Size = new System.Drawing.Size(64, 53);
            this.button2_AddNew.TabIndex = 4;
            this.button2_AddNew.Text = "Thêm mới";
            this.button2_AddNew.UseVisualStyleBackColor = false;
            this.button2_AddNew.Click += new System.EventHandler(this.button2_AddNew_Click);
            // 
            // textBox0_Search
            // 
            this.textBox0_Search.Location = new System.Drawing.Point(532, 18);
            this.textBox0_Search.Name = "textBox0_Search";
            this.textBox0_Search.Size = new System.Drawing.Size(259, 20);
            this.textBox0_Search.TabIndex = 3;
            // 
            // button1_Refresh
            // 
            this.button1_Refresh.BackColor = System.Drawing.Color.Khaki;
            this.button1_Refresh.Location = new System.Drawing.Point(6, 11);
            this.button1_Refresh.Name = "button1_Refresh";
            this.button1_Refresh.Size = new System.Drawing.Size(107, 32);
            this.button1_Refresh.TabIndex = 2;
            this.button1_Refresh.Text = "Làm mới";
            this.button1_Refresh.UseVisualStyleBackColor = false;
            this.button1_Refresh.Click += new System.EventHandler(this.button1_Refresh_Click);
            // 
            // button0_Find
            // 
            this.button0_Find.BackColor = System.Drawing.Color.Khaki;
            this.button0_Find.Location = new System.Drawing.Point(810, 11);
            this.button0_Find.Name = "button0_Find";
            this.button0_Find.Size = new System.Drawing.Size(65, 32);
            this.button0_Find.TabIndex = 1;
            this.button0_Find.Text = "Tìm kiếm";
            this.button0_Find.UseVisualStyleBackColor = false;
            this.button0_Find.Click += new System.EventHandler(this.button0_Find_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chooseTypeBook);
            this.groupBox2.Controls.Add(this.button8_AddNewTypeBook);
            this.groupBox2.Controls.Add(this.button7_Save);
            this.groupBox2.Controls.Add(this.button1_ChangeAvatar);
            this.groupBox2.Controls.Add(this.dataGridView2_DSTheLoai);
            this.groupBox2.Controls.Add(this.pictureBox1_Avatar);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 447);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // chooseTypeBook
            // 
            this.chooseTypeBook.FormattingEnabled = true;
            this.chooseTypeBook.Location = new System.Drawing.Point(176, 208);
            this.chooseTypeBook.Name = "chooseTypeBook";
            this.chooseTypeBook.Size = new System.Drawing.Size(118, 109);
            this.chooseTypeBook.TabIndex = 11;
            // 
            // button8_AddNewTypeBook
            // 
            this.button8_AddNewTypeBook.Location = new System.Drawing.Point(176, 189);
            this.button8_AddNewTypeBook.Name = "button8_AddNewTypeBook";
            this.button8_AddNewTypeBook.Size = new System.Drawing.Size(118, 25);
            this.button8_AddNewTypeBook.TabIndex = 18;
            this.button8_AddNewTypeBook.Text = "Thêm thể loại";
            this.button8_AddNewTypeBook.UseVisualStyleBackColor = true;
            this.button8_AddNewTypeBook.Click += new System.EventHandler(this.button8_AddNewTypeBook_Click);
            // 
            // button7_Save
            // 
            this.button7_Save.BackColor = System.Drawing.Color.Salmon;
            this.button7_Save.Location = new System.Drawing.Point(176, 159);
            this.button7_Save.Name = "button7_Save";
            this.button7_Save.Size = new System.Drawing.Size(118, 25);
            this.button7_Save.TabIndex = 9;
            this.button7_Save.Text = "Lưu thông tin";
            this.button7_Save.UseVisualStyleBackColor = false;
            this.button7_Save.Click += new System.EventHandler(this.button7_Save_Click);
            // 
            // button1_ChangeAvatar
            // 
            this.button1_ChangeAvatar.BackColor = System.Drawing.Color.Khaki;
            this.button1_ChangeAvatar.Location = new System.Drawing.Point(15, 188);
            this.button1_ChangeAvatar.Name = "button1_ChangeAvatar";
            this.button1_ChangeAvatar.Size = new System.Drawing.Size(129, 26);
            this.button1_ChangeAvatar.TabIndex = 9;
            this.button1_ChangeAvatar.Text = "Thay đổi ảnh";
            this.button1_ChangeAvatar.UseVisualStyleBackColor = false;
            this.button1_ChangeAvatar.Click += new System.EventHandler(this.button1_ChangeAvatar_Click);
            // 
            // dataGridView2_DSTheLoai
            // 
            this.dataGridView2_DSTheLoai.AllowUserToAddRows = false;
            this.dataGridView2_DSTheLoai.AllowUserToDeleteRows = false;
            this.dataGridView2_DSTheLoai.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2_DSTheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2_DSTheLoai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenTheLoai});
            this.dataGridView2_DSTheLoai.Location = new System.Drawing.Point(176, 21);
            this.dataGridView2_DSTheLoai.Name = "dataGridView2_DSTheLoai";
            this.dataGridView2_DSTheLoai.Size = new System.Drawing.Size(118, 128);
            this.dataGridView2_DSTheLoai.TabIndex = 17;
            // 
            // TenTheLoai
            // 
            this.TenTheLoai.DataPropertyName = "TenTheLoai";
            this.TenTheLoai.HeaderText = "Thể loại";
            this.TenTheLoai.Name = "TenTheLoai";
            this.TenTheLoai.Width = 120;
            // 
            // pictureBox1_Avatar
            // 
            this.pictureBox1_Avatar.Location = new System.Drawing.Point(15, 19);
            this.pictureBox1_Avatar.Name = "pictureBox1_Avatar";
            this.pictureBox1_Avatar.Size = new System.Drawing.Size(129, 165);
            this.pictureBox1_Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1_Avatar.TabIndex = 16;
            this.pictureBox1_Avatar.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tình trạng";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(108, 418);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(186, 20);
            this.textBox8.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giới hạn tuổi";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(108, 392);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(186, 20);
            this.textBox7.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nhà xuất bản";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(108, 366);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(186, 20);
            this.textBox6.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Giá";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(108, 340);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(186, 20);
            this.textBox5.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Năm xuất bản";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(108, 314);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(186, 20);
            this.textBox4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên tác giả";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 288);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(186, 20);
            this.textBox3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên sách";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 262);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sách";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 220);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 0;
            // 
            // ManageBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1244, 466);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ManageBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageBook_FormClosing);
            this.Load += new System.EventHandler(this.ManageBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_Info)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_DSTheLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_Avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_Info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox0_Search;
        private System.Windows.Forms.Button button1_Refresh;
        private System.Windows.Forms.Button button0_Find;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2_DSTheLoai;
        private System.Windows.Forms.PictureBox pictureBox1_Avatar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3_Edit;
        private System.Windows.Forms.Button button4_Delete;
        private System.Windows.Forms.Button button2_AddNew;
        private System.Windows.Forms.Button button5_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamXuatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaXuatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiHanTuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuongDanAnhDaiDien;
        private System.Windows.Forms.Button button6_Exit;
        private System.Windows.Forms.Button button1_ChangeAvatar;
        private System.Windows.Forms.Button button7_Save;
        private System.Windows.Forms.Button button8_AddNewTypeBook;
        private System.Windows.Forms.CheckedListBox chooseTypeBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTheLoai;
    }
}