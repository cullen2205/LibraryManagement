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
    public partial class BorrowBook : Form
    {
        List<string> lMuonSach = new List<string>();
        List<string> lListBorrow = new List<string>();

        private string sSoCMND;
        public BorrowBook(string _SoCMND)
        {
            InitializeComponent();
            this.dataGridView1_ListBook.ReadOnly = true;
            this.dataGridView2_ListBorrow.ReadOnly = true;
            this.dataGridView1_ListBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2_ListBorrow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = new Size(990, 650);
            sSoCMND = _SoCMND;
        }

        private void BorrowBook_Load(object sender, EventArgs e)
        {
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"MaSach", @"Mã sách")].DataPropertyName = @"MaSach";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"TenSach", @"Tên sách")].DataPropertyName = @"TenSach";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"TacGia", @"Tác giả")].DataPropertyName = @"TacGia";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"NamXuatBan", @"Năm xuất bản")].DataPropertyName = @"NamXuatBan";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"Gia", @"Giá")].DataPropertyName = @"Gia";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"NhaXuatBan", @"Nhà xuất bản")].DataPropertyName = @"NhaXuatBan";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"GioiHanTuoi", @"Giới hạn tuổi")].DataPropertyName = @"GioiHanTuoi";
            this.dataGridView1_ListBook.Columns[this.dataGridView1_ListBook.Columns.Add(@"DuongDanAnhDaiDien", @"Đường dẫn ảnh")].DataPropertyName = @"DuongDanAnhDaiDien";

            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"MaSach", @"Mã sách")].DataPropertyName = @"MaSach";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"TenSach", @"Tên sách")].DataPropertyName = @"TenSach";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"TacGia", @"Tác giả")].DataPropertyName = @"TacGia";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"NamXuatBan", @"Năm xuất bản")].DataPropertyName = @"NamXuatBan";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"Gia", @"Giá")].DataPropertyName = @"Gia";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"NhaXuatBan", @"Nhà xuất bản")].DataPropertyName = @"NhaXuatBan";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"GioiHanTuoi", @"Giới hạn tuổi")].DataPropertyName = @"GioiHanTuoi";
            this.dataGridView2_ListBorrow.Columns[this.dataGridView2_ListBorrow.Columns.Add(@"DuongDanAnhDaiDien", @"Đường dẫn ảnh")].DataPropertyName = @"DuongDanAnhDaiDien";

            lMuonSach = SQL.ListData.GetDataFromSQL.MuonSach_GetOneColumn("MuonSach", "MaSach");
            RemoveSameValue(ref lMuonSach);

            button5_Refresh_Click(sender, e);
        }

        private void RemoveSameValue(ref List<string> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = l.Count - 1; j > i; j--)
                {
                    if (string.Equals(l[i],l[j]))
                    {
                        l.RemoveAt(j);
                    }
                }
            }
        }

        /// <summary>
        /// Xoá các phần tử trùng nhau
        /// </summary>
        /// <param name="d"></param>
        /// <param name="_nameTable"></param>
        /// <param name="_value"></param>
        private void RemoveRow(ref DataGridView d, string _nameTable, string _value)
        {
            for (int j = 0; j < d.RowCount; j++)
            {
                // so sánh giá trị
                if (string.Equals(d.Rows[j].Cells[_nameTable].Value, _value))
                {
                    d.Rows.RemoveAt(j);
                    return;
                }
            }
        }

        private void button5_Refresh_Click(object sender, EventArgs e)
        {
            // Đổ dữ liêu vào datagridview
            SQL.ListData.Fill.AllToDataGridView(@"Sach", ref this.dataGridView1_ListBook);

            // load lại danh sách đã mượn
            lMuonSach = SQL.ListData.GetDataFromSQL.MuonSach_GetOneColumn("MuonSach", "MaSach");
            RemoveSameValue(ref lMuonSach);

            // xoá những cuốn sách đã có trong danh sách mượn
            for (int i = 0; i < lMuonSach.Count; i++)
            {
                RemoveRow(ref this.dataGridView1_ListBook, @"MaSach", lMuonSach[i]);
            }

            // xoá những cuốn đã có trong danh sách con
            for (int i = 0; i < lListBorrow.Count; i++)
            {
                RemoveRow(ref this.dataGridView1_ListBook, @"MaSach", lListBorrow[i]);
            }
        }

        
        private void AddToDataGridView(ref DataGridView _source, ref DataGridView _endPoint, int _index)
        {
                _endPoint.Rows.Add(
            _source.Rows[_index].Cells["MaSach"].Value.ToString(),
            _source.Rows[_index].Cells["TenSach"].Value.ToString(),
            _source.Rows[_index].Cells["TacGia"].Value.ToString(),
            _source.Rows[_index].Cells["NamXuatBan"].Value.ToString(),
            _source.Rows[_index].Cells["Gia"].Value.ToString(),
            _source.Rows[_index].Cells["NhaXuatBan"].Value.ToString(),
            _source.Rows[_index].Cells["GioiHanTuoi"].Value.ToString(),
            _source.Rows[_index].Cells["DuongDanAnhDaiDien"].Value.ToString()
            );
        }

        private void dataGridView1_ListBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView1_ListBook.RowCount - 1 || e.RowIndex < 0)
            {
                return;
            }
            // thêm phần từ vừa bấm vào lListBorrow
            lListBorrow.Add(this.dataGridView1_ListBook.Rows[e.RowIndex].Cells["MaSach"].Value.ToString());
            
            // thêm phần tử đó vào datagrview con
            AddToDataGridView(ref this.dataGridView1_ListBook,ref this.dataGridView2_ListBorrow, e.RowIndex);

            // xoá phần từ đã click ở datagrview vừa bấm
            this.dataGridView1_ListBook.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridView2_ListBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView2_ListBorrow.RowCount - 1 || e.RowIndex < 0)
            {
                return;
            }
            // xoá phần từ vừa bấm trong lListBorrow
            lListBorrow.Remove(this.dataGridView2_ListBorrow.Rows[e.RowIndex].Cells["MaSach"].Value.ToString());

            // xoá phần từ đã click ở datagrview vừa bấm
            this.dataGridView2_ListBorrow.Rows.RemoveAt(e.RowIndex);

            this.button5_Refresh_Click(new object(), new EventArgs());
        }

        private void button4_Exit_Click(object sender, EventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }

        private void button6_Find_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox1_search.Text))
            {
                Usefull_Function.Find(this.textBox1_search.Text, ref dataGridView1_ListBook, new List<int>() {0, 1, 2, 3, 4, 5, 6 });
            }
        }

        private void BorrowBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }

        private void button3_Borrow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2_IDEmployee.Text))
            {
                MessageBox.Show("Xin hãy nhập mã nhân viên thực hiện giao dịch!");
                return;
            }

            SQL.Query.CommandText = "select MaNhanVien from NhanVien where MaNhanVien = N'" + textBox2_IDEmployee.Text + "'";
            object q = SQL.Query.ExecuteScalar();

            SQL.Query.CommandText = "select SoCMND from NguoiDung where SoCMND = N'" + sSoCMND + "'";
            object c = SQL.Query.ExecuteScalar();
            if (c == null)
            {
                MessageBox.Show("Nhân viên không thể thực hiện mượn sách!\n\nXin hãy tạo tài khoản dành cho người dùng để có thể mượn sách!");
                return;
            }
            if (q != null)
            {
                string sErrorMessage = "Thông báo:\n\n";
                SQL.Struct.MuonSach tt;

                if (string.IsNullOrWhiteSpace(sSoCMND))
                {
                    sErrorMessage += "\n- Bạn chưa cập nhật số CMND để có thể mượn sách!\nHãy cập nhật số CMND trước khi mượn!";
                }
                else
                {
                    for (int i = 0; i < lListBorrow.Count && dataGridView2_ListBorrow.Rows.Count > 0; i = 0)
                    {
                        tt = new SQL.Struct.MuonSach();
                        tt.MaSach = lListBorrow[i];
                        tt.NgayMuon = DateTime.Now;
                        tt.SoCMND = sSoCMND;
                        tt.MaNhanVien = textBox2_IDEmployee.Text;

                        if (SQL.ListData.GetDataFromSQL.MuonSach_CreateNewRecord(tt))
                        {
                            sErrorMessage += "\n- " + lListBorrow[i] + " đã được chuyển đến nhân viên thành công!";
                        }
                        else
                        {
                            sErrorMessage += "\n- Không thể thực hiện mượn " + lListBorrow[i] + "!";
                        }

                        lListBorrow.RemoveAt(0);
                        dataGridView2_ListBorrow.Rows.RemoveAt(0);
                    }
                }
                
                MessageBox.Show(sErrorMessage);
            }
            else
            {
                MessageBox.Show("\n- Không tồn tại mã nhân viên, xin hãy kiểm tra lại!");
                return;
            }
        }
    }
}
