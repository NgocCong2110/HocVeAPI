using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class ThongTin
    {
        public int id { get; set; }
        public string TenNguoiDung { get; set; }
        public string EmailNguoiDung { get; set; }
        public string MatKhauNguoiDung { get; set; }
        public string? anh_Text { get; set; } = "";
    }
}