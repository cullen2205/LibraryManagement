using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.SQL.ListData;
using LibraryManagement.SQL.Struct;
using System.Data.SqlClient;
using System.Data.Common;

namespace LibraryManagement.Forms
{
    public partial class LoginFormLibraryManagement : Form
    {
        public static Forms.MainFormLibrary mainForm;
        public static int UserEmployeeAdmin { get; private set; }
        private static object DataUser;
        public LoginFormLibraryManagement()
        {
            InitializeComponent();
            //this.MaximizeBox = false;

            // DataFromSQL.GetALL();
        }

        public void ResetInput()
        {
            UsernameTextbox.Text = "";
            PasswordTextbox.Text = "";
            UsernameTextbox.Select();
        }

        private string HashPassword(string sText)
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(sText);
            Byte[] hash = new System.Security.Cryptography.SHA256CryptoServiceProvider().
                           ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

        public void UsernameTextbox_Click(object serder, EventArgs e)
        {
            UsernameTextbox.SelectAll();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextbox.Text)
                || string.IsNullOrEmpty(PasswordTextbox.Text))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị để trống. Xin hãy kiểm tra lại.");
                return;
            }

            // Kiểm tra trong mục nhân viên
            string pass = FindPassword(0, UsernameTextbox.Text);
            if (string.IsNullOrEmpty(pass))
            {
                // Kiểm tra tiếp trong mục người dùng
                pass = FindPassword(-1, UsernameTextbox.Text);
                if (!string.IsNullOrEmpty(pass))
                {
                    // MessageBox.Show("Success login NguoiDung");
                    this.Hide();

                    mainForm = new Forms.MainFormLibrary(DataUser);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");

                    // Trỏ đến username textbox
                    UsernameTextbox.Focus();

                    UsernameTextbox_Click(sender, e);

                    return;
                }

            }
            else if (pass == PasswordTextbox.Text)
            {
                // MessageBox.Show("Success login NhanVien");
                this.Hide();

                mainForm = new Forms.MainFormLibrary(DataUser);
                mainForm.Show();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string FindPassword(int typeU, string IDName)
        {
            switch (typeU)
            {
                case -1:
                    NguoiDung nd = SQL.ListData.GetDataFromSQL.Select_NguoiDung(SQL.Struct.NguoiDung.eNguoiDung.TenDangNhap, IDName);
                    DataUser = nd;
                    UserEmployeeAdmin = -1;
                    return nd.MatKhau;
                case 0:
                case 1:
                    NhanVien nv = SQL.ListData.GetDataFromSQL.Select_NhanVien(SQL.Struct.NhanVien.eNhanVien.MaNhanVien, IDName);
                    DataUser = nv;
                    UserEmployeeAdmin = nv.LaQuanTriVien ? 1 : 0;
                    return nv.MatKhau;
                default:
                    return null;
            }
        }

        private void UsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PasswordTextbox_KeyDown(sender, e);
            }
        }

        private void PasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LoginButton_Click(sender, new EventArgs());
            }
        }

        private void LoginFormLibraryManagement_Load(object sender, EventArgs e)
        {
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
