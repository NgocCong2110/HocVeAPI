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
        [HttpPost("KiemTraDangNhap")]
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
                    string? LayEmail = KetNoiCSDL.LayEmailNguoiDung(thongtin.TenNguoiDung);
                    return Ok(new { message = "Đăng Nhập Thành Công", LayEmail });
                }
            }
            return Unauthorized(new { message = "Thông Tin Không Khớp" });
        }
        [HttpPost("ThemNguoiDungMoi")]
        public IActionResult InsertUser([FromBody] ThongTin thongtin)
        {
            if (thongtin != null)
            {
                KetNoiCSDL.ThemNguoiDung(thongtin);
                return Ok(new {message = "Đã thêm người dùng"});
            }
            return BadRequest(new { message = "Có sự cố khi thêm"});
        }
    }
}