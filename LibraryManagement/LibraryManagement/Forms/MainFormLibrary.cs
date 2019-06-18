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
using LibraryManagement.SQL.Struct;
using System.Data.Common;
using LibraryManagement.SQL.ListData;

namespace LibraryManagement.Forms
{
    public partial class MainFormLibrary : Form
    {
        private static int UserEmployeeAdmin;
        private static object Data;
        public static Forms.ManageBook formManageBook;
        public static Forms.Manage_UserEmployee formManageUserEmployee;
        public static Forms.GiveBackBook formGiveBackBook;


        public MainFormLibrary(object ob)
        {
            InitializeComponent();
            HideEditInfomations(false);
            //this.MaximizeBox = false;

            Data = ob;
            UserEmployeeAdmin = LoginFormLibraryManagement.UserEmployeeAdmin;

            LoadInfo();
            HideForUser(UserEmployeeAdmin);
        }

        public void LoadInfo()
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            switch (UserEmployeeAdmin)
            {
                case -1:

                    NguoiDung nd = Data as NguoiDung;
                    Data = nd = SQL.ListData.GetDataFromSQL.Select_NguoiDung(SQL.Struct.NguoiDung.eNguoiDung.TenDangNhap, nd.TenDangNhap);
                    _pathAvatar = nd.DuongDanAnhDaiDien;
                    AddDataToTextBox(nd.TenDangNhap, nd.SoCMND, nd.HoTen,
                        nd.NgaySinh.ToShortDateString().ToString(), nd.SoDienThoai, 
                        nd.DiaChiThuongTru, nd.GioiTinh,nd.TenNguoiBaoHo,nd.SDTNguoiBaoHo,
                        nd.DiaChiNguoiBaoHo,nd.DuongDanAnhDaiDien);
                    break;
                case 0:
                case 1:
                    NhanVien nv = Data as NhanVien;
                    Data = nv = SQL.ListData.GetDataFromSQL.Select_NhanVien(SQL.Struct.NhanVien.eNhanVien.MaNhanVien, nv.MaNhanVien);
                    _pathAvatar = nv.DuongDanAnhDaiDien;
                    AddDataToTextBox(nv.MaNhanVien, nv.SoCMND, nv.TenNhanVien,
                        nv.NgaySinh.ToShortDateString().ToString(),
                        nv.SoDienThoai, nv.DiaChi,nv.GioiTinh,"","","",nv.DuongDanAnhDaiDien);
                    break;
                default:
                    break;
            }
            /*
             Tên đăng nhập
             Số cmnd
             Họ tên
             Ngày sinh
             Số điẹn thoại
             Địa chỉ
             Giới tính
             */
        }

        private void AddDataToTextBox(string TenDangNhap, string SoCMND,
            string HoTen, string NgaySinh, string SoDienThoai, string DiaChi, bool GioiTinh,
            string TenNguoiBaoHo = "", string SDTNguoiBaoHo = "", string DiaChiNguoiBaoHo = "",
            string pathAvatar = "")
        {
            this.textBox1.Text = TenDangNhap;
            this.textBox2.Text = SoCMND;
            this.textBox3.Text = HoTen;
            this.textBox4.Text = NgaySinh;
            this.textBox5.Text = SoDienThoai;
            this.textBox6.Text = DiaChi;
            this.textBox7.Text = TenNguoiBaoHo;
            this.textBox8.Text = SDTNguoiBaoHo;
            this.textBox9.Text = DiaChiNguoiBaoHo;
            if (GioiTinh)
            {
                this.radioButton1_Click(new object(), new EventArgs());
            }
            else
            {
                this.radioButton2_Click(new object(), new EventArgs());
            }

            try
            {
                this.pictureAvatar.Image = Image.FromFile(pathAvatar);
            }
            catch
            {
                this.pictureAvatar.Image = Properties.Resources.NoAvartar;
            }
        }

        public void HideForUser(int typeUser)
        {
            switch (typeUser)
            {
                case -1:
                    // for normal user
                    this.buttonBookManage.Hide();
                    this.buttonUserManage.Hide();
                    this.buttonGiveBackBook.Hide();
                    this.buttonEmployeeManage.Hide();
                    break;
                case 0:
                    // for employee
                    this.buttonBookManage.Show();
                    // this.buttonUserManage.Enabled = false;
                    this.buttonGiveBackBook.Show();
                    this.buttonEmployeeManage.Hide();
                    this.buttonBorrowBook.Hide();
                    break;
                case 1:
                    // for admin
                    this.buttonBookManage.Show();
                    this.buttonUserManage.Show();
                    this.buttonGiveBackBook.Show();
                    this.buttonEmployeeManage.Show();
                    this.buttonBorrowBook.Hide();
                    break;
                default:
                    break;
            }
        }

        public void HideEditInfomations(bool IsAdmin = false)
        {
            switch (IsAdmin)
            {
                case true:
                    // this.textBox1.Enabled = true;
                    // this.textBox2.Enabled = true;
                    this.textBox3.Enabled = true;
                    this.textBox4.Enabled = true;
                    this.textBox5.Enabled = true;
                    this.textBox6.Enabled = true;
                    if (UserEmployeeAdmin < 0)
                    {
                        this.textBox7.Enabled = true;
                        this.textBox8.Enabled = true;
                        this.textBox9.Enabled = true;
                    }
                    else
                    {
                        this.label8.Hide();
                        this.label9.Hide();
                        this.label10.Hide();
                        this.textBox7.Hide();
                        this.textBox8.Hide();
                        this.textBox9.Hide();
                    }
                    
                    this.radioButton1.Enabled = true;
                    this.radioButton2.Enabled = true;
                    this.buttonChangeAvatar.Show();
                    this.buttonChangePassword.Show();
                    this.buttonUpdateInfo.Show();
                    this.buttonCancel.Show();

                    this.dateTimePicker1.Enabled = true;

                    break;
                default:
                    // this.textBox1.Enabled = false;
                    // this.textBox2.Enabled = false;
                    this.textBox3.Enabled = false;
                    this.textBox4.Enabled = false;
                    this.textBox5.Enabled = false;
                    this.textBox6.Enabled = false;

                    if (UserEmployeeAdmin < 0)
                    {
                        this.textBox7.Enabled = false;
                        this.textBox8.Enabled = false;
                        this.textBox9.Enabled = false;
                    }
                    else
                    {
                        this.label8.Hide();
                        this.label9.Hide();
                        this.label10.Hide();
                        this.textBox7.Hide();
                        this.textBox8.Hide();
                        this.textBox9.Hide();
                    }
                    
                    this.radioButton1.Enabled = false;
                    this.radioButton2.Enabled = false;
                    this.buttonChangeAvatar.Hide();
                    this.buttonChangePassword.Hide();
                    this.buttonUpdateInfo.Hide();
                    this.buttonCancel.Hide();

                    this.dateTimePicker1.Enabled = false;
                    break;
            }
        }

        private void MainFormLibrary_FormClosed(object sender, FormClosedEventArgs e)
        {
            // LibraryManagement.Program.formm.Show();
            Application.Exit();
            // this.Dispose();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LibraryManagement.Program.formm.Show();
            LibraryManagement.Program.formm.ResetInput();
            this.Dispose();
        }

        private void buttonChangeInfo_Click(object sender, EventArgs e)
        {
            LoadInfo();
            HideEditInfomations(true);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.radioButton2.Checked = false;
            this.radioButton1.Checked = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            HideEditInfomations(false);
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            PasswordChangingForm c = new PasswordChangingForm(UserEmployeeAdmin, Data);
            c.Show();
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            switch (UserEmployeeAdmin)
            {
                case -1:
                    NguoiDung t = Data as NguoiDung;
                    t.HoTen = this.textBox3.Text;
                    t.NgaySinh = DateTime.Parse(this.textBox4.Text);
                    t.SoDienThoai = this.textBox5.Text;
                    t.DiaChiThuongTru = this.textBox6.Text;
                    t.GioiTinh = this.radioButton1.Checked ? true : false;
                    t.TenNguoiBaoHo = this.textBox7.Text;
                    t.SDTNguoiBaoHo = this.textBox8.Text;
                    t.DiaChiNguoiBaoHo = this.textBox9.Text;
                    t.DuongDanAnhDaiDien = _pathAvatar;

                    SQL.ListData.GetDataFromSQL.Update_NguoiDung(t);

                    Data = t;

                    MessageBox.Show("Update success!");
                    break;
                case 0:
                case 1:
                    NhanVien nv = Data as NhanVien;
                    nv.TenNhanVien = this.textBox3.Text;
                    nv.NgaySinh = DateTime.Parse(this.textBox4.Text);
                    nv.SoDienThoai = this.textBox5.Text;
                    nv.DiaChi = this.textBox6.Text;
                    nv.GioiTinh = this.radioButton1.Checked ? true : false;
                    nv.DuongDanAnhDaiDien = _pathAvatar;

                    SQL.ListData.GetDataFromSQL.Update_NhanVien(nv);

                    Data = nv;
                    
                    MessageBox.Show("Update success!");
                    break;
                default:
                    break;
            }
            buttonCancel_Click(new object(), new EventArgs());
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox4.Text = this.dateTimePicker1.Value.ToShortDateString().ToString();
        }

        private static string _pathAvatar;
        private void buttonChangeAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog t = new OpenFileDialog();
            if (t.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show(t.FileName);
                Image ima = Image.FromFile(t.FileName);
                this.pictureAvatar.Image = ima;
                _pathAvatar = t.FileName;
            }
            
        }

        private void buttonBorrowBook_Click(object sender, EventArgs e)
        {
            Forms.BorrowBook t = new BorrowBook(textBox2.Text);
            t.Show();
            this.Hide();
        }

        private void buttonBookManage_Click(object sender, EventArgs e)
        {
            formManageBook = new Forms.ManageBook();
            formManageBook.Show();
            this.Hide();
        }

        private void buttonUserManage_Click(object sender, EventArgs e)
        {
            formManageUserEmployee = new Forms.Manage_UserEmployee(EnumMyStruct.NguoiDung);
            formManageUserEmployee.Show();
            this.Hide();
        }

        private void buttonManageEmployee_Click(object sender, EventArgs e)
        {
            formManageUserEmployee = new Forms.Manage_UserEmployee(EnumMyStruct.NhanVien);
            formManageUserEmployee.Show();
            this.Hide();
        }

        private void buttonGiveBackBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            formGiveBackBook = new GiveBackBook();
            formGiveBackBook.Show();
        }

        private void MainFormLibrary_Load(object sender, EventArgs e)
        {
        }
    }
}
