using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class Manage_UserEmployee : Form
    {
        private List<TextBox> lTextbox;
        private EnumMyStruct eTypeManage;
        public Manage_UserEmployee(EnumMyStruct _typeManage) // only manage User or Employee
        {
            InitializeComponent();
            eTypeManage = _typeManage;
            this.Text += _typeManage == EnumMyStruct.NguoiDung ? "người dùng" : "nhân viên";
        }

        private void Manage_UserEmployee_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = new Size(1320, 620);

            lTextbox = new List<TextBox>();
            lTextbox.Add(textBox2_SoCMND);
            // lTextbox.Add(textBox3_TenDangNhap);
            lTextbox.Add(textBox4_HoTen);
            lTextbox.Add(textBox5_SoDienThoai);
            lTextbox.Add(textBox6_DiaChi);
            lTextbox.Add(textBox7_TenNBH);
            lTextbox.Add(textBox8_SDT_NBH);
            lTextbox.Add(textBox9_DiaChiNBH);

            textBox3_TenDangNhap.Enabled = false;

            EditMode(false);
            HideInfo(eTypeManage);
            SQL.ListData.Fill.AllToDataGridView(eTypeManage.ToString(), ref this.dataGridView1);
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

            textBox3_TenDangNhap.Text = "";
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
                    this.textBox7_TenNBH.Show();
                    this.textBox8_SDT_NBH.Show();
                    this.textBox9_DiaChiNBH.Show();

                    this.label12.Hide();
                    this.checkBox1.Hide();
                    break;
                default:
                    this.label8.Hide();
                    this.label9.Hide();
                    this.label10.Hide();
                    this.textBox7_TenNBH.Hide();
                    this.textBox8_SDT_NBH.Hide();
                    this.textBox9_DiaChiNBH.Hide();

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
                        this.textBox2_SoCMND.Text = this.dataGridView1.Rows[_index].Cells["SoCMND"].Value.ToString();
                        this.textBox3_TenDangNhap.Text = this.dataGridView1.Rows[_index].Cells["TenDangNhap"].Value.ToString();
                        this.textBox4_HoTen.Text = this.dataGridView1.Rows[_index].Cells["HoTen"].Value.ToString();
                        this.textBox5_SoDienThoai.Text = this.dataGridView1.Rows[_index].Cells["SoDienThoai"].Value.ToString();
                        this.textBox6_DiaChi.Text = this.dataGridView1.Rows[_index].Cells["DiaChiThuongTru"].Value.ToString();
                        this.textBox7_TenNBH.Text = this.dataGridView1.Rows[_index].Cells["TenNguoiBaoHo"].Value.ToString();
                        this.textBox8_SDT_NBH.Text = this.dataGridView1.Rows[_index].Cells["SDTNguoiBaoHo"].Value.ToString();
                        this.textBox9_DiaChiNBH.Text = this.dataGridView1.Rows[_index].Cells["DiaChiNguoiBaoHo"].Value.ToString();

                        radioButton1.Checked = bool.Parse(this.dataGridView1.Rows[_index].Cells["GioiTinh"].Value.ToString());
                        radioButton2.Checked = !radioButton1.Checked;
                        this.dateTimePicker1_NgaySinh.Value = DateTime.Parse(this.dataGridView1.Rows[_index].Cells["NgaySinh"].Value.ToString());
                        this.textBox10_KieuTaiKhoan.Text = "Người dùng";

                        break;

                    case EnumMyStruct.NhanVien:
                        this.textBox2_SoCMND.Text = this.dataGridView1.Rows[_index].Cells["SoCMND"].Value.ToString();
                        this.textBox3_TenDangNhap.Text = this.dataGridView1.Rows[_index].Cells["MaNhanVien"].Value.ToString();
                        this.textBox4_HoTen.Text = this.dataGridView1.Rows[_index].Cells["TenNhanVien"].Value.ToString();
                        this.textBox5_SoDienThoai.Text = this.dataGridView1.Rows[_index].Cells["SoDienThoai"].Value.ToString();
                        this.textBox6_DiaChi.Text = this.dataGridView1.Rows[_index].Cells["DiaChi"].Value.ToString();

                        radioButton1.Checked = bool.Parse(this.dataGridView1.Rows[_index].Cells["GioiTinh"].Value.ToString());
                        radioButton2.Checked = !radioButton1.Checked;

                        this.dateTimePicker1_NgaySinh.Value = DateTime.Parse(this.dataGridView1.Rows[_index].Cells["NgaySinh"].Value.ToString());

                        // kiểu tài khoản
                        this.textBox10_KieuTaiKhoan.Text = bool.Parse(this.dataGridView1.Rows[_index].Cells["LaQuanTriVien"].Value.ToString()) == true ? "Quản trị viên" : "Nhân viên";
                        
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
                this.textBox2_SoCMND.Text = "";
                this.textBox3_TenDangNhap.Text = "";
                this.textBox4_HoTen.Text = "";
                this.textBox5_SoDienThoai.Text = "";
                this.textBox6_DiaChi.Text = "";
                this.textBox7_TenNBH.Text = "";
                this.textBox8_SDT_NBH.Text = "";
                this.textBox9_DiaChiNBH.Text = "";
                this.textBox10_KieuTaiKhoan.Text = "";

                this.pictureBox1_Avatar.Image = Properties.Resources.NoAvartar;
            }
        }

        private object AddDataToObject(EnumMyStruct _eType)
        {
            switch (_eType)
            {
                case EnumMyStruct.NguoiDung:
                    SQL.Struct.NguoiDung nd = new SQL.Struct.NguoiDung();
                    nd.SoCMND = string.IsNullOrWhiteSpace(textBox2_SoCMND.Text) ? null : textBox2_SoCMND.Text;
                    nd.TenDangNhap = string.IsNullOrWhiteSpace(textBox3_TenDangNhap.Text) ? null : textBox3_TenDangNhap.Text;
                    nd.MatKhau = null;
                    nd.HoTen = string.IsNullOrWhiteSpace(textBox4_HoTen.Text) ? null : textBox4_HoTen.Text;
                    nd.SoDienThoai = string.IsNullOrWhiteSpace(textBox5_SoDienThoai.Text) ? null : textBox5_SoDienThoai.Text;
                    nd.DiaChiThuongTru = string.IsNullOrWhiteSpace(textBox6_DiaChi.Text) ? null : textBox6_DiaChi.Text;
                    nd.GioiTinh = radioButton1.Checked ? radioButton1.Checked : radioButton2.Checked;
                    nd.NgaySinh = this.dateTimePicker1_NgaySinh.Value;
                    nd.TenNguoiBaoHo = string.IsNullOrWhiteSpace(textBox7_TenNBH.Text) ? null : textBox7_TenNBH.Text;
                    nd.SDTNguoiBaoHo = string.IsNullOrWhiteSpace(textBox8_SDT_NBH.Text) ? null : textBox8_SDT_NBH.Text;
                    nd.DiaChiNguoiBaoHo = string.IsNullOrWhiteSpace(textBox9_DiaChiNBH.Text) ? null : textBox9_DiaChiNBH.Text;
                    nd.DuongDanAnhDaiDien = null;
                    return nd;
                case EnumMyStruct.NhanVien:
                    SQL.Struct.NhanVien nv = new SQL.Struct.NhanVien();
                    nv.MaNhanVien = string.IsNullOrWhiteSpace(textBox3_TenDangNhap.Text) ? null : textBox3_TenDangNhap.Text;
                    nv.MatKhau = null;
                    nv.TenNhanVien = string.IsNullOrWhiteSpace(textBox4_HoTen.Text) ? null : textBox4_HoTen.Text;
                    nv.SoCMND = string.IsNullOrWhiteSpace(textBox2_SoCMND.Text) ? null : textBox2_SoCMND.Text;
                    nv.DiaChi = string.IsNullOrWhiteSpace(textBox6_DiaChi.Text) ? null : textBox6_DiaChi.Text;
                    nv.SoDienThoai = string.IsNullOrWhiteSpace(textBox5_SoDienThoai.Text) ? null : textBox5_SoDienThoai.Text;
                    nv.GioiTinh = radioButton1.Checked ? radioButton1.Checked : radioButton2.Checked;
                    nv.NgaySinh = this.dateTimePicker1_NgaySinh.Value;
                    nv.LaQuanTriVien = this.checkBox1.Checked;
                    
                    return nv;
                default:
                    return null;
            }
        }

        private void EditMode(bool _Edit = false)
        {
            button5_SaveChange.Enabled = button8_Cancel.Enabled = _Edit;
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

        private void button2_Reset_Click(object sender, EventArgs e)
        {
            SQL.ListData.Fill.AllToDataGridView(eTypeManage.ToString(), ref this.dataGridView1);
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
            this.button6_Delete.Enabled = true;
            this.button4_Edit.Enabled = true;
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
                    if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NguoiDung(this.textBox2_SoCMND.Text))
                    {
                        if (DialogResult.OK == 
                            MessageBox.Show(
                                "Bản ghi hiện tại đang liên kết với các bản ghi khác\nBạn có muốn xoá (hoặc thay đổi) nội dung của tất cả các bản ghi trong trong csdl không?",
                                "Cảnh báo thay đổi", MessageBoxButtons.OKCancel))
                        {
                            // xoá bản ghi trong nhân viên _ ngân hàng
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NguoiDung_NganHang(
                                SQL.Struct.NguoiDung_NganHang.eNguoiDung_NganHang.SoCMND,
                                this.textBox2_SoCMND.Text))
                            {
                                sErrorMesage += "\n- Không thể xoá bản ghi trong table NhanVien_NganHang!";
                            }
                            else
                                sErrorMesage += "\n- Xoá bản ghi trong table NhanVien_NganHang thành công!";

                            // sửa bản ghi trong bảng mượn sách
                            if (!SQL.ListData.GetDataFromSQL.MuonSach_UpdateAllRecord_HaveTableX(SQL.Struct.MuonSach.eMuonSach.SoCMND,
                                "null", SQL.Struct.MuonSach.eMuonSach.SoCMND, this.textBox2_SoCMND.Text))
                            {
                                sErrorMesage += "\n- Không thể sửa bản ghi trong table MuonSach!";
                            }
                            else
                                sErrorMesage += "\n- Sửa bản ghi trong table MuonSach thành công!";

                            // xoá trong bảng người dùng
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NguoiDung(this.textBox2_SoCMND.Text))
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
                    if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NhanVien(this.textBox3_TenDangNhap.Text))
                    {
                        if (DialogResult.OK ==
                            MessageBox.Show(
                                "Bản ghi hiện tại đang liên kết với các bản ghi khác\nBạn có muốn xoá (hoặc thay đổi) nội dung của tất cả các bản ghi trong trong csdl không?",
                                "Cảnh báo thay đổi", MessageBoxButtons.OKCancel))
                        {
                            // Nhân viên: xoá bảng nhân viên _ ngân hàng, sửa bảng nhận sách + mượn sách

                            // xoá trong bảng nhân viên _ ngân hàng
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NhanVien_NganHang(SQL.Struct.NhanVien_NganHang.eNhanVien_NganHang.MaNhanVien, this.textBox3_TenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể xoá bản ghi trong table NhanVien_NganHang!";
                            }
                            else
                            {
                                sErrorMesage += "\n- Xoá bản ghi trong table NhanVien_NganHang thành công!";
                            }

                            // sửa trong bảng nhận sách
                            if (!SQL.ListData.GetDataFromSQL.NhanSach_UpdateAllRecord_HaveTableX(SQL.Struct.NhanSach.eNhanSach.MaNhanVien,
                                "null", SQL.Struct.NhanSach.eNhanSach.MaNhanVien, this.textBox3_TenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể sửa bản ghi trong table MuonSach!";
                            }
                            else
                                sErrorMesage += "\n- Sửa bản ghi trong table MuonSach thành công!";

                            // sửa trong bảng mượn sách
                            if (!SQL.ListData.GetDataFromSQL.MuonSach_UpdateAllRecord_HaveTableX(SQL.Struct.MuonSach.eMuonSach.MaNhanVien,
                                "null", SQL.Struct.MuonSach.eMuonSach.MaNhanVien, this.textBox3_TenDangNhap.Text))
                            {
                                sErrorMesage += "\n- Không thể sửa bản ghi trong table MuonSach!";
                            }
                            else
                                sErrorMesage += "\n- Sửa bản ghi trong table MuonSach thành công!";

                            // xoá bản ghi trong table nhân viên
                            if (!SQL.ListData.GetDataFromSQL.DeleteRecord_NhanVien(this.textBox3_TenDangNhap.Text))
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
                        this.textBox3_TenDangNhap.Enabled = true;
                        EmptyInput(ref lTextbox);
                        break;

                    case EnumMyStruct.NhanVien:
                        EmptyInput(ref lTextbox);
                        this.textBox3_TenDangNhap.Text = SQL.ListData.GetDataFromSQL.NhanVien_GetNext_MaNhanVien();
                        break;

                    default:
                        break;
                }
                bSaveNewRecord = true;
                EditMode(true);
                this.button3_AddNew.Text = "Lưu bản ghi mới";
                this.button4_Edit.Enabled = false;
                this.button5_SaveChange.Enabled = false;
                this.button6_Delete.Enabled = false;
                this.dataGridView1.Enabled = false;
            }
            else
            {
                // lưu bản ghi mới
                switch (eTypeManage)
                {
                    case EnumMyStruct.NguoiDung:
                        SQL.Struct.NguoiDung nd = AddDataToObject(EnumMyStruct.NguoiDung) as SQL.Struct.NguoiDung;
                        if (SQL.ListData.GetDataFromSQL.NguoiDung_AddNewRecord(nd))
                        {
                            MessageBox.Show("Tạo bản ghi mới thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Tạo bản ghi thất bại!");
                        }

                        this.textBox3_TenDangNhap.Enabled = false;
                        break;

                    case EnumMyStruct.NhanVien:
                        SQL.Struct.NhanVien nv = AddDataToObject(EnumMyStruct.NhanVien) as SQL.Struct.NhanVien;
                        if(SQL.ListData.GetDataFromSQL.NhanVien_AddNewRecord(nv))
                        {
                            MessageBox.Show("Tạo bản ghi mới thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Tạo bản ghi thất bại!");
                        }
                        break;

                    default:
                        break;
                }
                bSaveNewRecord = false;
                this.button3_AddNew.Text = "Thêm mới";
                this.button8_Cancel_Click(sender, e);
                this.dataGridView1.Enabled = true;
            }
        }

        private void button5_SaveChange_Click(object sender, EventArgs e)
        {
            switch (eTypeManage)
            {
                case EnumMyStruct.NguoiDung:
                    SQL.Struct.NguoiDung nd = AddDataToObject(EnumMyStruct.NguoiDung) as SQL.Struct.NguoiDung;
                    if(!SQL.ListData.GetDataFromSQL.Update_NguoiDung(nd))
                    {
                        MessageBox.Show("Không thể update bản ghi");
                    }
                    break;
                case EnumMyStruct.NhanVien:
                    SQL.Struct.NhanVien nv = AddDataToObject(EnumMyStruct.NhanVien) as SQL.Struct.NhanVien;
                    if (!SQL.ListData.GetDataFromSQL.Update_NhanVien(nv))
                    {
                        MessageBox.Show("Không thể update bản ghi");
                    }
                    break;
                default:
                    break;
            }
            button2_Reset_Click(sender, e);
        }

        private void button1_Find_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1_FindTextbox.Text))
            {
                Usefull_Function.Find(this.textBox1_FindTextbox.Text, ref dataGridView1, new List<int>() {0, 1, 2, 3, 4, 5, 6 });
            }
        }
    }
}
