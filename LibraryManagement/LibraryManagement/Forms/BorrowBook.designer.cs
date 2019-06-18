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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1_ListBook = new System.Windows.Forms.DataGridView();
            this.textBox1_search = new System.Windows.Forms.TextBox();
            this.button6_Find = new System.Windows.Forms.Button();
            this.button5_Refresh = new System.Windows.Forms.Button();
            this.button3_Borrow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2_IDEmployee = new System.Windows.Forms.TextBox();
            this.button4_Exit = new System.Windows.Forms.Button();
            this.dataGridView2_ListBorrow = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_ListBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_ListBorrow)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1_ListBook
            // 
            this.dataGridView1_ListBook.AllowUserToDeleteRows = false;
            this.dataGridView1_ListBook.BackgroundColor = System.Drawing.Color.Wheat;
            this.dataGridView1_ListBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_ListBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1_ListBook.Location = new System.Drawing.Point(0, 105);
            this.dataGridView1_ListBook.Name = "dataGridView1_ListBook";
            this.dataGridView1_ListBook.ReadOnly = true;
            this.dataGridView1_ListBook.Size = new System.Drawing.Size(598, 576);
            this.dataGridView1_ListBook.TabIndex = 0;
            this.dataGridView1_ListBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_ListBook_CellClick);
            this.dataGridView1_ListBook.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_ListBook_MouseMove);
            // 
            // textBox1_search
            // 
            this.textBox1_search.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox1_search.Location = new System.Drawing.Point(214, 38);
            this.textBox1_search.Name = "textBox1_search";
            this.textBox1_search.Size = new System.Drawing.Size(372, 29);
            this.textBox1_search.TabIndex = 8;
            // 
            // button6_Find
            // 
            this.button6_Find.BackColor = System.Drawing.Color.Brown;
            this.button6_Find.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button6_Find.ForeColor = System.Drawing.Color.Wheat;
            this.button6_Find.Location = new System.Drawing.Point(591, 21);
            this.button6_Find.Name = "button6_Find";
            this.button6_Find.Size = new System.Drawing.Size(140, 60);
            this.button6_Find.TabIndex = 7;
            this.button6_Find.Text = "Tìm kiếm";
            this.button6_Find.UseVisualStyleBackColor = false;
            this.button6_Find.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // button5_Refresh
            // 
            this.button5_Refresh.BackColor = System.Drawing.Color.Brown;
            this.button5_Refresh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button5_Refresh.ForeColor = System.Drawing.Color.Wheat;
            this.button5_Refresh.Location = new System.Drawing.Point(22, 21);
            this.button5_Refresh.Name = "button5_Refresh";
            this.button5_Refresh.Size = new System.Drawing.Size(140, 60);
            this.button5_Refresh.TabIndex = 6;
            this.button5_Refresh.Text = "Làm mới";
            this.button5_Refresh.UseVisualStyleBackColor = false;
            this.button5_Refresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button3_Borrow
            // 
            this.button3_Borrow.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button3_Borrow.BackColor = System.Drawing.Color.Wheat;
            this.button3_Borrow.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button3_Borrow.Location = new System.Drawing.Point(59, 70);
            this.button3_Borrow.Name = "button3_Borrow";
            this.button3_Borrow.Size = new System.Drawing.Size(140, 60);
            this.button3_Borrow.TabIndex = 4;
            this.button3_Borrow.Text = "Mượn tất cả";
            this.button3_Borrow.UseVisualStyleBackColor = false;
            this.button3_Borrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Wheat;
            this.label2.Location = new System.Drawing.Point(17, -26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nhập mã nhân viên giao dịch tại đây";
            // 
            // textBox2_IDEmployee
            // 
            this.textBox2_IDEmployee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox2_IDEmployee.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox2_IDEmployee.Location = new System.Drawing.Point(21, 7);
            this.textBox2_IDEmployee.Name = "textBox2_IDEmployee";
            this.textBox2_IDEmployee.Size = new System.Drawing.Size(223, 29);
            this.textBox2_IDEmployee.TabIndex = 7;
            // 
            // button4_Exit
            // 
            this.button4_Exit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button4_Exit.BackColor = System.Drawing.Color.Wheat;
            this.button4_Exit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button4_Exit.Location = new System.Drawing.Point(59, 146);
            this.button4_Exit.Name = "button4_Exit";
            this.button4_Exit.Size = new System.Drawing.Size(140, 60);
            this.button4_Exit.TabIndex = 5;
            this.button4_Exit.Text = "Trở về menu";
            this.button4_Exit.UseVisualStyleBackColor = false;
            this.button4_Exit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGridView2_ListBorrow
            // 
            this.dataGridView2_ListBorrow.AllowUserToDeleteRows = false;
            this.dataGridView2_ListBorrow.BackgroundColor = System.Drawing.Color.Wheat;
            this.dataGridView2_ListBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2_ListBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2_ListBorrow.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2_ListBorrow.Name = "dataGridView2_ListBorrow";
            this.dataGridView2_ListBorrow.ReadOnly = true;
            this.dataGridView2_ListBorrow.Size = new System.Drawing.Size(394, 576);
            this.dataGridView2_ListBorrow.TabIndex = 1;
            this.dataGridView2_ListBorrow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_ListBorrow_CellClick);
            this.dataGridView2_ListBorrow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_ListBorrow_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2_IDEmployee);
            this.panel1.Controls.Add(this.button3_Borrow);
            this.panel1.Controls.Add(this.button4_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1028, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 681);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button6_Find);
            this.panel2.Controls.Add(this.textBox1_search);
            this.panel2.Controls.Add(this.button5_Refresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 105);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.dataGridView2_ListBorrow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(634, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 576);
            this.panel3.TabIndex = 8;
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(598, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(36, 576);
            this.panel4.TabIndex = 9;
            // 
            // BorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources._4_confetti_background_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.dataGridView1_ListBook);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "BorrowBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mượn sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BorrowBook_FormClosing);
            this.Load += new System.EventHandler(this.BorrowBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_ListBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_ListBorrow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_ListBook;
        private System.Windows.Forms.Button button3_Borrow;
        private System.Windows.Forms.DataGridView dataGridView2_ListBorrow;
        private System.Windows.Forms.Button button4_Exit;
        private System.Windows.Forms.TextBox textBox1_search;
        private System.Windows.Forms.Button button6_Find;
        private System.Windows.Forms.Button button5_Refresh;
        private System.Windows.Forms.TextBox textBox2_IDEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel4;
    }
}