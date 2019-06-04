using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class ManageBook : Form
    {
        //private List<Label> lLabel = new List<Label>();
        private List<TextBox> lTextBox = new List<TextBox>();
        private List<string> lTenTheLoai;
        private List<string> lMaTheLoai;
        //private List<Button> lButton = new List<Button>();
        string _pathAvatar;


        public ManageBook()
        {
            InitializeComponent();

            // cài đặt mặc định cho form
            this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = new Size(1260, 505);
            this.textBox1.Enabled = false;
            this.textBox8.Enabled = false;
            this.dataGridView2_DSTheLoai.ReadOnly = true;

            button8_AddNewTypeBook.Hide();
        }

        private void ManageBook_Load(object sender, EventArgs e)
        {
            //this.richTextBox1.Hide();

            // quản lý label bằng list
            //lLabel.Add(this.label1);
            //lLabel.Add(this.label2);
            //lLabel.Add(this.label3);
            //lLabel.Add(this.label4);
            //lLabel.Add(this.label5);
            //lLabel.Add(this.label6);
            //lLabel.Add(this.label7);
            //lLabel.Add(this.label8);

            // quản lý textbox bằng list
            //lTextBox.Add(this.textBox0_Search);
            //lTextBox.Add(this.textBox1);

            lTextBox.Add(this.textBox2);
            lTextBox.Add(this.textBox3);
            lTextBox.Add(this.textBox4);
            lTextBox.Add(this.textBox5);
            lTextBox.Add(this.textBox6);
            lTextBox.Add(this.textBox7);

            // quản lý button bằng list
            // lButton.Add(this.button0_Find);
            // lButton.Add(this.button1_Refresh);
            //lButton.Add(this.button2_AddNew);
            //lButton.Add(this.button3_Edit);
            //lButton.Add(this.button4_Delete);
            //lButton.Add(this.button5_Cancel);

            // đổ dữ liệu vào datagridview
            SQL.ListData.Fill.AllToDataGridView("Sach", ref this.dataGridView1_Info);

            // thêm thể loại vào biến chooseTypeBook
            lTenTheLoai = SQL.ListData.GetDataFromSQL.Sach_SelectOneTableString("select * from TheLoai", "TenTheLoai");
            lMaTheLoai = SQL.ListData.GetDataFromSQL.Sach_SelectOneTableString("select * from TheLoai", "MaTheLoai");
            for (int i = 0; i < lTenTheLoai.Count; i++)
            {
                chooseTypeBook.Items.Add(lTenTheLoai[i]);
            }
            // mặc định khi chưa chuyển trạng thái editmode
            EditMode(false);
            SetStatus_TextBox(ref lTextBox, false);

            LoadInfoToForm();

            // chỉnh mấy cái thuộc tính vớ vẩn
            chooseTypeBook.Hide();
        }

        private void EmptyInfo()
        {
            dataGridView2_DSTheLoai.DataSource = null;
            dataGridView2_DSTheLoai.Refresh();

            textBox1.Text = "";
            for (int i = 0; i < lTextBox.Count; i++)
            {
                lTextBox[i].Text = "";
            }
        }

        private void LoadInfoToForm()
        {
            try
            {
                this.textBox1.Text = this.dataGridView1_Info.SelectedRows[0].Cells["MaSach"].Value.ToString();
                this.textBox2.Text = this.dataGridView1_Info.SelectedRows[0].Cells["TenSach"].Value.ToString();
                this.textBox3.Text = this.dataGridView1_Info.SelectedRows[0].Cells["TacGia"].Value.ToString();
                this.textBox4.Text = this.dataGridView1_Info.SelectedRows[0].Cells["NamXuatBan"].Value.ToString();
                this.textBox5.Text = this.dataGridView1_Info.SelectedRows[0].Cells["Gia"].Value.ToString();
                this.textBox6.Text = this.dataGridView1_Info.SelectedRows[0].Cells["NhaXuatBan"].Value.ToString();
                this.textBox7.Text = this.dataGridView1_Info.SelectedRows[0].Cells["GioiHanTuoi"].Value.ToString();

                object tam = SQL.ListData.GetDataFromSQL.Query_All
                    (@"select top 1 TinhTrang from MuonSach where MaSach = N'"
                        + this.textBox1.Text + "' order by TinhTrang desc");
                if (tam != null)
                {
                    this.textBox8.Text = tam.ToString();
                }
                else
                {
                    this.textBox8.Text = "False";
                }

                LoadAvatar_Sach(this.textBox1.Text);
            }
            catch
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
                LoadAvatar_Sach(this.textBox1.Text);

            }
        }

        private void LoadAvatar_Sach(string _MaSach)
        {
            // Hiện avatar
            try
            {
                string path = (string)SQL.ListData.GetDataFromSQL.Query_All(
                @"select top 1 DuongDanAnhDaiDien from Sach where MaSach = N'" + _MaSach + "'");

                this.pictureBox1_Avatar.Image = Image.FromFile(path);
            }
            catch
            {
                this.pictureBox1_Avatar.Image = Properties.Resources.NoAvartar;
            }
        }

        private SQL.Struct.Sach TextboxTo_Sach()
        {
            SQL.Struct.Sach t = new SQL.Struct.Sach();
            t.MaSach = textBox1.Text;
            t.TenSach = textBox2.Text;
            t.TacGia = textBox3.Text;
            t.NamXuatBan = string.IsNullOrWhiteSpace(textBox4.Text) ? 0 : int.Parse(textBox4.Text);
            t.Gia = string.IsNullOrWhiteSpace(textBox5.Text) ? 0 : int.Parse(textBox5.Text);
            t.NhaXuatBan = textBox6.Text;
            t.GioiHanTuoi = string.IsNullOrWhiteSpace(textBox7.Text) ? 0 : int.Parse(textBox7.Text);
            return t;
        }

        private void EditMode(bool IsHide = false)
        {
            this.button4_Delete.Enabled = IsHide;
            this.button5_Cancel.Enabled = IsHide;
            this.button1_ChangeAvatar.Enabled = IsHide;
            this.button7_Save.Enabled = IsHide;
        }

        private void SetStatus_TextBox(ref List<TextBox> t, bool IsHide = false)
        {
            for (int i = 0; i < t.Count; i++)
            {
                t[i].Enabled = IsHide;
            }
        }

        private void ManageBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }

        private void button1_ChangeAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog t = new OpenFileDialog();
            if (t.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show(t.FileName);
                Image ima = Image.FromFile(t.FileName);
                this.pictureBox1_Avatar.Image = ima;
                _pathAvatar = t.FileName;
            }
        }

        private void button7_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SQL.Struct.Sach s = new SQL.Struct.Sach();
                s.MaSach = this.textBox1.Text;
                s.TenSach = this.textBox2.Text;
                s.TacGia = this.textBox3.Text;
                s.NamXuatBan = int.Parse(this.textBox4.Text);
                s.Gia = int.Parse(this.textBox5.Text);
                s.NhaXuatBan = this.textBox6.Text;
                s.GioiHanTuoi = int.Parse(this.textBox7.Text);
                s.DuongDanAnhDaiDien = _pathAvatar;

                if (SQL.ListData.GetDataFromSQL.Update_ARecord_Sach(s))
                {
                    MessageBox.Show("Lưu thành công!");
                    this.button1_Refresh_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Không thể lưu vì một hoặc nhiều mục đang để trống");
            }
            
        }

        List<string> test = new List<string>();

        private bool _clickEdit = false;
        private void button3_Edit_Click(object sender, EventArgs e)
        {
            if (!_clickEdit)
            {
                _clickEdit = true;
                EditMode(true);
                SetStatus_TextBox(ref lTextBox, true);
            }
            else
            {
                _clickEdit = false;
                EditMode(false);
                SetStatus_TextBox(ref lTextBox, false);
            }
        }

        private void button5_Cancel_Click(object sender, EventArgs e)
        {
            LoadInfoToForm();
            EditMode(false);
            SetStatus_TextBox(ref lTextBox, false);
            _bCheckClick_AddNewBook = false;

        }

        private void button1_Refresh_Click(object sender, EventArgs e)
        {
            SQL.ListData.Fill.AllToDataGridView("Sach", ref this.dataGridView1_Info);
        }

        private void dataGridView1_Info_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadInfoToForm();

            SQL.ListData.Fill.SomeToDataGridView(
                @"select TenTheLoai from TheLoai tl, Sach_TheLoai stl where tl.MaTheLoai = stl.MaTheLoai and stl.MaSach = N'"
                    + this.textBox1.Text + "'",
                ref this.dataGridView2_DSTheLoai);
            //test = SQL.ListData.GetDataFromSQL.SelectOneTableString(
            //    @"select tl.TenTheLoai from TheLoai tl, Sach_TheLoai stl where tl.MaTheLoai =  = N'" + this.textBox1.Text + "'");

            //int i = 0;
            //while (i < test.Count)
            //{
            //    this.richTextBox1.Text += test[i] + "\n";
            //    ++i;
            //}
        }

        private void button0_Find_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox0_Search.Text))
            {
                Usefull_Function.Find(this.textBox0_Search.Text, ref dataGridView1_Info, new List<int>() {0, 1, 2, 3, 4, 5, 6 });
            }
        }
        
        private void button6_Exit_Click(object sender, EventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }

        private void button4_Delete_Click(object sender, EventArgs e)
        {
            string masachhientai = this.dataGridView1_Info.SelectedRows[0].Cells[0].Value.ToString();
            SQL.Query.CommandText = 
                @"delete from Sach where MaSach = N'" + masachhientai + "'";
            if (!SQL.Query.ExecuteNonQuery())
            {
                if (DialogResult.OK == MessageBox.Show(@"Không thể xoá vì vẫn còn tồn tại các bản ghi liên kết đến bản ghi hiện tại\n\nBạn có muốn xoá tất cả các bản ghi liên kết đến không?", @"Cảnh báo xoá", MessageBoxButtons.OKCancel))
                {
                    // xoá các bản ghi trong table 'sach_theloai' + 'muonsach' + 'nhansach' + 'sach_theloai' sau đó xoá trong table 'sach'
                    List<string> nameTable = new List<string>();
                    string tam = "Xoá sách: " + this.dataGridView1_Info.SelectedRows[0].Cells["TenSach"].Value.ToString() + "\n\n";

                    nameTable.Add(@"Sach_TheLoai");
                    nameTable.Add(@"MuonSach");
                    nameTable.Add(@"NhanSach");
                    nameTable.Add(@"Sach");

                    for (int i = 0; i < nameTable.Count; i = 0)
                    {
                        SQL.Query.CommandText =
                        @"delete from " + nameTable[0] + " where MaSach = N'" + masachhientai + "'";
                        if (!SQL.Query.ExecuteNonQuery())
                        {
                            tam += @"Không thể xoá các bản ghi trong table " + nameTable[0] + "\n";
                        }
                        else
                        {
                            tam += @"Xoá thành công bản ghi trong table " + nameTable[0] + "\n";
                        }
                        nameTable.RemoveAt(0);
                    }

                    MessageBox.Show(tam);
                }
            }

            this.button1_Refresh_Click(sender, e);
        }

        private bool _bCheckClick_AddNewBook = false;
        private void button2_AddNew_Click(object sender, EventArgs e)
        {
            if (!_bCheckClick_AddNewBook)
            {
                _bCheckClick_AddNewBook = true;
                this.button2_AddNew.Text = "Lưu bản ghi";

                EditMode(true);
                SetStatus_TextBox(ref lTextBox, true);

                dataGridView1_Info.Enabled = false;
                this.button3_Edit.Enabled = false;
                this.button4_Delete.Enabled = false;
                this.button7_Save.Enabled = false;

                textBox8.Text = "True";
                EmptyInfo();
                textBox1.Text = SQL.ListData.GetDataFromSQL.Sach_GetNextIndex();


                //dataGridView2_DSTheLoai.DataSource = null;
                //dataGridView2_DSTheLoai.Refresh();

                button8_AddNewTypeBook.Show();
            }
            else
            {
                _bCheckClick_AddNewBook = false;
                this.button2_AddNew.Text = "Thêm mới";
                this.button7_Save.Enabled = true;
                button8_AddNewTypeBook.Hide();

                dataGridView1_Info.Enabled = true;
                this.button3_Edit.Enabled = true;
                this.button4_Delete.Enabled = true;

                string sErrorMessage = "Tình trạng:\n\n";

                // tạo bản ghi cho cuốn sách mới
                SQL.Struct.Sach t = TextboxTo_Sach();
                if (SQL.ListData.GetDataFromSQL.Sach_CreateNewRecord(t))
                {
                    sErrorMessage += "\n- Tạo bản ghi sách mới thành công!\n";
                }
                else
                    sErrorMessage += "\n- Tạo bản ghi sách thất bại!\n";

                // lưu thể loại cho cuốn sách mới
                SQL.Struct.Sach_TheLoai stl;
                for (int i = 0; i < chooseTypeBook.Items.Count; i++)
                {
                    if (chooseTypeBook.GetItemChecked(i))
                    {
                        stl = new SQL.Struct.Sach_TheLoai();
                        stl.MaSach = textBox1.Text;
                        stl.MaTheLoai = lMaTheLoai[i];

                        if (SQL.ListData.GetDataFromSQL.Sach_TheLoai_CreateNewRecord(stl))
                        {
                            sErrorMessage += "\n- Tạo thể loại \"" + lTenTheLoai[i] + "\" thành công!";
                        }
                        else
                        {
                            sErrorMessage += "\n- Thất bại tạo thể loại \"" + lTenTheLoai[i] + "\"!";
                        }
                    }
                }
                dataGridView2_DSTheLoai.DataSource = null;
                dataGridView2_DSTheLoai.Columns.Remove("TheLoai");
                MessageBox.Show(sErrorMessage);
            }
        }

        private bool bHelpAddTypeBook = true;
        private void button8_AddNewTypeBook_Click(object sender, EventArgs e)
        {
            if (bHelpAddTypeBook)
            {
                chooseTypeBook.Show();
                button8_AddNewTypeBook.Text = "Lưu ds thể loại";
                bHelpAddTypeBook = false;
            }
            else
            {
                bHelpAddTypeBook = true;
                chooseTypeBook.Hide();
                button8_AddNewTypeBook.Text = "Thêm thể loại";
                dataGridView2_DSTheLoai.Columns.Add("TheLoai", "Thể loại");
                for (int i = 0; i < chooseTypeBook.Items.Count; i++)
                {
                    if (chooseTypeBook.GetItemChecked(i))
                    {
                        
                        dataGridView2_DSTheLoai.Rows.Add(chooseTypeBook.Items[i].ToString());
                    }
                }
            }
        }
    }
}
