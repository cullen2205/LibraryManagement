using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.SQL.ConnectSQL
{
    public class KenConnectSQL
    {
        KenConnectSQL()
        {
            GetConnect();
        }

        protected static SqlConnection SetSQLConnect_conn(string datasource, string database, string username, string password)
        {
            //
            // Data Source=DESKTOP-L2250;Initial Catalog=ThucTapNhom;Integrated Security=True
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                    + database + ";Persist Security Info=True"
                    + (username == null ? null : ";User ID=" + username)
                    + (password == null ? null : "; Password=" + password);

            // 
            try
            {
                return new SqlConnection(connString);
            }
            catch
            {
                MessageBox.Show("Cant create conn");
                return new SqlConnection();
            }
        }
        public static SqlConnection GetConnect()
        {
            //Forms.Loading ld = new Forms.Loading();
            //ld.SetValueRichTextBox(@"- Đang thực hiện kết nối đến cơ dở dữ liệu.");

            SqlConnection tam;
            try
            {
                tam = new SqlConnection(@"Data Source=" + System.Environment.MachineName.ToString()
                    + ";Initial Catalog=ThucTapNhom_Khai;Integrated Security=True");

                tam.Open();
                tam.Close();
                // ld.Dispose();
                return tam;
            }
            catch
            {
                MessageBox.Show("Have no database name ThucTapNhom...\nErrorID:VKxxxxx0123.");
                Application.Exit();

                return null;


                // Tạo mới cơ sở dữ liệu (database) nếu mặc định chưa tồn tại
                // ld.SetValueRichTextBox(@"- Chưa có cơ sở dữ liệu, đang khởi tạo cơ sở dữ liệu lần đầu...");
                String str;
                SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

                str = "CREATE DATABASE ThucTapNhom_Khai";

                SqlCommand myCommand = new SqlCommand(str, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ld.SetValueRichTextBox(@"- Không thể tạo csdl. Mã lỗi: VKxxxxxxx1203!");
                    Application.Exit();
                    return null;
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }

                // Tạo bảng
                myConn = new SqlConnection(@"Data Source=" + System.Environment.MachineName.ToString()
                    + ";Initial Catalog=ThucTapNhom_Khai;Integrated Security=True");

                string[] ttt = defaultCreateDatabase_ThucTapNhom_Khai.Split(new string[] { "go" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ttt.Count<string>(); i++)
                {
                    try
                    {
                        myConn.Open();
                        myCommand.CommandText = ttt[i];
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                        //ld.SetValueRichTextBox(@"Create table success!");
                    }
                    catch
                    {
                        myConn.Close();
                        //ld.SetValueRichTextBox(@"Create table failed!");
                    }
                }
                // Tạo dữ liệu trong bảng
                string[] qqq = defaultData_ThucTapNhom_Khai.Split(new string[] { "go" }, StringSplitOptions.None);
                for (int i = 0; i < qqq.Count<string>(); i++)
                {
                    try
                    {
                        myConn.Open();
                        myCommand.CommandText = qqq[i];
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                        // ld.SetValueRichTextBox(@"Create data success!");
                    }
                    catch
                    {
                        myConn.Close();
                        // ld.SetValueRichTextBox(@"Create data failed!");
                    }
                }

                // ld.Dispose();
                return myConn;
            }
        }



        #region private static string defaultCreateDatabase_ThucTapNhom

        private static string defaultCreateDatabase_ThucTapNhom_Khai =
"if not exists (select name from sysobjects where name = 'NganHang') create table NganHang(MaNganHang varchar(40), TenNganHang nvarchar(100), DiaChi nvarchar(100), primary key (MaNganHang))";

        public static string DefaultCreateDatabase
        {
            get
            {
                return defaultCreateDatabase_ThucTapNhom_Khai;
            }
        }

        #endregion

        #region private static string defaultData_ThucTapNhom
        private static string defaultData_ThucTapNhom_Khai =
@"insert into NganHang (MaNganHang, TenNganHang, DiaChi) values ('ACB', N'Ngân hàng Á Châu', N'Số 340 Phan Bội Châu Tp (tỉnh) Bạc Liêu'),
('TPBank', N'Ngân hàng Tiên Phong', N'Số 239 Văn Cao Tp (tỉnh) Lào Cai'),
('DAB', N'Ngân hàng Đông Á', N'Số 4 Cầu Đất Tp (tỉnh) Đồng Nai'),
('SeABank', N'Ngân hàng Đông Nam Á', N'Số 339 Nam Cao Tp (tỉnh) Tây Ninh'),
('ABBANK', N'Ngân hàng An Bình', N'Số 124 Đông Tác Tp (tỉnh) Thái Bình'),
('BacABank', N'Ngân hàng Bắc Á', N'Số 206 Hùng Vương Tp (tỉnh) Thái Bình'),
('VietCapitalBank', N'Ngân hàng Bản Việt', N'Số 214 Ngõ 100 Nguyễn Chí Thanh Tp (tỉnh) Tây Ninh'),
('MSB', N'Hàng Hải Việt Nam', N'Số 315 Cao Bá Quát Tp (tỉnh) Đà Nẵng'),
('TCB', N'Kỹ Thương Việt Nam', N'Số 280 Hai Bà Trưng Tp (tỉnh) Bắc Ninh'),
('KienLongBank', N'Kiên Long', N'Số 237 Tôn Thất Thuyết Tp (tỉnh) Đồng Tháp'),
('Nam A Bank', N'Nam Á', N'Số 93 Hoa Lư Tp (tỉnh) Lào Cai'),
('NCB', N'Quốc Dân', N'Số 128 Ngõ 126 Hoàng Văn Thái Tp (tỉnh) Bình Định'),
('VPBank', N'Việt Nam Thịnh Vượng', N'Số 315 Hai Bà Trưng Tp (tỉnh) Hậu Giang'),
('HDBank', N'Phát triển nhà Thành phố Hồ Chí Minh', N'Số 257 Phạm Ngọc Thạch Tp (tỉnh) Hưng Yên'),
('OCB', N'Phương Đông', N'Số 115 Trung Tự Tp (tỉnh) Tuyên Quang'),
('MB', N'Quân đội', N'Số 372 Quốc Tử Giám Tp (tỉnh) Trà Vinh'),
('PVcombank', N'Đại chúng', N'Số 262 Định Công Tp (tỉnh) Bắc Giang'),
('VIB', N'Quốc tế', N'Số 243 Đường Bưởi Tp (tỉnh) Cần Thơ'),
('SCB', N'Sài Gòn', N'Số 14 Hoàng Cầu Tp (tỉnh) Quảng Nam'),
('SGB', N'Sài Gòn Công Thương', N'Số 52 Chùa Láng Tp (tỉnh) Tây Ninh'),
('SHB', N'Sài Gòn-Hà Nội', N'Số 186 Đê La Thành Tp (tỉnh) Hòa Bình'),
('STB', N'Sài Gòn Thương Tín', N'Số 421 Bát Sứ Tp (tỉnh) Hà Nội'),
('VAB', N'Việt Á', N'Số 98 Dương Đình Nghệ Tp (tỉnh) Bắc Giang'),
('BVB', N'Bảo Việt', N'Số 269 Tôn Thất Tùng Tp (tỉnh) Hòa Bình'),
('VietBank', N'Việt Nam Thương Tín', N'Số 160 Vạn Bảo Tp (tỉnh) Vĩnh Long'),
('PG Bank', N'Xăng dầu Petrolimex', N'Số 142 Ngõ 4 Kim Đồng Tp (tỉnh) Phú Yên'),
('EIB', N'Xuất Nhập khẩu Việt Nam', N'Số 41 Lương Đình Của Tp (tỉnh) Gia Lai'),
('LPB', N'Bưu điện Liên Việt', N'Số 107 Ngõ 100 Nguyễn Chí Thanh Tp (tỉnh) Lào Cai'),
('VCB', N'Ngoại thương Việt Nam', N'Số 99 Ngõ Huyện Tp (tỉnh) Lào Cai'),
('CTG', N'Công Thương Việt Nam', N'Số 243 Trần Hưng Đạo Tp (tỉnh) Quảng Trị'),
('BIDV', N'Đầu tư và Phát triển Việt Nam', N'Số 204 Bảo Khánh Tp (tỉnh) Khánh Hòa') go  insert into NguoiDung (SoCMND, TenDangNhap, MatKhau, HoTen, SoDienThoai, DiaChiThuongTru, GioiTinh, NgaySinh, TenNguoiBaoHo, SDTNguoiBaoHo, DiaChiNguoiBaoHo) values ('0100100100', 'TK01', 'MK01', N'Nhâm Huyền Trâm', '034 9627 471', N'Số 239 Hà Trung Tp (tỉnh) Gia Lai', 0, '2001-06-05', N'Xa Công Tráng', '034 5151 905', N'Số 117 Đại Cồ Việt Tp (tỉnh) Sơn La'),
('0100100101', 'TK02', 'MK02', N'Cam Quang Đông', '034 6538 552', N'Số 4 Giải Phóng Tp (tỉnh) Bắc Ninh', 1, '1975-01-16', N'Đồ Phượng Tiên', '034 3126 792', N'Số 190 Lý Thái Tổ Tp (tỉnh) Yên Bái'),
('0100100102', 'TK03', 'MK03', N'Mạc Thy Vân', '034 1967 251', N'Số 308 Đê La Thành Tp (tỉnh) Quảng Bình', 1, '1982-09-20', N'Giàng Thy Vân', '034 7080 170', N'Số 294 Cảm Hội Tp (tỉnh) Đồng Nai'),
('0100100103', 'TK04', 'MK04', N'Hàn Bích Hạnh', '034 4316 770', N'Số 140 Hồ Tùng Mậu Tp (tỉnh) Đắk Lắk', 0, '2006-06-04', N'Vưu Kim Khánh', '034 4975 630', N'Số 419 Nguyễn Thái Học Tp (tỉnh) Cần Thơ'),
('0100100104', 'TK05', 'MK05', N'Nghị An Tường', '034 8684 601', N'Số 372 Đường Láng Tp (tỉnh) Cần Thơ', 0, '2010-10-19', N'Trang Mỹ Kiều', '034 7085 981', N'Số 218 Phố Đông Các Tp (tỉnh) Thanh Hóa'),
('0100100105', 'TK06', 'MK06', N'Lỳ Quang Ninh', '034 2279 149', N'Số 402 Hàm Long Tp (tỉnh) Điện Biên', 0, '2010-05-19', N'Công Quang Lâm', '034 5325 954', N'Số 67 Cầu Mai Động Tp (tỉnh) Hà Nam'),
('0100100106', 'TK07', 'MK07', N'Khâu Hoài Nam', '034 2875 422', N'Số 347 Lê Quang Đạo Tp (tỉnh) Bình Thuận', 0, '1997-12-10', N'Khúc Thanh Tuấn', '034 6682 393', N'Số 341 Ngõ 84 Ngọc Khánh Tp (tỉnh) Cần Thơ'),
('0100100107', 'TK08', 'MK08', N'Tiêu Trọng Chính', '034 9751 407', N'Số 131 Ông Ích Kiêm Tp (tỉnh) Bình Định', 1, '2003-09-03', N'Cầm Nam Sơn', '034 9987 629', N'Số 275 Nguyễn Khang Tp (tỉnh) Hà Tĩnh'),
('0100100108', 'TK09', 'MK09', N'Mẫn Phong Lan', '034 9847 232', N'Số 378 Tràng Thi Tp (tỉnh) Yên Bái', 0, '2008-06-15', N'Võ Thái Sang', '034 9272 120', N'Số 13 Lê Lai Tp (tỉnh) Long An'),
('0100100109', 'TK10', 'MK10', N'Hình Thùy Dương', '034 5193 538', N'Số 103 Trương Hán Siêu Tp (tỉnh) Đồng Nai', 0, '1983-07-05', N'Giang Ngọc Quang', '034 3435 563', N'Số 417 Ngõ 40 Tạ Quang Bửu Tp (tỉnh) Đồng Tháp'),
('0100100110', 'TK11', 'MK11', N'Lê Ðăng Khánh', '034 6929 478', N'Số 190 Phố Huế Tp (tỉnh) Vĩnh Long', 1, '1973-10-27', N'Cồ Thanh Hảo', '034 8511 658', N'Số 23 Long Biên Tp (tỉnh) Bắc Kạn'),
('0100100111', 'TK12', 'MK12', N'Ung Thanh Hằng', '034 9403 728', N'Số 376 Nguyễn Văn Cừ Tp (tỉnh) Điện Biên', 0, '1975-07-20', N'Cù Huệ Thương', '034 8785 717', N'Số 313 Cổ Linh Tp (tỉnh) Tây Ninh'),
('0100100112', 'TK13', 'MK13', N'Ưng Quang Thắng', '034 6481 465', N'Số 261 Hàng Quạt Tp (tỉnh) Đắk Lắk', 0, '1996-02-13', N'Đường Thái Hòa', '034 8087 980', N'Số 194 Phố Đông Các Tp (tỉnh) Bình Phước'),
('0100100113', 'TK14', 'MK14', N'Hè Trà My', '034 7667 294', N'Số 77 Hoàng Cầu Tp (tỉnh) Đà Nẵng', 0, '1971-11-10', N'Dương Ngọc Vy', '034 4179 768', N'Số 370 Lê Đức Thọ Tp (tỉnh) Hải Dương'),
('0100100114', 'TK15', 'MK15', N'Lạc Hải Vân', '034 5226 411', N'Số 206 Đường Xuân Thủy Tp (tỉnh) Tuyên Quang', 0, '2013-10-27', N'Trịnh Thảo Ly', '034 9934 774', N'Số 229 Ngõ 118 Đào Tấn Tp (tỉnh) Tuyên Quang'),
('0100100115', 'TK16', 'MK16', N'Ánh Minh Hải', '034 7814 591', N'Số 198 Trương Hán Siêu Tp (tỉnh) Nghệ An', 0, '1977-08-21', N'Bửu Tuấn Chương', '034 8317 648', N'Số 265 Đường Láng Tp (tỉnh) Quảng Nam'),
('0100100116', 'TK17', 'MK17', N'Quản Huệ An', '034 7753 401', N'Số 155 Chùa Bộc Tp (tỉnh) Bắc Ninh', 0, '1991-03-21', N'Hạ Hạnh Nga', '034 9481 964', N'Số 376 Nguyễn Hữu Huân Tp (tỉnh) Lào Cai'),
('0100100117', 'TK18', 'MK18', N'Ngân Quốc Trụ', '034 9987 266', N'Số 334 Lê Văn Lương Tp (tỉnh) Điện Biên', 0, '1990-12-09', N'Bạch Phương Mai', '034 6310 983', N'Số 43 Đinh Tiên Hoàng Tp (tỉnh) Hòa Bình'),
('0100100118', 'TK19', 'MK19', N'Cao Hiệp Hào', '034 3633 711', N'Số 195 Cửa Đông Tp (tỉnh) Thừa Thiên Huế', 0, '2000-11-12', N'Tào Mai Hiền', '034 6974 945', N'Số 40 Chùa Láng Tp (tỉnh) Bến Tre'),
('0100100119', 'TK20', 'MK20', N'Phó Mỹ Xuân', '034 2911 637', N'Số 40 Nguyễn Văn Cừ Tp (tỉnh) Quảng Bình', 0, '2008-06-02', N'Hề Gia Khanh', '034 1688 614', N'Số 333 Phố Đông Các Tp (tỉnh) Đắk Nông'),
('0100100120', 'TK21', 'MK21', N'Xung Bích Thoa', '034 6854 445', N'Số 183 Nguyễn Xiển Tp (tỉnh) Hưng Yên', 1, '2003-10-19', N'Cam Thúy Hương', '034 6049 884', N'Số 190 Hàng Vôi Tp (tỉnh) Cà Mau'),
('0100100121', 'TK22', 'MK22', N'Lục Minh Ðạt', '034 2558 145', N'Số 125 Cầu Gỗ Tp (tỉnh) Hải Dương', 0, '1997-06-07', N'Ong Gia Bạch', '034 8885 763', N'Số 367 Giáp Bát Tp (tỉnh) Quảng Ninh'),
('0100100122', 'TK23', 'MK23', N'Ánh Như Hoa', '034 8025 207', N'Số 292 Ngõ 37 Lê Thanh Nghị Tp (tỉnh) Yên Bái', 0, '1981-05-27', N'Lư Thụy Vân', '034 7231 730', N'Số 167 Triệu Việt Vương Tp (tỉnh) Quảng Bình'),
('0100100123', 'TK24', 'MK24', N'Bảo Thế Sơn', '034 2288 238', N'Số 14 Bạch Mai Tp (tỉnh) Vĩnh Phúc', 1, '2000-02-10', N'Thạch Minh Uyên', '034 3368 503', N'Số 86 Kim Mã Tp (tỉnh) Đồng Tháp'),
('0100100124', 'TK25', 'MK25', N'Khâu Hoài Trang', '034 8953 947', N'Số 67 Ngõ 850 Tp (tỉnh) Điện Biên', 1, '1994-02-01', N'Lương Ðình Thắng', '034 2165 633', N'Số 47 100 Doi Can Tp (tỉnh) Điện Biên'),
('0100100125', 'TK26', 'MK26', N'Lưu Việt Quốc', '034 1658 759', N'Số 104 Hoàng Tích Trí Tp (tỉnh) Nghệ An', 1, '1971-07-31', N'Mộc Kỳ Duyên', '034 3419 318', N'Số 182 Đường Làng Tp (tỉnh) Yên Bái'),
('0100100126', 'TK27', 'MK27', N'Thẩm Thu Hoài', '034 7379 270', N'Số 383 Cầu Mai Động Tp (tỉnh) Lạng Sơn', 1, '2010-02-06', N'Trử Xuân Hương', '034 3224 501', N'Số 86 Ngo 110 Ngoc Ha Tp (tỉnh) Phú Thọ'),
('0100100127', 'TK28', 'MK28', N'Cù Quang Hải', '034 2264 193', N'Số 163 Nguyễn Đổng Chi Tp (tỉnh) Phú Yên', 1, '1970-12-02', N'Thập Lệ Nhi', '034 5529 217', N'Số 294 Nguyễn Đổng Chi Tp (tỉnh) Sóc Trăng'),
('0100100128', 'TK29', 'MK29', N'Lý Mai Quyên', '034 9457 135', N'Số 98 Nguyễn Công Hoan Tp (tỉnh) Yên Bái', 0, '1998-11-13', N'Thân Tuyết Hương', '034 8716 632', N'Số 270 Ngo 30 Ta Quang Buu Tp (tỉnh) Hà Tĩnh'),
('0100100129', 'TK30', 'MK30', N'Thi Anh Khôi', '034 7517 409', N'Số 118 Khuất Duy Tiến Tp (tỉnh) Bà Rịa -Vũng Tàu', 1, '2003-02-27', N'Phùng Quỳnh Chi', '034 4939 892', N'Số 312 Tam Trinh Tp (tỉnh) Hà Tĩnh'),
('0100100130', 'TK31', 'MK31', N'Phùng Thiên Kim', '034 4890 707', N'Số 91 Duy Tân Tp (tỉnh) Tây Ninh', 0, '1985-04-26', N'Cổ Thanh Lam', '034 6775 341', N'Số 336 Ngõ Chùa Nền Tp (tỉnh) Sơn La'),
('0100100131', 'TK32', 'MK32', N'Hồ Đan Linh', '034 1536 782', N'Số 4 Ngõ 250 Kim Giang Tp (tỉnh) Sơn La', 1, '1994-12-26', N'Huỳnh Vân Sơn', '034 4537 272', N'Số 108 Hồ Tùng Mậu Tp (tỉnh) Bạc Liêu'),
('0100100132', 'TK33', 'MK33', N'Vương Mai Hạ', '034 4844 774', N'Số 256 Trần Đại Nghĩa Tp (tỉnh) Tuyên Quang', 1, '2001-07-31', N'Doãn Thủy Trang', '034 3188 548', N'Số 67 Nguyễn Viết Xuân Tp (tỉnh) Lai Châu'),
('0100100133', 'TK34', 'MK34', N'Đồng Minh Trung', '034 2337 767', N'Số 405 Ngo 12 Núi Trúc Tp (tỉnh) Kiên Giang', 1, '1979-05-12', N'Kim Dũng Việt', '034 9146 698', N'Số 81 Liễu Giai Tp (tỉnh) Vĩnh Long'),
('0100100134', 'TK35', 'MK35', N'Đường Duyên My', '034 6292 837', N'Số 387 Ngõ 37 Lê Thanh Nghị Tp (tỉnh) Hà Nội', 0, '2004-04-18', N'Nhâm Lan Thương', '034 7386 672', N'Số 304 Duy Tân Tp (tỉnh) Bạc Liêu'),
('0100100135', 'TK36', 'MK36', N'Nguyễn Hồng Lâm', '034 2102 967', N'Số 135 Nguyễn Bỉnh Khiêm Tp (tỉnh) Bắc Giang', 0, '1987-04-19', N'Bình Việt Cương', '034 2819 416', N'Số 271 Hàng Thùng Tp (tỉnh) Lào Cai'),
('0100100136', 'TK37', 'MK37', N'Văn Khánh Thủy', '034 9882 925', N'Số 322 Vạn Bảo Tp (tỉnh) Quảng Trị', 0, '1979-08-30', N'Quản Thống Nhất', '034 3399 936', N'Số 251 Nguyễn Huy Tự Tp (tỉnh) Tây Ninh'),
('0100100137', 'TK38', 'MK38', N'Thành Trúc Quân', '034 9227 782', N'Số 331 Ngo 12 Núi Trúc Tp (tỉnh) Trà Vinh', 1, '1995-09-24', N'Hồng Yến My', '034 8292 863', N'Số 49 Tô Hiến Thành Tp (tỉnh) Lào Cai'),
('0100100138', 'TK39', 'MK39', N'Ca Minh Anh', '034 4595 379', N'Số 117 Vũ Thạnh Tp (tỉnh) Quảng Bình', 0, '1993-09-15', N'Giáp Kiều Khanh', '034 9684 944', N'Số 263 Láng Hạ Tp (tỉnh) Long An'),
('0100100139', 'TK40', 'MK40', N'Nghị Kim Hương', '034 7080 572', N'Số 35 Hồ Tùng Mậu Tp (tỉnh) Điện Biên', 1, '1985-11-12', N'Chế Hữu Phước', '034 7174 489', N'Số 176 Trung Yên Tp (tỉnh) Điện Biên'),
('0100100140', 'TK41', 'MK41', N'Hạ Yến Thanh', '034 1511 735', N'Số 58 Phùng Hưng Tp (tỉnh) Đà Nẵng', 0, '1980-03-18', N'Tô Nguyên Thảo', '034 6565 912', N'Số 136 Tạ Hiển Tp (tỉnh) Sóc Trăng')
go
 insert into NhanVien (MaNhanVien,MatKhau,TenNhanVien,SoCMND,DiaChi,SoDienThoai,GioiTinh,NgaySinh) values ('NV100101', 'MK01', N'Thẩm Hiệp Hòa', '037432728', N'Số 213 Nguyễn Chí Thanh Tp (tỉnh) Ninh Thuận', '034 9252 424', 0, '1990-01-28'),
('NV100102', 'MK02', N'Tri Hoàng Minh', '094553342', N'Số 349 Duy Tân Tp (tỉnh) Nam Định', '034 5018 642', 1, '2003-04-13'),
('NV100103', 'MK03', N'Bàn Tường Phát', '021137607', N'Số 35 Tt 34a Trần Phú Tp (tỉnh) Bắc Ninh', '034 9989 212', 1, '1990-01-07'),
('NV100104', 'MK04', N'Mâu Thái Duy', '065213531', N'Số 328 Ngõ 100 Nguyễn Chí Thanh Tp (tỉnh) Yên Bái', '034 3167 113', 1, '1992-02-07'),
('NV100105', 'MK05', N'Ong Mai Phương', '096996084', N'Số 288 Ngõ 612 Đê La Thành Tp (tỉnh) Lạng Sơn', '034 3041 989', 0, '2011-06-04'),
('NV100106', 'MK06', N'Lãnh Long Quân', '065969517', N'Số 111 Ngo 12 Núi Trúc Tp (tỉnh) Đà Nẵng', '034 3323 439', 1, '2003-04-12'),
('NV100107', 'MK07', N'Xa Công Hậu', '071768572', N'Số 8 Hàng Bài Tp (tỉnh) Đồng Tháp', '034 5046 592', 1, '2011-06-13'),
('NV100108', 'MK08', N'Cáp Mai Phương', '069607725', N'Số 56 Ngõ 1 Tạ Quang Bửu Tp (tỉnh) Bạc Liêu', '034 8199 686', 0, '1992-04-03'),
('NV100109', 'MK09', N'Đôn Vĩnh Thụy', '059318084', N'Số 419 Ngõ 40 Tạ Quang Bửu Tp (tỉnh) Thái Bình', '034 5507 888', 0, '1997-10-25'),
('NV100110', 'MK10', N'Trang Tố Loan', '052297410', N'Số 52 Giải Phóng Tp (tỉnh) Phú Yên', '034 4890 584', 0, '1979-02-05'),
('NV100111', 'MK11', N'Đồng Lan Hương', '023791681', N'Số 260 Ngõ 850 Tp (tỉnh) Phú Thọ', '034 2948 472', 0, '1997-09-17'),
('NV100112', 'MK12', N'Tăng Phương Thùy', '038188655', N'Số 393 Ngõ 564 Nguyễn Văn Cừ Tp (tỉnh) Ninh Bình', '034 4192 544', 1, '2009-04-01'),
('NV100113', 'MK13', N'Nghị Tiến Hiệp', '026598072', N'Số 98 Phạm Ngọc Thạch Tp (tỉnh) Thái Nguyên', '034 7201 153', 1, '1988-09-04'),
('NV100114', 'MK14', N'Ngân Ðức Toàn', '092190951', N'Số 193 Cầu Giấy Tp (tỉnh) Hà Tĩnh', '034 4774 273', 0, '2012-05-01'),
('NV100115', 'MK15', N'Nghiêm Bảo An', '019963077', N'Số 344 Hàng Muối Tp (tỉnh) Quảng Ngãi', '034 6280 454', 1, '1976-01-09'),
('NV100116', 'MK16', N'Khu Hoài Việt', '040230769', N'Số 253 Trúc Khê Tp (tỉnh) Quảng Trị', '034 7404 379', 1, '1979-05-17'),
('NV100117', 'MK17', N'Phí Quang Trọng', '018685309', N'Số 90 Giải Phóng Tp (tỉnh) Bình Định', '034 5927 698', 0, '1977-08-18'),
('NV100118', 'MK18', N'Phú Thiện Tâm', '027917980', N'Số 70 Lê Duẩn Tp (tỉnh) Hà Nam', '034 3697 509', 1, '1999-01-13'),
('NV100119', 'MK19', N'Ân Gia Phúc', '033520204', N'Số 330 Ngõ 106 Lê Thanh Nghị Tp (tỉnh) Bắc Ninh', '034 3386 450', 0, '1995-02-16'),
('NV100120', 'MK20', N'Hứa Quang Thạch', '070526498', N'Số 251 Bát Đàn Tp (tỉnh) An Giang', '034 3190 418', 1, '2012-01-16'),
('NV100121', 'MK21', N'Mã Tuyết Vy', '047953286', N'Số 385 Lĩnh Nam Tp (tỉnh) Quảng Ninh', '034 1014 877', 1, '1979-08-27'),
('NV100122', 'MK22', N'Thịnh Uyên Thơ', '026437980', N'Số 385 Xã Đàn Tp (tỉnh) Hưng Yên', '034 1796 739', 0, '1997-06-13'),
('NV100123', 'MK23', N'Ngụy Kim Sơn', '057037836', N'Số 273 Phạm Ngọc Thạch Tp (tỉnh) Bắc Kạn', '034 3166 892', 0, '1983-09-19'),
('NV100124', 'MK24', N'Trình Diệp Vy', '035889572', N'Số 380 Kim Ngưu Tp (tỉnh) Bắc Ninh', '034 8911 253', 0, '2006-10-29'),
('NV100125', 'MK25', N'Trà Tùng Quân', '020136801', N'Số 153 Hàng Bè Tp (tỉnh) Hà Tĩnh', '034 3186 951', 0, '1971-04-01'),
('NV100126', 'MK26', N'Châu Hạ Uyên', '016550130', N'Số 265 Cổ Linh Tp (tỉnh) Thái Bình', '034 6880 521', 1, '1996-01-24'),
('NV100127', 'MK27', N'Cát Ái Linh', '058883339', N'Số 62 Ông Ích Kiêm Tp (tỉnh) Đồng Tháp', '034 1936 822', 0, '1997-10-15'),
('NV100128', 'MK28', N'Hoàng Mạnh Tấn', '012726556', N'Số 367 Tam Trinh Tp (tỉnh) Tây Ninh', '034 6071 821', 0, '1982-10-26'),
('NV100129', 'MK29', N'Ấu Quỳnh Ngân', '028449028', N'Số 221 Kim Ngưu Tp (tỉnh) Hải Dương', '034 2345 313', 0, '1985-03-21'),
('NV100130', 'MK30', N'Tô Mai Hiền', '030230580', N'Số 323 Chùa Láng Tp (tỉnh) Lâm Đồng', '034 9818 568', 1, '1997-09-03'),
('NV100131', 'MK31', N'Thái Hùng Ngọc', '047007550', N'Số 12 Tôn Đức Thắng Tp (tỉnh) Đồng Nai', '034 6146 854', 0, '2003-02-15'),
('NV100132', 'MK32', N'Biện Hữu Ðịnh', '066982123', N'Số 287 Kim Đồng Tp (tỉnh) Ninh Thuận', '034 2788 633', 1, '1986-01-30'),
('NV100133', 'MK33', N'Lục Việt Nhân', '087491859', N'Số 297 Ngo 154 Ngoc Lam Tp (tỉnh) Điện Biên', '034 3542 467', 1, '1975-10-12'),
('NV100134', 'MK34', N'Phạm Dạ Hương', '029707259', N'Số 419 Hoàng Tích Trí Tp (tỉnh) Hưng Yên', '034 3099 147', 1, '2004-09-11'),
('NV100135', 'MK35', N'Trưng Diệu Nương', '014559464', N'Số 394 Trần Quốc Hoàn Tp (tỉnh) Bắc Ninh', '034 5084 428', 1, '1990-07-07'),
('NV100136', 'MK36', N'Khâu Cao Sỹ', '058571775', N'Số 81 Ngõ 84 Ngọc Khánh Tp (tỉnh) Sơn La', '034 9075 953', 1, '1981-09-11'),
('NV100137', 'MK37', N'Hùng Như Loan', '082458127', N'Số 95 Thái Thịnh Tp (tỉnh) Bà Rịa -Vũng Tàu', '034 9873 772', 0, '1993-11-06'),
('NV100138', 'MK38', N'Hè Thế Vinh', '053036992', N'Số 282 Gia Thụy Tp (tỉnh) Quảng Ngãi', '034 5363 641', 0, '1996-11-27'),
('NV100139', 'MK39', N'Bàng Chí Dũng', '032875679', N'Số 364 Trường Chinh Tp (tỉnh) Nghệ An', '034 6259 608', 1, '1995-03-09'),
('NV100140', 'MK40', N'Đồ Diễm My', '071494690', N'Số 199 Ngõ 211 Khương Trung Tp (tỉnh) Bến Tre', '034 8912 112', 1, '1970-02-23'),
('NV100141', 'MK41', N'Khoa Linh Nhi', '042425720', N'Số 253 Tạ Quang Bửu Tp (tỉnh) Tây Ninh', '034 4307 650', 1, '1986-02-14')
go

update NhanVien set LaQuanTriVien = 0
go

update NhanVien set LaQUanTriVien = 1 where MaNhanVien = 'NV100101'
go  insert into Sach (MaSach, TenSach, TacGia, NamXuatBan, Gia, NhaXuatBan, GioiHanTuoi) values ('S001', N'Tôi tài giỏi, bạn cũng thế', N'Adam Khoo', 1950, 40000, N'NXB Công An', 15), ('S002', N'Đắc nhân tâm', N'Dale Carnegie', 1951, 21000, N'NXB Công An Nhân Dân', 18), ('S003', N'Tội ác và trừng phạt', N'Dostoevsky.', 1952, 24000, N'NXB Công An', 18), ('S004', N'Nhà giả kim', N'Paulo Coelho', 1953, 23000, N'NXB Công An', 18), ('S005', N'Bắt trẻ đồng xanh', N'J.D.Salinger', 1954, 24000, N'NXB Đại Học Kinh Tế Quốc Dân', 11), ('S006', N'Xách ba lô lên và đi', N'Chưa rõ', 1955, 25000, N'NXB Khoa Học Xã Hội', 12), ('S007', N'Cứ đi rồi sẽ đến', N'Minh DeltaViet', 1956, 26000, N'NXB Hồng Đức', 15), ('S008', N'7 thói quen để thành đạt', N'Stephen R', 1957, 27000, N'NXB Khoa Học Xã Hội', 12), ('S009', N'Bố Già', N'Mario Puzo', 1958, 28000, N'NXB Hồng Đức', 18), ('S010', N'Zen and the Art of Motorcycle Maintenance', N'Robert M. Pirsig', 1959, 29000, N'NXB Hồng Đức', 15), ('S011', N'Watership Down', N'Richard Adams', 1950, 40000, N'NXB Phương Đông', 12), ('S012', N'The Last Lecture', N'Randy Pausch & Jeffrey Zaslow', 1951, 21000, N'NXB Phương Đông', 12), ('S013', N'A Short History of Nearly Everything', N'Bill Bryson', 1952, 24000, N'NXB Phương Đông', 13), ('S014', N'Man is Search for Meaning', N'Viktor Frankl', 1953, 23000, N'NXB Thông Tin Và Truyền Thông', 13), ('S015', N'The Forever War', N'Joe Haldeman', 1954, 24000, N'NXB Thông Tin Và Truyền Thông', 13), ('S016', N'Cosmos', N'Carl Sagan', 1955, 25000, N'NXB Thông Tin Và Truyền Thông', 16), ('S017', N'Bartleby The Scrivener: A Story of Wall-Street', N'Herman Melville', 1956, 26000, N'NXB Trẻ', 16), ('S018', N'Maus: A Survivor''s Tale', N'Art Spiegelman', 1957, 27000, N'NXB Trẻ', 16), ('S019', N'For Whom the Bell Tolls', N'Ernest Hemingway', 1958, 28000, N'NXB Từ Điển Bách Khoa', 18), ('S020', N'Kafka on the Shore', N'Haruki Murakami', 1959, 29000, N'NXB Từ Điển Bách Khoa', 18), ('S021', N'The Little Prince', N'Antoine de Saint-Exupéry', 1950, 40000, N'NXB Văn Hóa Văn Nghệ TPHCM', 18), ('S022', N'The Road', N'Cormac McCarthy', 1951, 21000, N'NXB Văn Hóa Văn Nghệ TPHCM', 18), ('S023', N'One Hundred Years of Solitude', N'Gabriel Garcia Marquez', 1952, 24000, N'NXB Văn Nghệ TP.HCM', 03), ('S024', N'East of Eden', N'John Steinbeck', 1953, 23000, N'NXB Văn Nghệ TP.HCM', 05), ('S025', N'How to Win Friends and Influence People', N'Dale Carnegie', 1954, 24000, N'NXB Văn Nghệ', 05), ('S026', N'Crime and Punishment', N'Fyodor Dostoyevsky', 1955, 25000, N'NXB Văn Nghệ', 06) go  insert into TheLoai (MaTheLoai, TenTheLoai) values ('TL01', N'Chính trị'), ('TL02', N'Pháp luật'), ('TL03', N'Khoa học công nghệ'), ('TL04', N'Kinh tế'), ('TL05', N'Văn hóa xã hội'), ('TL06', N'Lịch sử'), ('TL07', N'Văn học nghệ thuật'), ('TL08', N'Giáo trình'), ('TL09', N'Truyện, tiểu thuyết'), ('TL10', N'Tâm lý'), ('TL11', N'Tâm linh'), ('TL12', N'Tôn giáo'), ('TL13', N'Sách thiếu nhi'), ('TL14', N'Alternate history'), ('TL15', N'Autobiography'), ('TL16', N'Anthology'), ('TL17', N'Biography'), ('TL18', N'Chick lit'), ('TL19', N'Book review'), ('TL20', N'Children''s literature'), ('TL21', N'Cookbook'), ('TL22', N'Comic book'), ('TL23', N'Comic book'), ('TL24', N'Diary'), ('TL25', N'Coming-of-age') go  insert into dbo.NguoiDung_NganHang (SoCMND, MaNganHang, SoTaiKhoanNganHang) values
('0100100100', N'ACB', 'TK0100100100'),
('0100100101', N'TPBank', 'TK0100100101'),
('0100100102', N'DAB', 'TK0100100102'),
('0100100103', N'SeABank', 'TK0100100103'),
('0100100104', N'ABBANK', 'TK0100100104'),
('0100100105', N'BacABank', 'TK0100100105'),
('0100100106', N'VietCapitalBank', 'TK0100100106'),
('0100100107', N'MSB', 'TK0100100107'),
('0100100108', N'TCB', 'TK0100100108'),
('0100100109', N'KienLongBank', 'TK0100100109'),
('0100100110', N'Nam A Bank', 'TK0100100110'),
('0100100111', N'NCB', 'TK0100100111'),
('0100100112', N'VPBank', 'TK0100100112'),
('0100100113', N'HDBank', 'TK0100100113'),
('0100100114', N'OCB', 'TK0100100114'),
('0100100115', N'MB', 'TK0100100115'),
('0100100116', N'PVcombank', 'TK0100100116'),
('0100100117', N'VIB', 'TK0100100117'),
('0100100118', N'SCB', 'TK0100100118'),
('0100100119', N'SGB', 'TK0100100119'),
('0100100120', N'SHB', 'TK0100100120'),
('0100100121', N'STB', 'TK0100100121'),
('0100100122', N'VAB', 'TK0100100122'),
('0100100123', N'BVB', 'TK0100100123'),
('0100100124', N'VietBank', 'TK0100100124'),
('0100100125', N'PG Bank', 'TK0100100125'),
('0100100126', N'EIB', 'TK0100100126'),
('0100100127', N'LPB', 'TK0100100127'),
('0100100128', N'VCB', 'TK0100100128'),
('0100100129', N'CTG', 'TK0100100129'),
('0100100130', N'BIDV', 'TK0100100130')
go


insert into dbo.NhanVien_NganHang (MaNhanVien, MaNganHang, SoTaiKhoanNganHang) values
('NV100101', 'ACB', 'TK0100100200'),
('NV100102', 'TPBank', 'TK0100100201'),
('NV100103', 'DAB', 'TK0100100202'),
('NV100104', 'SeABank', 'TK0100100203'),
('NV100105', 'ABBANK', 'TK0100100204'),
('NV100106', 'BacABank', 'TK0100100205'),
('NV100107', 'VietCapitalBank', 'TK0100100206'),
('NV100108', 'MSB', 'TK0100100207'),
('NV100109', 'TCB', 'TK0100100208'),
('NV100110', 'KienLongBank', 'TK0100100209'),
('NV100111', 'Nam A Bank', 'TK0100100210'),
('NV100112', 'NCB', 'TK0100100211'),
('NV100113', 'VPBank', 'TK0100100212'),
('NV100114', 'HDBank', 'TK0100100213'),
('NV100115', 'OCB', 'TK0100100214'),
('NV100116', 'MB', 'TK0100100215'),
('NV100117', 'PVcombank', 'TK0100100216'),
('NV100118', 'VIB', 'TK0100100217'),
('NV100119', 'SCB', 'TK0100100218'),
('NV100120', 'SGB', 'TK0100100219'),
('NV100121', 'SHB', 'TK0100100220'),
('NV100122', 'STB', 'TK0100100221'),
('NV100123', 'VAB', 'TK0100100222'),
('NV100124', 'BVB', 'TK0100100223'),
('NV100125', 'VietBank', 'TK0100100224'),
('NV100126', 'PG Bank', 'TK0100100225'),
('NV100127', 'EIB', 'TK0100100226'),
('NV100128', 'LPB', 'TK0100100227'),
('NV100129', 'VCB', 'TK0100100228'),
('NV100130', 'CTG', 'TK0100100229'),
('NV100131', 'BIDV', 'TK0100100230')
go  insert into dbo.Sach_TheLoai (MaSach, MaTheLoai) values ('S001', 'TL04'), ('S001', 'TL01'), ('S002', 'TL02'), ('S002', 'TL03'), ('S003', 'TL04'), ('S003', 'TL05'), ('S004', 'TL01'), ('S004', 'TL07'), ('S005', 'TL14'), ('S006', 'TL07'), ('S006', 'TL09'), ('S007', 'TL12'), ('S007', 'TL03'), ('S008', 'TL06'), ('S009', 'TL02'), ('S010', 'TL04'), ('S011', 'TL08'), ('S011', 'TL02'), ('S012', 'TL05'), ('S012', 'TL07'), ('S013', 'TL08'), ('S013', 'TL06'), ('S014', 'TL09'), ('S015', 'TL12'), ('S015', 'TL06'), ('S016', 'TL03'), ('S016', 'TL02'), ('S017', 'TL01'), ('S018', 'TL06'), ('S018', 'TL14'), ('S019', 'TL12'), ('S020', 'TL01'), ('S020', 'TL09'), ('S020', 'TL07'), ('S021', 'TL16'), ('S021', 'TL05'), ('S021', 'TL03'), ('S021', 'TL02'), ('S023', 'TL01'), ('S024', 'TL19') go  insert into MuonSach (SoCMND, MaSach, MaNhanVien, NgayMuon) values ('0100100114', 'S001', 'NV100120', '1973-12-17'),
('0100100128', 'S002', 'NV100125', '2006-12-11'),
('0100100100', 'S003', 'NV100132', '2006-12-10'),
('0100100115', 'S004', 'NV100112', '1971-05-24'),
('0100100138', 'S005', 'NV100110', '2010-03-20'),
('0100100127', 'S006', 'NV100124', '1987-03-06'),
('0100100111', 'S007', 'NV100106', '1971-07-18'),
('0100100122', 'S008', 'NV100103', '1991-08-26'),
('0100100113', 'S009', 'NV100108', '2002-06-01'),
('0100100124', 'S010', 'NV100133', '1998-03-22'),
('0100100126', 'S011', 'NV100121', '2010-04-11'),
('0100100118', 'S012', 'NV100123', '2010-04-30'),
('0100100112', 'S013', 'NV100139', '1996-10-07'),
('0100100140', 'S014', 'NV100121', '1981-06-08'),
('0100100137', 'S015', 'NV100130', '1989-07-18'),
('0100100109', 'S016', 'NV100137', '1990-03-26'),
('0100100101', 'S017', 'NV100140', '1978-07-22'),
('0100100116', 'S018', 'NV100121', '2001-03-01'),
('0100100126', 'S019', 'NV100125', '1977-08-28'),
('0100100130', 'S020', 'NV100137', '2012-03-17'),
('0100100114', 'S021', 'NV100134', '1978-12-31'),
('0100100108', 'S022', 'NV100124', '1984-10-14'),
('0100100100', 'S023', 'NV100114', '2002-06-26') go  update MuonSach set NgayTra = DATEADD(day,120,NgayMuon) go  update MuonSach set TinhTrang = 0  go  insert into dbo.NhanSach (MaSach, MaNhanVien, NgayNhanSach) values ('S001', 'NV100101', '1974-04-09'),
('S002', 'NV100115', '2009-05-07'),
('S004', 'NV100106', '2010-04-12'),
('S006', 'NV100134', '1977-04-26'),
('S007', 'NV100102', '2000-12-12'),
('S008', 'NV100103', '1993-12-22'),
('S010', 'NV100136', '1977-08-15'),
('S011', 'NV100103', '1988-12-30'),
('S012', 'NV100140', '1978-04-23'),
('S013', 'NV100102', '1972-11-14'),
('S015', 'NV100135', '1991-03-21')
go  update NhanSach set NgayTreHan = DATEDIFF(day,(select ms.NgayTra from MuonSach ms where ms.MaSach = NhanSach.MaSach and ms.TinhTrang = 0),NgayNhanSach) go  update MuonSach set TinhTrang = 1 from NhanSach ns where MuonSach.MaSach = ns.MaSach and TinhTrang = 0  	and DATEDIFF(day, 		(select MAX(ns2.NgayNhanSach) from NhanSach ns2 where ns2.MaSach = MuonSach.MaSach), 		(select MAX(NgayMuon) from MuonSach, NhanSach ns3 where ns3.MaSach = MuonSach.MaSach)) > 0 go";

        public static string DefaultData_ThucTapNhom
        {
            get
            {
                return defaultData_ThucTapNhom_Khai;
            }
        }

        #endregion

    }

}
