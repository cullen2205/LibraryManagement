using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class NganHang
    {
        /*  create table NganHang(
            MaNganHang varchar(40),
            TenNganHang nvarchar(100),
            DiaChi nvarchar(100),

            primary key (MaNganHang),
            )
         */
        public string MaNganHang { get; set; }
        public string TenNganHang { get; set; }
        public string DiaChi { get; set; }
        public string ToString(eNganHang e)
        {
            switch (e)
            {
                case eNganHang.MaNganHang:
                    return MaNganHang;
                case eNganHang.TenNganHang:
                    return TenNganHang;
                case eNganHang.DiaChi:
                    return DiaChi;
                default:
                    return "";
            }
        }
        public enum eNganHang
        {
            MaNganHang,
            TenNganHang,
            DiaChi,
        }
    }
}
