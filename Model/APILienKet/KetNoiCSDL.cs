// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Cryptography.X509Certificates;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;
// namespace APILienKet
// {
//     public class KetNoiCSDL
//     {
//         public static string urlketnoi = "server=localhost;user=root;password=123456;database=nguoidung";
//         public static void Main(string[] args)
//         {
//             string? InPutName = Console.ReadLine();
//             if (InPutName != null)
//             {
//                 string? KetQua = TimKiemNguoiDung(InPutName);
//                 if (KetQua != null)
//                 {
//                     Console.WriteLine("Ton tai nguoi dung");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Khong ton tai nguoi dung");
//                 }
//             }
//         }
//         public static List<ThongTin> XemThongTinTatCaND()
//         {
//             List<ThongTin> list = new List<ThongTin>();
//             using var coon = new MySqlConnection(urlketnoi);
//             coon.Open();

//             string getall = "Select * from thongtinnguoidung";
//             using var cmd = new MySqlCommand(getall, coon);
//             using var reader = cmd.ExecuteReader();

//             while (reader.Read())
//             {
//                 ThongTin ttnguoidung = new ThongTin
//                 {
//                     TenNguoiDung = reader.GetString("TenNguoiDung"),
//                     EmailNguoiDung = reader.GetString("EmailNguoiDung"),
//                     MatKhauNguoiDung = reader.GetString("MatKhauNguoiDung")
//                 };
//                 list.Add(ttnguoidung);
//             }
//             return list;
//         }
//         public static string? TimKiemNguoiDung(string TenNguoiDung)
//         {
//             using var coon = new MySqlConnection(urlketnoi);
//             coon.Open();
//             string timkiem = "select tennguoidung from thongtinnguoidung where tennguoidung = @tennguoidung";
//             using var cmd = new MySqlCommand(timkiem, coon);
//             cmd.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
//             using var reader = cmd.ExecuteReader();
//             if (reader.Read())
//             {
//                 return reader["TenNguoiDung"].ToString();
//             }
//             return null;
//         }
//     }
// }