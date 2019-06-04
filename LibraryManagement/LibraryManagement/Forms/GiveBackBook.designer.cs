namespace LibraryManagement.Forms
{
    partial class GiveBackBook
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn2_Refresh = new System.Windows.Forms.Button();
            this.btn1_Search = new System.Windows.Forms.Button();
            this.tb1_Search = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn3_GiveBackAll = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(614, 457);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn2_Refresh);
            this.groupBox1.Controls.Add(this.btn1_Search);
            this.groupBox1.Controls.Add(this.tb1_Search);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 520);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn2_Refresh
            // 
            this.btn2_Refresh.BackColor = System.Drawing.Color.Khaki;
            this.btn2_Refresh.BackgroundImage = global::LibraryManagement.Properties.Resources.restart_png_open_2000;
            this.btn2_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn2_Refresh.Location = new System.Drawing.Point(6, 19);
            this.btn2_Refresh.Name = "btn2_Refresh";
            this.btn2_Refresh.Size = new System.Drawing.Size(141, 32);
            this.btn2_Refresh.TabIndex = 3;
            this.btn2_Refresh.Text = "Làm mới";
            this.btn2_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn2_Refresh.UseVisualStyleBackColor = false;
            this.btn2_Refresh.Click += new System.EventHandler(this.btn2_Refresh_Click);
            // 
            // btn1_Search
            // 
            this.btn1_Search.BackColor = System.Drawing.Color.Khaki;
            this.btn1_Search.BackgroundImage = global::LibraryManagement.Properties.Resources.find_148857_640;
            this.btn1_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn1_Search.Location = new System.Drawing.Point(485, 19);
            this.btn1_Search.Name = "btn1_Search";
            this.btn1_Search.Size = new System.Drawing.Size(135, 32);
            this.btn1_Search.TabIndex = 2;
            this.btn1_Search.Text = "Tìm kiếm";
            this.btn1_Search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn1_Search.UseVisualStyleBackColor = false;
            this.btn1_Search.Click += new System.EventHandler(this.btn1_Search_Click);
            // 
            // tb1_Search
            // 
            this.tb1_Search.Location = new System.Drawing.Point(246, 26);
            this.tb1_Search.Name = "tb1_Search";
            this.tb1_Search.Size = new System.Drawing.Size(213, 20);
            this.tb1_Search.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn3_GiveBackAll);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(675, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 520);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btn3_GiveBackAll
            // 
            this.btn3_GiveBackAll.BackColor = System.Drawing.Color.Khaki;
            this.btn3_GiveBackAll.Location = new System.Drawing.Point(163, 14);
            this.btn3_GiveBackAll.Name = "btn3_GiveBackAll";
            this.btn3_GiveBackAll.Size = new System.Drawing.Size(140, 32);
            this.btn3_GiveBackAll.TabIndex = 4;
            this.btn3_GiveBackAll.Text = "Trả tất cả";
            this.btn3_GiveBackAll.UseVisualStyleBackColor = false;
            this.btn3_GiveBackAll.Click += new System.EventHandler(this.btn3_GiveBackAll_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(17, 57);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(286, 457);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // GiveBackBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(996, 545);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GiveBackBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GiveBackBook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GiveBackBook_FormClosing);
            this.Load += new System.EventHandler(this.GiveBackBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn1_Search;
        private System.Windows.Forms.TextBox tb1_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn2_Refresh;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn3_GiveBackAll;
    }
}