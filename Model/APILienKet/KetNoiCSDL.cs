using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySql.Data.MySqlClient;
namespace APILienKet
{
    public class KetNoiCSDL
    {
        public static string urlketnoi = "server=localhost;user=root;password=123456;database=nguoidung";
        public static List<ThongTin> XemThongTinTatCaND()
        {
            List<ThongTin> list = new List<ThongTin>();
            using var coon = new MySqlConnection(urlketnoi);
            coon.Open();

            string getall = "Select * from thongtinnguoidung";
            using var cmd = new MySqlCommand(getall, coon);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ThongTin ttnguoidung = new ThongTin
                {
                    TenNguoiDung = reader.GetString("TenNguoiDung"),
                    EmailNguoiDung = reader.GetString("EmailNguoiDung"),
                    MatKhauNguoiDung = reader.GetString("MatKhauNguoiDung")
                };
                list.Add(ttnguoidung);
            }
            return list;
        }
        public static string? KiemTraMatKhau(string TenNguoiDung)
        {
            using var coon = new MySqlConnection(urlketnoi);
            coon.Open();
            string kiemtramatkhau = "Select matkhaunguoidung from thongtinnguoidung where tennguoidung = @tennguoidung";
            using var cmd = new MySqlCommand(kiemtramatkhau, coon);
            cmd.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader["MatKhauNguoiDung"].ToString();
            }
            return null;
        }
        public static string? TimKiemNguoiDung(string TenNguoiDung)
        {
            using var coon = new MySqlConnection(urlketnoi);
            coon.Open();
            string timkiem = "select tennguoidung from thongtinnguoidung where tennguoidung = @tennguoidung";
            using var cmd = new MySqlCommand(timkiem, coon);
            cmd.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader["TenNguoiDung"].ToString();
            }
            return null;
        }
        public static string? LayEmailNguoiDung(string TenNguoiDung)
        {
            using var coon = new MySqlConnection(urlketnoi);
            coon.Open();
            string TimKiemEmail = "Select emailnguoidung from thongtinnguoidung where tennguoidung = @tennguoidung";
            using var cmd = new MySqlCommand(TimKiemEmail, coon);
            cmd.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader["EmailNguoiDung"].ToString();
            }
            return null;
        }
        public static void ThemNguoiDung(ThongTin thongTin)
        {
            using var coon = new MySqlConnection(urlketnoi);
            coon.Open();
            string ThemThongTin = "Insert into thongtinnguoidung(tennguoidung, emailnguoidung, matkhaunguoidung) values(@tennguoidung, @emailnguoidung, @matkhaunguoidung)";
            using var reader = new MySqlCommand(ThemThongTin, coon);
            reader.Parameters.AddWithValue("@tennguoidung", thongTin.TenNguoiDung);
            reader.Parameters.AddWithValue("@emailnguoidung", thongTin.EmailNguoiDung);
            reader.Parameters.AddWithValue("@matkhaunguoidung", thongTin.MatKhauNguoiDung);
            reader.ExecuteNonQuery();
        }
    }
}