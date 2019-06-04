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
    public partial class GiveBackBook : Form
    {
        List<string> lBookGiveBack = new List<string>();
        List<string> lMuonSach = new List<string>();
        public GiveBackBook()
        {
            InitializeComponent();

            this.dataGridView1.ReadOnly = true;
            this.dataGridView2.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MaximizeBox = false;
        }
        /// <summary>
        /// 
        /// Thêm dữ liệu từ datagridview cha vào datagridview con
        /// 
        /// </summary>
        /// <param name="_source"></param>
        /// <param name="_endPoint"></param>
        /// <param name="_index"></param>
        private void AddToDataGridView(ref DataGridView _source, ref DataGridView _endPoint, int _index)
        {
            _endPoint.Rows.Add(
        _source.Rows[_index].Cells["MaSach"].Value.ToString(),
        _source.Rows[_index].Cells["TenSach"].Value.ToString(),
        _source.Rows[_index].Cells["TacGia"].Value.ToString(),
        _source.Rows[_index].Cells["NamXuatBan"].Value.ToString(),
        _source.Rows[_index].Cells["Gia"].Value.ToString(),
        _source.Rows[_index].Cells["NhaXuatBan"].Value.ToString(),
        _source.Rows[_index].Cells["NgayTra"].Value.ToString()
        );
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
        private void RemoveSameValue(ref List<string> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = l.Count - 1; j > i; j--)
                {
                    if (string.Equals(l[i], l[j]))
                    {
                        l.RemoveAt(j);
                    }
                }
            }
        }

        private void GiveBackBook_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"MaSach", @"Mã sách")].DataPropertyName = @"MaSach";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"NgayMuon", @"Ngày mượn")].DataPropertyName = @"NgayMuon";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"NgayTra", @"Ngày trả")].DataPropertyName = @"NgayTra";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"SoCMND", @"Số CMND người mượn")].DataPropertyName = @"SoCMND";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"MaNhanVien", @"Mã nhân viên")].DataPropertyName = @"MaNhanVien";

            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"TenSach", @"Tên sách")].DataPropertyName = @"TenSach";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"TacGia", @"Tác giả")].DataPropertyName = @"TacGia";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"NamXuatBan", @"Năm xuất bản")].DataPropertyName = @"NamXuatBan";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"Gia", @"Giá")].DataPropertyName = @"Gia";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"NhaXuatBan", @"Nhà xuất bản")].DataPropertyName = @"NhaXuatBan";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Add(@"GioiHanTuoi", @"Giới hạn tuổi")].DataPropertyName = @"GioiHanTuoi";

            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"MaSach", @"Mã sách")].DataPropertyName = @"MaSach";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"TenSach", @"Tên sách")].DataPropertyName = @"TenSach";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"TacGia", @"Tác giả")].DataPropertyName = @"TacGia";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"NamXuatBan", @"Năm xuất bản")].DataPropertyName = @"NamXuatBan";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"Gia", @"Giá")].DataPropertyName = @"Gia";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"NhaXuatBan", @"Nhà xuất bản")].DataPropertyName = @"NhaXuatBan";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"NgayTra", @"Ngày phải trả")].DataPropertyName = @"NgayTra";

            lMuonSach = SQL.ListData.GetDataFromSQL.MuonSach_GetOneColumn("MuonSach", "MaSach");
            RemoveSameValue(ref lMuonSach);

            btn2_Refresh_Click(sender, e);
        }

        private void btn1_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.tb1_Search.Text))
            {
                Usefull_Function.Find(this.tb1_Search.Text, ref dataGridView1, new List<int>() {0, 1, 2, 3, 4, 5, 6 });
            }
        }

        private void btn2_Refresh_Click(object sender, EventArgs e)
        {
            // Đổ dữ liêu vào datagridview
            SQL.ListData.Fill.SomeToDataGridView("select ms.MaSach, ms.NgayMuon, ms.NgayTra, ms.SoCMND, ms.MaNhanVien, s.TenSach, s.TacGia, s.NamXuatBan, s.Gia, s.NhaXuatBan, s.GioiHanTuoi from Sach s, MuonSach ms where s.MaSach = ms.MaSach", ref this.dataGridView1);

            // xoá những dòng đã có bên dataGridView con, lặp tất cả các phần tử của List
            for (int i = 0; i < lBookGiveBack.Count; i++)
            {
                RemoveRow(ref this.dataGridView1, @"MaSach", lBookGiveBack[i]);
            }
        }

        private void btn3_GiveBackAll_Click(object sender, EventArgs e)
        {
            string sErrorMessage = "Kết quả:\n\n";
            string sBill = "Trả sách trễ:\n\n";
            bool bBill = false;
            for (int i = 0; i < lBookGiveBack.Count; i = 0)
            {
                if(SQL.ListData.GetDataFromSQL.MuonSach_RemoveOneRecord(lBookGiveBack[i]))
                {
                    sErrorMessage += "\n- Trả sách có mã " + lBookGiveBack[i] + " thành công!";
                    TimeSpan ngaytre = DateTime.Now - DateTime.Parse(dataGridView2.Rows[0].Cells["NgayTra"].Value.ToString());
                    if (ngaytre.Days > 0)
                    {
                        bBill = true;
                        sBill += "\n- Sách có mã: " + lBookGiveBack[i] + " trễ " + ngaytre.Days + " ngày!\nSố tiền phạt (1000 đồng/ngày): " + (ngaytre.Days * 1000) + "\n";
                    }
                }
                else
                {
                    sErrorMessage += "\n- Thất bại trả sách có mã " + lBookGiveBack[i];
                }
                
                lBookGiveBack.RemoveAt(0);
                this.dataGridView2.Rows.RemoveAt(0);
            }
            MessageBox.Show(sErrorMessage);
            if (bBill)
            {
                MessageBox.Show(sBill);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView2.RowCount - 1 || e.RowIndex < 0)
            {
                return;
            }
            // xoá phần từ vừa bấm trong lBookGiveBack
            lBookGiveBack.Remove(this.dataGridView2.Rows[e.RowIndex].Cells["MaSach"].Value.ToString());

            // xoá phần từ đã click ở datagrview vừa bấm
            this.dataGridView2.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView1.RowCount - 1 || e.RowIndex < 0)
            {
                return;
            }
            // thêm phần từ vừa bấm vào lListBook
            lBookGiveBack.Add(this.dataGridView1.Rows[e.RowIndex].Cells["MaSach"].Value.ToString());

            // thêm phần tử đó vào datagrview con
            AddToDataGridView(ref this.dataGridView1, ref this.dataGridView2, e.RowIndex);

            // xoá phần từ đã click ở datagrview vừa bấm
            this.dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void GiveBackBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.LoginFormLibraryManagement.mainForm.Show();
            this.Dispose();
        }
    }
}
