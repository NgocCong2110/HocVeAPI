using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILienKet
{
    public class ThongTin
    {
        public int id { get; set; }
        public string TenNguoiDung { get; set; } = "";
        public string? EmailNguoiDung { get; set; } = null;
        public string MatKhauNguoiDung { get; set; } = "";

    }
}