namespace LibraryManagement.Forms
{
    partial class BorrowBook
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
            this.dataGridView1_ListBook = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1_search = new System.Windows.Forms.TextBox();
            this.button6_Find = new System.Windows.Forms.Button();
            this.button5_Refresh = new System.Windows.Forms.Button();
            this.button3_Borrow = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2_IDEmployee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4_Exit = new System.Windows.Forms.Button();
            this.dataGridView2_ListBorrow = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_ListBook)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_ListBorrow)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1_ListBook
            // 
            this.dataGridView1_ListBook.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView1_ListBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_ListBook.Location = new System.Drawing.Point(6, 62);
            this.dataGridView1_ListBook.Name = "dataGridView1_ListBook";
            this.dataGridView1_ListBook.Size = new System.Drawing.Size(669, 507);
            this.dataGridView1_ListBook.TabIndex = 0;
            this.dataGridView1_ListBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_ListBook_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1_search);
            this.groupBox1.Controls.Add(this.button6_Find);
            this.groupBox1.Controls.Add(this.button5_Refresh);
            this.groupBox1.Controls.Add(this.dataGridView1_ListBook);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 575);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sách hiện có trong thư viện";
            // 
            // textBox1_search
            // 
            this.textBox1_search.Location = new System.Drawing.Point(336, 28);
            this.textBox1_search.Name = "textBox1_search";
            this.textBox1_search.Size = new System.Drawing.Size(223, 20);
            this.textBox1_search.TabIndex = 8;
            // 
            // button6_Find
            // 
            this.button6_Find.BackColor = System.Drawing.Color.LemonChiffon;
            this.button6_Find.Location = new System.Drawing.Point(565, 19);
            this.button6_Find.Name = "button6_Find";
            this.button6_Find.Size = new System.Drawing.Size(110, 35);
            this.button6_Find.TabIndex = 7;
            this.button6_Find.Text = "Tìm kiếm";
            this.button6_Find.UseVisualStyleBackColor = false;
            this.button6_Find.Click += new System.EventHandler(this.button6_Find_Click);
            // 
            // button5_Refresh
            // 
            this.button5_Refresh.BackColor = System.Drawing.Color.LemonChiffon;
            this.button5_Refresh.Location = new System.Drawing.Point(202, 19);
            this.button5_Refresh.Name = "button5_Refresh";
            this.button5_Refresh.Size = new System.Drawing.Size(110, 35);
            this.button5_Refresh.TabIndex = 6;
            this.button5_Refresh.Text = "Làm mới";
            this.button5_Refresh.UseVisualStyleBackColor = false;
            this.button5_Refresh.Click += new System.EventHandler(this.button5_Refresh_Click);
            // 
            // button3_Borrow
            // 
            this.button3_Borrow.BackColor = System.Drawing.Color.LemonChiffon;
            this.button3_Borrow.Location = new System.Drawing.Point(6, 60);
            this.button3_Borrow.Name = "button3_Borrow";
            this.button3_Borrow.Size = new System.Drawing.Size(248, 60);
            this.button3_Borrow.TabIndex = 4;
            this.button3_Borrow.Text = "Mượn tất cả";
            this.button3_Borrow.UseVisualStyleBackColor = false;
            this.button3_Borrow.Click += new System.EventHandler(this.button3_Borrow_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2_IDEmployee);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button4_Exit);
            this.groupBox2.Controls.Add(this.dataGridView2_ListBorrow);
            this.groupBox2.Controls.Add(this.button3_Borrow);
            this.groupBox2.Location = new System.Drawing.Point(699, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 575);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(100, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã nhân viên giao dịch";
            // 
            // textBox2_IDEmployee
            // 
            this.textBox2_IDEmployee.Location = new System.Drawing.Point(103, 34);
            this.textBox2_IDEmployee.Name = "textBox2_IDEmployee";
            this.textBox2_IDEmployee.Size = new System.Drawing.Size(151, 20);
            this.textBox2_IDEmployee.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh sách mượn";
            // 
            // button4_Exit
            // 
            this.button4_Exit.BackColor = System.Drawing.Color.LemonChiffon;
            this.button4_Exit.Location = new System.Drawing.Point(6, 126);
            this.button4_Exit.Name = "button4_Exit";
            this.button4_Exit.Size = new System.Drawing.Size(248, 65);
            this.button4_Exit.TabIndex = 5;
            this.button4_Exit.Text = "Thoát";
            this.button4_Exit.UseVisualStyleBackColor = false;
            this.button4_Exit.Click += new System.EventHandler(this.button4_Exit_Click);
            // 
            // dataGridView2_ListBorrow
            // 
            this.dataGridView2_ListBorrow.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView2_ListBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2_ListBorrow.Location = new System.Drawing.Point(6, 222);
            this.dataGridView2_ListBorrow.Name = "dataGridView2_ListBorrow";
            this.dataGridView2_ListBorrow.Size = new System.Drawing.Size(248, 347);
            this.dataGridView2_ListBorrow.TabIndex = 1;
            this.dataGridView2_ListBorrow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_ListBorrow_CellClick);
            // 
            // BorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(971, 599);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BorrowBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mượn sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BorrowBook_FormClosing);
            this.Load += new System.EventHandler(this.BorrowBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_ListBook)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_ListBorrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_ListBook;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3_Borrow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2_ListBorrow;
        private System.Windows.Forms.Button button4_Exit;
        private System.Windows.Forms.TextBox textBox1_search;
        private System.Windows.Forms.Button button6_Find;
        private System.Windows.Forms.Button button5_Refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2_IDEmployee;
        private System.Windows.Forms.Label label2;
    }
}