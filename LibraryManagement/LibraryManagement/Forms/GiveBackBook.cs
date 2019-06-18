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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Xceed.Words.NET;

namespace LibraryManagement.Forms
{
    public partial class GiveBackBook : Form
    {
        List<string> lBookGiveBack = new List<string>();
        List<string> lMuonSach = new List<string>();
        private DbLibraryManagement db = new DbLibraryManagement();
        public GiveBackBook()
        {
            InitializeComponent();
            
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.MaximizeBox = false;
        }
        #region MY STRUCT - CLASS
        private class MySach
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public MySach()
            {

            }

            [Key]
            [StringLength(40)]
            public string MaSach { get; set; }

            [StringLength(100)]
            public string TenSach { get; set; }

            [StringLength(100)]
            public string TacGia { get; set; }

            public int? NamXuatBan { get; set; }

            public int? Gia { get; set; }

            [StringLength(100)]
            public string NhaXuatBan { get; set; }

            public int? GioiHanTuoi { get; set; }

            [Column(Order = 1, TypeName = "date")]
            public DateTime NgayMuon { get; set; }

            [Column(TypeName = "date")]
            public DateTime? NgayTra { get; set; }

            [StringLength(40)]
            public string SoCMND { get; set; }

            [StringLength(40)]
            public string MaNhanVien { get; set; }
        }
        #endregion
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
        _source.Rows[_index].Cells["NgayMuon"].Value.ToString(),
        _source.Rows[_index].Cells["NgayTra"].Value.ToString(),
        _source.Rows[_index].Cells["SoCMND"].Value.ToString(),
        _source.Rows[_index].Cells["MaNhanVien"].Value.ToString()
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

            this.dataGridView1.Columns[this.dataGridView2.Columns.Add(@"NgayMuon", @"Ngày mượn")].DataPropertyName = @"NgayMuon";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"NgayTra", @"Ngày phải trả")].DataPropertyName = @"NgayTra";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"SoCMND", @"Số CMND người mượn")].DataPropertyName = @"SoCMND";
            this.dataGridView2.Columns[this.dataGridView2.Columns.Add(@"MaNhanVien", @"Mã nhân viên")].DataPropertyName = @"MaNhanVien";

            lMuonSach = SQL.ListData.GetDataFromSQL.MuonSach_GetOneColumn("MuonSach", "MaSach");
            RemoveSameValue(ref lMuonSach);

            btnRefresh_Click(sender, e);
        }

        private void btn1_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.tb1_Search.Text))
            {
                btnRefresh_Click(sender, e);
                Usefull_Function.Find(this.tb1_Search.Text, ref dataGridView1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Đổ dữ liêu vào datagridview
            //BindingList<MySach> lms = new BindingList<MySach>(db.Database.SqlQuery<MySach>("select ms.MaSach, ms.NgayMuon, ms.NgayTra, ms.SoCMND, ms.MaNhanVien, s.TenSach, s.TacGia, s.NamXuatBan, s.Gia, s.NhaXuatBan, s.GioiHanTuoi from Sach s, MuonSach ms where s.MaSach = ms.MaSach").ToList());
            //dataGridView1.DataSource = lms;
            dataGridView1.DataSource = new System.Collections.ObjectModel.ObservableCollection<MySach>(db.Database.SqlQuery<MySach>("select ms.MaSach, ms.NgayMuon, ms.NgayTra, ms.SoCMND, ms.MaNhanVien, s.TenSach, s.TacGia, s.NamXuatBan, s.Gia, s.NhaXuatBan, s.GioiHanTuoi from Sach s, MuonSach ms where s.MaSach = ms.MaSach").ToList()).ToBindingList();

            // xoá những dòng đã có bên dataGridView con, lặp tất cả các phần tử của List
            for (int i = 0; i < lBookGiveBack.Count; i++)
            {
                RemoveRow(ref this.dataGridView1, @"MaSach", lBookGiveBack[i]);
            }
        }

        private void btnGiveBackAll_Click(object sender, EventArgs e)
        {
            string sErrorMessage = "Kết quả:\n\n";
            string sBill = "Trả sách trễ:\n\n";
            bool bBill = false;
            List<string>[] l = new List<string>[7];
            /*
             0. ngày mượn
             1. ngày trả
             2. tên sách
             3. ngày trễ
             4. mã nhân viên
             5. tên nhân viên
             6. tên người dùng
             */
            for (int i = 0; i < 7; i++)
            {
                l[i] = new List<string>();
            }

            for (int i = 0; i < lBookGiveBack.Count; i = 0)
            {
                if(SQL.ListData.GetDataFromSQL.MuonSach_RemoveOneRecord(lBookGiveBack[i]))
                {
                    sErrorMessage += "\n- Trả sách có mã " + lBookGiveBack[i] + " thành công!";
                    DateTime ngaytra = DateTime.Parse(dataGridView2.Rows[0].Cells["NgayTra"].Value.ToString());
                    TimeSpan ngaytre = DateTime.Now - ngaytra;
                    if (ngaytre.Days > 0)
                    {
                        bBill = true;
                        sBill += "\n- Sách có mã: " + lBookGiveBack[i] + " trễ " + ngaytre.Days + " ngày!\nSố tiền phạt (1000 đồng/ngày): " + (ngaytre.Days * 1000) + "\n";
                        l[0].Add(dataGridView2.Rows[0].Cells["NgayMuon"].Value.ToString());
                        l[1].Add(dataGridView2.Rows[0].Cells["NgayTra"].Value.ToString());
                        l[2].Add(dataGridView2.Rows[0].Cells["TenSach"].Value.ToString());
                        l[3].Add(ngaytre.Days.ToString());
                        l[4].Add(dataGridView2.Rows[0].Cells["MaNhanVien"].Value.ToString());
                        l[5].Add(db.Database.SqlQuery<string>("SELECT TOP 1 TenNhanVien FROM NhanVien WHERE MaNhanVien = N'" + dataGridView2.Rows[0].Cells["MaNhanVien"].Value as string + "'").SingleOrDefault());
                        l[6].Add(db.Database.SqlQuery<string>("SELECT TOP 1 HoTen FROM NguoiDung WHERE SoCMND = N'" + dataGridView2.Rows[0].Cells["SoCMND"].Value as string + "'").SingleOrDefault());
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
                if(DialogResult.Yes == MessageBox.Show(sBill, "Bạn có muốn in hoá đơn trả sách trễ không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    // biến này để lưu dữ liệu trong temp.doc
                    DocX temp;
                    try
                    {
                        temp = DocX.Load(System.AppDomain.CurrentDomain.BaseDirectory + "temp.docx");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể load tập tin temp.docx, xin hãy kiểm tra lại thư mục chủ!");
                        return;
                    }
                    // copy nội dung trong temp.doc vào để tạo file mới
                    DocX val = temp.Copy();

                    // thêm tên nhân viên
                    val.ReplaceText(@"<#TENNHANVIEN>", l[5][0]);

                    // thêm mã nhân viên
                    val.ReplaceText(@"<#MANHANVIEN>", l[4][0]);

                    // thêm tên người mượn
                    val.ReplaceText(@"<#TENNGUOIDUNG>", l[6][0]);

                    // thêm ngày trả sách
                    val.ReplaceText(@"<#NGAYTRASACH>", DateTime.Now.ToString());

                    // thêm cột vào tập .doc
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if( l[i].Count > j )
                                        val.ReplaceText(@"<#A" + j + @">", l[i][j]);
                                    else
                                        val.ReplaceText(@"<#A" + j + @">", "");
                                    break;
                                case 1:
                                    if (l[i].Count > j)
                                        val.ReplaceText(@"<#B" + j + @">", l[i][j]);
                                    else
                                        val.ReplaceText(@"<#B" + j + @">", "");
                                    break;
                                case 2:
                                    if (l[i].Count > j)
                                        val.ReplaceText(@"<#C" + j + @">", l[i][j]);
                                    else
                                        val.ReplaceText(@"<#C" + j + @">", "");
                                    break;
                                case 3:
                                    if (l[i].Count > j)
                                        val.ReplaceText(@"<#D" + j + @">", l[i][j]);
                                    else
                                        val.ReplaceText(@"<#D" + j + @">", "");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    FolderBrowserDialog t;
                    if (DialogResult.OK == MessageBox.Show("Chọn nơi lưu (chọn 'ok' nếu muốn tiếp tục, ngược lại 'cancel' sẽ không lưu)", "Lưu tập tin", MessageBoxButtons.OKCancel))
                    {
                        // chọn nơi lưu
                        t = new FolderBrowserDialog();
                        while (string.IsNullOrWhiteSpace(t.SelectedPath))
                        {
                            t.ShowDialog();
                            if (!string.IsNullOrWhiteSpace(t.SelectedPath))
                            {
                                val.SaveAs(t.SelectedPath + l[4][0] + ".docx");
                                break;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                    

                    if (DialogResult.Yes == MessageBox.Show("Lưu thành công tại đường dẫn: " + t.SelectedPath + l[4][0] + ".docx", "Bạn có muốn mở tập tin không?", MessageBoxButtons.YesNo))
                    {
                        var th = new System.Threading.Thread(() => 
                        {
                            System.Diagnostics.Process.Start("WINWORD.EXE", t.SelectedPath + l[4][0] + ".docx");
                        });
                        th.IsBackground = true;
                        th.Start();
                    }

                    //--
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView2.RowCount - 1 | e.RowIndex < 0)
            {
                return;
            }
            // xoá phần từ vừa bấm trong lBookGiveBack
            lBookGiveBack.Remove(this.dataGridView2.Rows[e.RowIndex].Cells["MaSach"].Value.ToString());

            // xoá phần từ đã click ở datagrview vừa bấm
            this.dataGridView2.Rows.RemoveAt(e.RowIndex);
            btnRefresh_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView1.RowCount - 1 | e.RowIndex < 0)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            GiveBackBook_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        private void GiveBackBook_SizeChanged(object sender, EventArgs e)
        {
            panel4.Size = new Size(this.Size.Width - 570, panel4.Size.Height);
        }
    }
}
