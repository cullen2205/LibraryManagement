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
using LibraryManagement.Models;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace LibraryManagement.Forms
{
    public partial class ManageBook : Form
    {
        //private List<Label> lLabel = new List<Label>();
        private List<TextBox> lTextBox = new List<TextBox>();
        private List<string> lTenTheLoai;
        private List<string> lMaTheLoai;
        private DbLibraryManagement db = new DbLibraryManagement();
        //private List<Button> lButton = new List<Button>();
        string _pathAvatar;


        public ManageBook()
        {
            InitializeComponent();

            // cài đặt mặc định cho form
            //this.MaximizeBox = false;
            this.txtMaSach.Enabled = false;
            this.txtTinhTrang.Enabled = false;
            this.dataGridView2_DSTheLoai.ReadOnly = true;

            btnAddNewTypeBook.Hide();
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

            lTextBox.Add(this.txtTenSach);
            lTextBox.Add(this.txtTenTacGia);
            lTextBox.Add(this.txtNamXuatBan);
            lTextBox.Add(this.txtGia);
            lTextBox.Add(this.txtNhaXuatBan);
            lTextBox.Add(this.txtGioiHanTuoi);

            // quản lý button bằng list
            // lButton.Add(this.button0_Find);
            // lButton.Add(this.button1_Refresh);
            //lButton.Add(this.button2_AddNew);
            //lButton.Add(this.button3_Edit);
            //lButton.Add(this.button4_Delete);
            //lButton.Add(this.button5_Cancel);

            // đổ dữ liệu vào datagridview
            btnRefresh_Click(sender, e);

            // thêm thể loại vào biến chooseTypeBook
            //lTenTheLoai = SQL.ListData.GetDataFromSQL.Sach_SelectOneTableString("select * from TheLoai", "TenTheLoai");
            //lMaTheLoai = SQL.ListData.GetDataFromSQL.Sach_SelectOneTableString("select * from TheLoai", "MaTheLoai");
            lTenTheLoai = db.Database.SqlQuery<string>("SELECT TenTheLoai FROM THELOAI").ToList();
            lMaTheLoai = db.Database.SqlQuery<string>("SELECT MaTheLoai FROM THELOAI").ToList();
            for (int i = 0; i < lTenTheLoai.Count; i++)
            {
                chooseTypeBook.Items.Add(lTenTheLoai[i]);
            }
            // mặc định khi chưa chuyển trạng thái editmode
            EditMode(false);
            SetStatus_TextBox(ref lTextBox, false);

            LoadInfoToForm();
            btnAddNewTypeBook.Show();
            chooseTypeBook.Hide();
        }

        private void EmptyInfo()
        {
            dataGridView2_DSTheLoai.DataSource = null;
            dataGridView2_DSTheLoai.Refresh();

            txtMaSach.Text = "";
            for (int i = 0; i < lTextBox.Count; i++)
            {
                lTextBox[i].Text = "";
            }
        }

        private void LoadInfoToForm()
        {
            if (this.dataGridView1_Info.SelectedRows.Count > 0)
            {
                //try
                //{
                this.txtMaSach.Text = this.dataGridView1_Info.SelectedRows[0].Cells["MaSach"].Value.ToString();
                this.txtTenSach.Text = this.dataGridView1_Info.SelectedRows[0].Cells["TenSach"].Value.ToString();
                this.txtTenTacGia.Text = this.dataGridView1_Info.SelectedRows[0].Cells["TacGia"].Value.ToString();
                this.txtNamXuatBan.Text = this.dataGridView1_Info.SelectedRows[0].Cells["NamXuatBan"].Value.ToString();
                this.txtGia.Text = this.dataGridView1_Info.SelectedRows[0].Cells["Gia"].Value.ToString();
                this.txtNhaXuatBan.Text = this.dataGridView1_Info.SelectedRows[0].Cells["NhaXuatBan"].Value.ToString();
                this.txtGioiHanTuoi.Text = this.dataGridView1_Info.SelectedRows[0].Cells["GioiHanTuoi"].Value.ToString();

                //object tam = SQL.ListData.GetDataFromSQL.Query_All
                //    (@"select top 1 TinhTrang from MuonSach where MaSach = N'"
                //        + this.textBox1.Text + "' order by TinhTrang desc");
                bool? tam = db.Database.SqlQuery<bool?>(@"select top 1 TinhTrang from MuonSach where MaSach = N'"
                        + this.txtMaSach.Text + @"' order by TinhTrang desc").SingleOrDefault();
                if (tam != null | tam == true)
                {
                    this.txtTinhTrang.Text = "True";
                }
                else
                {
                    this.txtTinhTrang.Text = "False";
                }

                LoadAvatar_Sach(this.txtMaSach.Text);
                //}
                //catch
                //{
                //    this.txtMaSach.Text = "";
                //    this.textBox2.Text = "";
                //    this.textBox3.Text = "";
                //    this.textBox4.Text = "";
                //    this.textBox5.Text = "";
                //    this.textBox6.Text = "";
                //    this.textBox7.Text = "";
                //    this.textBox8.Text = "";
                //    LoadAvatar_Sach(this.txtMaSach.Text);

                //}
            }
        }

        private void LoadAvatar_Sach(string _MaSach)
        {
            // Hiện avatar
            try
            {
                //string path = (string)SQL.ListData.GetDataFromSQL.Query_All(
                //@"select top 1 DuongDanAnhDaiDien from Sach where MaSach = N'" + _MaSach + "'");
                string path = db.Database.SqlQuery<string>(
                @"select top 1 DuongDanAnhDaiDien from Sach where MaSach = N'" + _MaSach + "'").SingleOrDefault();

                this.pictureBox1_Avatar.Image = Image.FromFile(path);
            }
            catch
            {
                this.pictureBox1_Avatar.Image = Properties.Resources.NoAvartar;
            }
        }

        private Models.Sach TextboxTo_Sach()
        {
            Models.Sach t = new Models.Sach();
            t.MaSach = txtMaSach.Text;
            t.TenSach = txtTenSach.Text;
            t.TacGia = txtTenTacGia.Text;
            t.NamXuatBan = string.IsNullOrWhiteSpace(txtNamXuatBan.Text) ? 0 : int.Parse(txtNamXuatBan.Text);
            t.Gia = string.IsNullOrWhiteSpace(txtGia.Text) ? 0 : int.Parse(txtGia.Text);
            t.NhaXuatBan = txtNhaXuatBan.Text;
            t.GioiHanTuoi = string.IsNullOrWhiteSpace(txtGioiHanTuoi.Text) ? 0 : int.Parse(txtGioiHanTuoi.Text);
            t.DuongDanAnhDaiDien = _pathAvatar;
            return t;
        }

        private void EditMode(bool IsHide = false)
        {
            this.btnDelete.Enabled = IsHide;
            this.btnCancel.Enabled = IsHide;
            this.btnChangeAvatar.Enabled = IsHide;
            this.btnSaveInfo.Enabled = IsHide;
            this.btnAddNewTypeBook.Enabled = IsHide;
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
            Sach s = db.Saches.SingleOrDefault(m => m.MaSach == txtMaSach.Text);
            s.MaSach = this.txtMaSach.Text;
            s.TenSach = this.txtTenSach.Text;
            s.TacGia = this.txtTenTacGia.Text;
            s.NamXuatBan = int.Parse(this.txtNamXuatBan.Text);
            s.Gia = int.Parse(this.txtGia.Text);
            s.NhaXuatBan = this.txtNhaXuatBan.Text;
            s.GioiHanTuoi = int.Parse(this.txtGioiHanTuoi.Text);
            s.DuongDanAnhDaiDien = _pathAvatar;
            db.Database.ExecuteSqlCommand("DELETE Sach_TheLoai WHERE MaSach = N'" + txtMaSach.Text + "'");
            db.SaveChanges();

            for (int i = 0; i < dataGridView2_DSTheLoai.Rows.Count; i++)
            {
                string maThLoai = dataGridView2_DSTheLoai.Rows[i].Cells[0].Value.ToString();
                if (!string.IsNullOrWhiteSpace(s.MaSach) | !string.IsNullOrWhiteSpace(maThLoai))
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("INSERT Sach_TheLoai (MaSach, MaTheLoai) VALUES (N'" + s.MaSach + "', N'" + maThLoai + "')");
                    }
                    catch
                    {

                    }
                }
            }
            db.SaveChanges();
            dataGridView2_DSTheLoai.DataSource = null;
            dataGridView2_DSTheLoai.Columns.Clear();
            dataGridView2_DSTheLoai.Refresh();
            btnRefresh_Click(sender, e);
        }

        List<string> test = new List<string>();

        private bool _clickEdit = false;
        private void btnEdit_Click(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //BindingList<Sach> dtSach = new BindingList<Sach>(db.Saches.ToList());
            //dataGridView1_Info.DataSource = dtSach;
            dataGridView1_Info.DataSource = new System.Collections.ObjectModel.ObservableCollection<Sach>(db.Saches.ToList()).ToBindingList();
        }

        private void dataGridView1_Info_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadInfoToForm();

            _pathAvatar = dataGridView1_Info.Rows[e.RowIndex].Cells["DuongDanAnhDaiDien"].Value as string;


            dataGridView2_DSTheLoai.DataSource = null;
            dataGridView2_DSTheLoai.DataSource = db.Database.SqlQuery<TheLoai>("SELECT tl.MaTheLoai, tl.TenTheLoai FROM THELOAI tl, Sach_TheLoai stl WHERE stl.MaSach = N'" + txtMaSach.Text + "' AND stl.MaTheLoai = tl.MaTheLoai").Cast<TheLoai>().ToList();
            dataGridView2_DSTheLoai.Columns[0].Width = 80;
        }

        private void button0_Find_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtSearch.Text))
            {
                btnRefresh_Click(sender, e);
                Usefull_Function.Find(this.txtSearch.Text, ref dataGridView1_Info);
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

            btnRefresh_Click(sender, e);
        }

        private bool _bCheckClick_AddNewBook = false;
        private void button2_AddNew_Click(object sender, EventArgs e)
        {
            if (!_bCheckClick_AddNewBook)
            {
                _bCheckClick_AddNewBook = true;
                this.btnAddNew.Text = "Lưu bản ghi";

                _pathAvatar = null;

                EditMode(true);
                SetStatus_TextBox(ref lTextBox, true);

                dataGridView1_Info.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnSaveInfo.Enabled = false;

                txtTinhTrang.Text = "True";
                EmptyInfo();
                txtMaSach.Text = SQL.ListData.GetDataFromSQL.Sach_GetNextIndex();


                //dataGridView2_DSTheLoai.DataSource = null;
                //dataGridView2_DSTheLoai.Refresh();

                btnAddNewTypeBook.Show();
            }
            else
            {
                _bCheckClick_AddNewBook = false;
                this.btnAddNew.Text = "Thêm mới";
                this.btnSaveInfo.Enabled = true;
                //btnAddNewTypeBook.Hide();

                dataGridView1_Info.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;

                // tạo bản ghi cho cuốn sách mới
                Sach t = TextboxTo_Sach();
                db.Saches.Add(t);
                db.SaveChanges();
                // lưu thể loại cho cuốn sách mới
                for (int i = 0; i < chooseTypeBook.Items.Count; i++)
                {
                    if (chooseTypeBook.GetItemChecked(i))
                    {
                        db.Database.ExecuteSqlCommand("INSERT Sach_TheLoai (MaSach, MaTheLoai) VALUES ('" + t.MaSach + "', '" + lMaTheLoai[i] + "')");
                    }
                }

                db.SaveChanges();

                dataGridView2_DSTheLoai.DataSource = null;
                dataGridView2_DSTheLoai.Columns.Clear();
                dataGridView2_DSTheLoai.Refresh();
                MessageBox.Show("Lưu thành công!");
                btnEdit_Click(sender, e);
                btnRefresh_Click(sender, e);
            }
        }

        private bool bHelpAddTypeBook = true;
        private void btnAddNewTypeBook_Click(object sender, EventArgs e)
        {
            if (bHelpAddTypeBook)
            {
                chooseTypeBook.Show();
                btnAddNewTypeBook.Text = "Lưu ds thể loại";
                bHelpAddTypeBook = false;
            }
            else
            {
                bHelpAddTypeBook = true;
                chooseTypeBook.Hide();
                btnAddNewTypeBook.Text = "Thêm thể loại";
                
                for (int i = 0; i < dataGridView2_DSTheLoai.Rows.Count; i++)
                {
                    string ldata = dataGridView2_DSTheLoai.Rows[i].Cells[1].Value.ToString();
                    string lchoose = chooseTypeBook.Items.ToString();
                    if (string.Equals(ldata, lchoose))
                    {
                        chooseTypeBook.SetItemChecked(i, true);
                    }
                }
                dataGridView2_DSTheLoai.DataSource = null;
                dataGridView2_DSTheLoai.Columns.Clear();
                dataGridView2_DSTheLoai.Columns.Add("MaTheLoai", "Mã thể loại");
                dataGridView2_DSTheLoai.Columns.Add("TenTheLoai", "Tên thể loại");

                for (int i = 0; i < dataGridView2_DSTheLoai.Rows.Count; i = 0)
                {
                    dataGridView2_DSTheLoai.Rows.RemoveAt(i);
                }
                for (int i = 0; i < chooseTypeBook.Items.Count; i++)
                {
                    if (chooseTypeBook.GetItemChecked(i))
                    {
                        dataGridView2_DSTheLoai.Rows.Add(lMaTheLoai[i], chooseTypeBook.Items[i].ToString());
                    }
                }
                dataGridView2_DSTheLoai.Refresh();
            }
        }
    }
}
