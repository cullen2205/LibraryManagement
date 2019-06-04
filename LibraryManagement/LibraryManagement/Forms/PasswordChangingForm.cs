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
using LibraryManagement;
using LibraryManagement.SQL.Struct;

namespace LibraryManagement.Forms
{
    public partial class PasswordChangingForm : Form
    {
        private int iTypeUser;
        private object Data;
        private string strOldPass;
        public PasswordChangingForm(int typeUser, object ob)
        {
            InitializeComponent();
            this.UsernameTextbox.Enabled = false;
            this.Data = ob;
            this.iTypeUser = typeUser;

            LoadEmployee();
        }

        private void LoadEmployee()
        {
            string IDLogin = "";
            switch (iTypeUser)
            {
                case -1:
                    NguoiDung nd = Data as NguoiDung;
                    strOldPass = nd.MatKhau;
                    IDLogin = nd.TenDangNhap;
                    break;
                case 0:
                case 1:
                    NhanVien nv = Data as NhanVien;
                    strOldPass = nv.MatKhau;
                    IDLogin = nv.MaNhanVien;
                    break;
                default:
                    return;
            }

            this.UsernameTextbox.Text = IDLogin;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (OldPasswordTextbox.Text == strOldPass)
            {
                if(NewPasswordTextbox.Text == RepeatNewPasswordTextbox.Text)
                {
                    // Update dữ liệu
                    switch (iTypeUser)
                    {
                        case -1:
                            SQL.ListData.GetDataFromSQL.Update_OneTable_NguoiDung(
                                "string", SQL.Struct.NguoiDung.eNguoiDung.MatKhau, NewPasswordTextbox.Text,
                                SQL.Struct.NguoiDung.eNguoiDung.TenDangNhap, this.UsernameTextbox.Text);
                            break;
                        case 0:
                        case 1:
                            SQL.ListData.GetDataFromSQL.Update_OneTable_NhanVien(
                                "string", SQL.Struct.NhanVien.eNhanVien.MatKhau, NewPasswordTextbox.Text,
                                SQL.Struct.NhanVien.eNhanVien.MaNhanVien, this.UsernameTextbox.Text);
                            break;
                        default:
                            break;
                    }

                    MessageBox.Show("Đổi mật khẩu thành công!");
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không trùng lặp!");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
            }
                
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            LibraryManagement.Forms.LoginFormLibraryManagement.mainForm.Enabled = true;
            Close();
        }

        private void PasswordChangingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LibraryManagement.Forms.LoginFormLibraryManagement.mainForm.Enabled = true;
        }
    }
}
