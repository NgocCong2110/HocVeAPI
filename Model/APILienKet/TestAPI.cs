using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace APILienKet
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestAPI : ControllerBase
    {
        [HttpPost("TimKiemNguoiDung")]
        public IActionResult Login([FromBody] ThongTin thongtin)
        {
            // if (thongtin.TenNguoiDung == "nguyen van a" && thongtin.MatKhauNguoiDung == "123456")
            // {
            //     return Ok(new { message = "Dang nhap thanh cong" });
            // }
            // return Unauthorized(new { message = "Thong Tin khong khop" });
            string? result = KetNoiCSDL.TimKiemNguoiDung(thongtin.TenNguoiDung);
            if (result != null)
            {
                string? kiemtrapassw = KetNoiCSDL.KiemTraMatKhau(thongtin.TenNguoiDung);
                if (thongtin.MatKhauNguoiDung == kiemtrapassw)
                {
                    return Ok(new { message = "Đăng Nhập Thành Công" });
                }
            }
            return Unauthorized(new { message = "Thông Tin Không Khớp" });
        }
    }
}