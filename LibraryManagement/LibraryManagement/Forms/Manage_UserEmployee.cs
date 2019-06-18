using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace LibraryManagement.Forms
{
    public partial class Manage_UserEmployee : Form
    {
        private List<TextBox> lTextbox;
        private EnumMyStruct eTypeManage;
        private DbLibraryManagement db = new DbLibraryManagement();
        public Manage_UserEmployee(EnumMyStruct _typeManage) // only manage User or Employee
        {
            InitializeComponent();
            //this.MaximizeBox = false;
            eTypeManage = _typeManage;
            this.Text += _typeManage == EnumMyStruct.NguoiDung ? "người dùng" : "nhân viên";
        }

        private void Manage_UserEmployee_Load(object sender, EventArgs e)
        {
            lTextbox = new List<TextBox>();
            lTextbox.Add(txtSoCMND);
            // lTextbox.Add(textBox3_TenDangNhap);
            lTextbox.Add(txtHoTen);
            lTextbox.Add(txtSoDienThoai);
            lTextbox.Add(txtDiaChi);
            lTextbox.Add(txtTenNBH);
            lTextbox.Add(txtSDTNBH);
            lTextbox.Add(txtDiaChiNBH);

            txtTenDangNhap.Enabled = false;

            EditMode(false);
            HideInfo(eTypeManage);
            btnReset_Click(sender, e);
        }

        private void ChangeState_ListTextbox(ref List<TextBox> l, bool _bState = false)
        {
            for (int i = 0; i < l.Count; i++)
            {
                l[i].Enabled = _bState;
            }
        }

        private void EmptyInput(ref List<TextBox> l)
        {
            // làm rỗng danh sách
            for (int i = 0; i < l.Count; i++)
            {
                l[i].Text = "";
            }

            txtTenDangNhap.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            dateTimePicker1_NgaySinh.Value = DateTime.Now;
            checkBox1.Checked = false;
        }

        private void HideInfo(EnumMyStruct _typeMagnage)
        {
            switch (_typeMagnage)
            {
                case EnumMyStruct.NguoiDung:
                    this.label8.Show();
                    this.label9.Show();
                    this.label10.Show();
                    this.txtTenNBH.Show();
                    this.txtSDTNBH.Show();
                    this.txtDiaChiNBH.Show();

                    this.label12.Hide();
                    this.checkBox1.Hide();
                    break;
                default:
                    this.label8.Hide();
                    this.label9.Hide();
                    this.label10.Hide();
                    this.txtTenNBH.Hide();
                    this.txtSDTNBH.Hide();
                    this.txtDiaChiNBH.Hide();

                    this.label12.Show();
                    this.checkBox1.Show();
                    break;
            }
        }

        private void LoadInfo(int _index)
        {
            try
            {
                switch (eTypeManage)
                {
                    case EnumMyStruct.NguoiDung:
                        this.txtSoCMND.Text = this.dataGridView1.Rows[_index].Cells["SoCMND"].Value.ToString();
                        this.txtTenDangNhap.Text = this.dataGridView1.Rows[_index].Cells["TenDangNhap"].Value.ToString();
                        this.txtHoTen.Text = this.dataGridView1.Rows[_index].Cells["HoTen"].Value.ToString();
                        this.txtSoDienThoai.Text = this.dataGridView1.Rows[_index].Cells["SoDienThoai"].Value.ToString();
                        this.txtDiaChi.Text = this.dataGridView1.Rows[_index].Cells["DiaChiThuongTru"].Value.ToString();
                        this.txtTenNBH.Text = this.dataGridView1.Rows[_index].Cells["TenNguoiBaoHo"].Value.ToString();
                        this.txtSDTNBH.Text = this.dataGridView1.Rows[_index].Cells["SDTNguoiBaoHo"].Value.ToString();
                        this.txtDiaChiNBH.Text = this.dataGridView1.Rows[_index].Cells["DiaChiNguoiBaoHo"].Value.ToString();

                        radioButton1.Checked = bool.Parse(this.dataGridView1.Rows[_index].Cells["GioiTinh"].Value.ToString());
                        radioButton2.Checked = !radioButton1.Checked;
                        this.dateTimePicker1_NgaySinh.Value = DateTime.Parse(this.dataGridView1.Rows[_index].Cells["NgaySinh"].Value.ToString());
                        this.txtKieuTaiKhoan.Text = "Người dùng";

                        break;

                    case EnumMyStruct.NhanVien:
                        this.txtSoCMND.Text = this.dataGridView1.Rows[_index].Cells["SoCMND"].Value.ToString();
                        this.txtTenDangNhap.Text = this.dataGridView1.Rows[_index].Cells["MaNhanVien"].Value.ToString();
                        this.txtHoTen.Text = this.dataGridView1.Rows[_index].Cells["TenNhanVien"].Value.ToString();
                        this.txtSoDienThoai.Text = this.dataGridView1.Rows[_index].Cells["SoDienThoai"].Value.ToString();
                        this.txtDiaChi.Text = this.dataGridView1.Rows[_index].Cells["DiaChi"].Value.ToString();

                        radioButton1.Checked = bool.Parse(this.dataGridView1.Rows[_index].Cells["GioiTinh"].Value.ToString());
                        radioButton2.Checked = !radioButton1.Checked;

                        this.dateTimePicker1_NgaySinh.Value = DateTime.Parse(this.dataGridView1.Rows[_index].Cells["NgaySinh"].Value.ToString());

                        // kiểu tài khoản
                        this.txtKieuTaiKhoan.Text = bool.Parse(this.dataGridView1.Rows[_index].Cells["LaQuanTriVien"].Value.ToString()) == true ? "Quản trị viên" : "Nhân viên";
                        
                        break;

                    default:
                        break;
                }

                // load ảnh
                try
                {
                    Image ima = Image.FromFile(this.dataGridView1.Rows[_index].Cells["DuongDanAnhDaiDien"].Value.ToString());
                    this.pictureBox1_Avatar.Image = ima;
                }
                catch (Exception)
                {
                    this.pictureBox1_Avatar.Image = Properties.Resources.NoAvartar;
                }
            }
            catch
            {
                this.txtSoCMND.Text = "";
                this.txtTenDangNhap.Text = "";
                this.txtHoTen.Text = "";
                this.txtSoDienThoai.Text = "";
                this.txtDiaChi.Text = "";
                this.txtTenNBH.Text = "";
                this.txtSDTNBH.Text = "";
                this.txtDiaChiNBH.Text = "";
                this.txtKieuTaiKhoan.Text = "";

                this.pictureBox1_Avatar.Image = Properties.Resources.NoAvartar;
            }
        }

        private object AddDataToObject(EnumMyStruct _eType)
        {
            switch (_eType)
            {
                case EnumMyStruct.NguoiDung:
                    Models.NguoiDung nd = db.NguoiDungs.Find(txtSoCMND.Text);
                    if (nd == null)
                    {
                        nd = new NguoiDung();
                        nd.MatKhau = txtTenDangNhap.Text;
                    }
                    nd.SoCMND = txtSoCMND.Text;
                    nd.TenDangNhap = txtTenDangNhap.Text;
                    nd.HoTen = txtHoTen.Text;
                    nd.SoDienThoai = txtSoDienThoai.Text;
                    nd.DiaChiThuongTru = txtDiaChi.Text;
                    nd.GioiTinh = radioButton1.Checked ? true : false;
                    nd.NgaySinh = dateTimePicker1_NgaySinh.Value;
                    nd.TenNguoiBaoHo = txtTenNBH.Text;
                    nd.SDTNguoiBaoHo = txtSDTNBH.Text;
                    nd.DiaChiNguoiBaoHo = txtDiaChiNBH.Text;
                    return nd;
                case EnumMyStruct.NhanVien:
                    Models.NhanVien nv = db.NhanViens.Find(txtTenDangNhap.Text);
                    if (nv == null)
                    {
                        nv = new NhanVien();
                        nv.MatKhau = txtTenDangNhap.Text;
                    }
                    nv.MaNhanVien = txtTenDangNhap.Text;
                    nv.TenNhanVien = txtHoTen.Text;
                    nv.SoCMND = txtSoCMND.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.SoDienThoai = txtSoDienThoai.Text;
                    nv.GioiTinh = radioButton1.Checked ? true : false;
                    nv.NgaySinh = dateTimePicker1_NgaySinh.Value;
                    nv.LaQuanTriVien = checkBox1.Checked;
                    return nv;
                default:
                    return null;
            }
        }

        private void EditMode(bool _Edit = false)
        {
            btnSaveChange.Enabled = btnCancel.Enabled = _Edit;
            ChangeState_ListTextbox(ref lTextbox, _Edit);
            this.radioButton1.Enabled = this.radioButton2.Enabled = _Edit;
            this.dateTimePicker1_NgaySinh.Enabled = _Edit;

            if (eTypeManage == EnumMyStruct.NhanVien && LoginFormLibraryManagement.UserEmployeeAdmin == 1)
            {
                this.checkBox1.Enabled = _Edit;
            }
            else
            {
                this.checkBox1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }

        private void ManageUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // SQL.ListData.Fill.AllToDataGridView(eTypeManage.ToString(), ref this.dataGridView1);
            dataGridView1.DataSource = null;

            switch (eTypeManage)
            {
                case EnumMyStruct.MuonSach:
                    break;
                case EnumMyStruct.NganHang:
                    break;
                case EnumMyStruct.NguoiDung:
                    //BindingList<NguoiDung> blnguoidung = new BindingList<NguoiDung>(db.NguoiDungs.ToList());
                    //dataGridView1.DataSource = blnguoidung;
                    dataGridView1.DataSource = new System.Collections.ObjectModel.ObservableCollection<NguoiDung>(db.NguoiDungs.ToList()).ToBindingList();
                    break;
                case EnumMyStruct.NguoiDung_NganHang:
                    break;
                case EnumMyStruct.NhanSach:
                    break;
                case EnumMyStruct.NhanVien:
                    //BindingList<NhanVien> blnhanvien = new BindingList<NhanVien>(db.NhanViens.ToList());
                    //dataGridView1.DataSource = blnhanvien;
                    dataGridView1.DataSource = new System.Collections.ObjectModel.ObservableCollection<NhanVien>(db.NhanViens.ToList()).ToBindingList();
                    break;
                case EnumMyStruct.NhanVien_NganHang:
                    break;
                case EnumMyStruct.Sach:
                    break;
                case EnumMyStruct.Sach_TheLoai:
                    break;
                case EnumMyStruct.TheLoai:
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadInfo(e.RowIndex);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton1.Checked = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
        }

        private void button4_Edit_Click(object sender, EventArgs e)
        {
            EditMode(true);
        }

        private void button8_Cancel_Click(object sender, EventArgs e)
        {
            EditMode(false);
            this.btnDelete.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        private void button6_Delete_Click(object sender, EventArgs e)
        {
            // Nhân viên: xoá bảng nhân viên _ ngân hàng, sửa bảng nhận sách + mượn sách
            // Người dùng: xoá bảng người dùng _ ngân hàng, sửa bảng mượn sách

            string sErrorMesage = "Kết quả:\n\n";
            switch (eTypeManage)
            {
                case EnumMyStruct.NguoiDung:
                    // thử xoá bản ghi trước nếu nó không có liên kết
                    if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NguoiDung(this.txtSoCMND.Text))
                    {
                        if (DialogResult.OK == 
                            MessageBox.Show(
                                "Bản ghi hiện tại đang liên kết với các bản ghi khác\nBạn có muốn xoá (hoặc thay đổi) nội dung của tất cả các bản ghi trong trong csdl không?",
                                "Cảnh báo thay đổi", MessageBoxButtons.OKCancel))
                        {
                            // xoá bản ghi trong nhân viên _ ngân hàng
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NguoiDung_NganHang(
                                SQL.Struct.NguoiDung_NganHang.eNguoiDung_NganHang.SoCMND,
                                this.txtSoCMND.Text))
                            {
                                sErrorMesage += "\n- Không thể xoá bản ghi trong table NhanVien_NganHang!";
                            }
                            else
                                sErrorMesage += "\n- Xoá bản ghi trong table NhanVien_NganHang thành công!";

                            // sửa bản ghi trong bảng mượn sách
                            if (!SQL.ListData.GetDataFromSQL.MuonSach_UpdateAllRecord_HaveTableX(SQL.Struct.MuonSach.eMuonSach.SoCMND,
                                "null", SQL.Struct.MuonSach.eMuonSach.SoCMND, this.txtSoCMND.Text))
                            {
                                sErrorMesage += "\n- Không thể sửa bản ghi trong table MuonSach!";
                            }
                            else
                                sErrorMesage += "\n- Sửa bản ghi trong table MuonSach thành công!";

                            // xoá trong bảng người dùng
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NguoiDung(this.txtSoCMND.Text))
                            {
                                sErrorMesage += "\n- Không thể xoá bản ghi trong table NguoiDung!";
                            }
                            else
                                sErrorMesage += "\n- Xoá bản ghi trong table NguoiDung thành công!";

                            MessageBox.Show(sErrorMesage);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xoá thành công!");
                    }

                    // nếu ko xoá được thì xoá và sửa các bản ghi liên kết đến nó
                    break;
                case EnumMyStruct.NhanVien:
                    // thử xoá bản ghi trước nếu nó không có liên kết
                    if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NhanVien(this.txtTenDangNhap.Text))
                    {
                        if (DialogResult.OK ==
                            MessageBox.Show(
                                "Bản ghi hiện tại đang liên kết với các bản ghi khác\nBạn có muốn xoá (hoặc thay đổi) nội dung của tất cả các bản ghi trong trong csdl không?",
                                "Cảnh báo thay đổi", MessageBoxButtons.OKCancel))
                        {
                            // Nhân viên: xoá bảng nhân viên _ ngân hàng, sửa bảng nhận sách + mượn sách

                            // xoá trong bảng nhân viên _ ngân hàng
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NhanVien_NganHang(SQL.Struct.NhanVien_NganHang.eNhanVien_NganHang.MaNhanVien, this.txtTenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể xoá bản ghi trong table NhanVien_NganHang!";
                            }
                            else
                            {
                                sErrorMesage += "\n- Xoá bản ghi trong table NhanVien_NganHang thành công!";
                            }

                            // sửa trong bảng nhận sách
                            if (!SQL.ListData.GetDataFromSQL.NhanSach_UpdateAllRecord_HaveTableX(SQL.Struct.NhanSach.eNhanSach.MaNhanVien,
                                "null", SQL.Struct.NhanSach.eNhanSach.MaNhanVien, this.txtTenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể sửa bản ghi trong table MuonSach!";
                            }
                            else
                                sErrorMesage += "\n- Sửa bản ghi trong table MuonSach thành công!";

                            // sửa trong bảng mượn sách
                            if (!SQL.ListData.GetDataFromSQL.MuonSach_UpdateAllRecord_HaveTableX(SQL.Struct.MuonSach.eMuonSach.MaNhanVien,
                                "null", SQL.Struct.MuonSach.eMuonSach.MaNhanVien, this.txtTenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể sửa bản ghi trong table MuonSach!";
                            }
                            else
                                sErrorMesage += "\n- Sửa bản ghi trong table MuonSach thành công!";

                            // xoá bản ghi trong table nhân viên
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NhanVien(this.txtTenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể xoá bản ghi trong table NhanVien!";
                            }
                            else
                            {
                                sErrorMesage += "\n- Xoá bản ghi trong table NhanVien thành công!";
                            }

                            MessageBox.Show(sErrorMesage);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xoá thành công!");
                    }
                    break;
                default:
                    break;
            }
        }

        private bool bSaveNewRecord = false;
        private void button3_AddNew_Click(object sender, EventArgs e)
        {
            if (!bSaveNewRecord)
            {
                // tạo một bản ghi mới
                switch (eTypeManage)
                {
                    case EnumMyStruct.NguoiDung:
                        this.txtTenDangNhap.Enabled = true;
                        EmptyInput(ref lTextbox);
                        break;

                    case EnumMyStruct.NhanVien:
                        EmptyInput(ref lTextbox);
                        this.txtTenDangNhap.Text = SQL.ListData.GetDataFromSQL.NhanVien_GetNext_MaNhanVien();
                        break;

                    default:
                        break;
                }
                bSaveNewRecord = true;
                EditMode(true);
                this.btnAddNew.Text = "Lưu bản ghi mới";
                this.btnEdit.Enabled = false;
                this.btnSaveChange.Enabled = false;
                this.btnDelete.Enabled = false;
                this.dataGridView1.Enabled = false;
            }
            else
            {
                // lưu bản ghi mới
                switch (eTypeManage)
                {
                    case EnumMyStruct.NguoiDung:
                        Models.NguoiDung nd = AddDataToObject(EnumMyStruct.NguoiDung) as Models.NguoiDung;
                        db.NguoiDungs.AddOrUpdate(nd);
                        db.SaveChanges();
                        MessageBox.Show("Tạo bản ghi mới thành công!");

                        this.txtTenDangNhap.Enabled = false;
                        break;

                    case EnumMyStruct.NhanVien:
                        Models.NhanVien nv = AddDataToObject(EnumMyStruct.NhanVien) as Models.NhanVien;
                        db.NhanViens.AddOrUpdate(nv);
                        db.SaveChanges();
                        MessageBox.Show("Tạo bản ghi mới thành công!");
                        break;

                    default:
                        break;
                }
                bSaveNewRecord = false;
                this.btnAddNew.Text = "Thêm mới";
                this.button8_Cancel_Click(sender, e);
                this.dataGridView1.Enabled = true;
            }
        }

        private void button5_SaveChange_Click(object sender, EventArgs e)
        {
            switch (eTypeManage)
            {
                case EnumMyStruct.NguoiDung:
                    Models.NguoiDung nd = AddDataToObject(EnumMyStruct.NguoiDung) as Models.NguoiDung;
                    db.NguoiDungs.AddOrUpdate(nd);
                    db.SaveChanges();
                    break;
                case EnumMyStruct.NhanVien:
                    Models.NhanVien nv = AddDataToObject(EnumMyStruct.NhanVien) as Models.NhanVien;
                    db.NhanViens.AddOrUpdate(nv);
                    db.SaveChanges();
                    break;
                default:
                    break;
            }
            btnReset_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFindTextbox.Text))
            {
                btnReset_Click(sender, e);
                Usefull_Function.Find(this.txtFindTextbox.Text, ref dataGridView1);
            }
        }
    }
}
