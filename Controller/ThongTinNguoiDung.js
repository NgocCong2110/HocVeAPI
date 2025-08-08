//dung cookie
// document.addEventListener("DOMContentLoaded", () => {
//     const data = getCookie("ThongTinNguoiDung")
//     console.log("Cookie sau khi ghi:", document.cookie);
//     if (data) {
//         try {
//             const ThongTin = JSON.parse(decodeURIComponent(data))

//             if (ThongTin) {
//                 document.getElementById("TenChenVao").innerHTML = ThongTin.TenNguoiDung
//                 document.getElementById("EmailChenVao").innerHTML = ThongTin.EmailNguoiDung
//             }
//         }
//         catch (e) {
//             console.log("Lỗi phân tích cookie:", e)
//         }
//     }
//     else{
//         console.log("Cookie hiện tại:", document.cookie);
//         console.log("Không có dữ liệu")
//     }
// })
// function getCookie(name) {
//     const value = `; ${document.cookie}`
//     const parts = value.split(`; ${name}=`)
//     if (parts.length === 2) {
//         return parts.pop().split(";").shift()
//     }
//     return null
// }




//Khong dung cookie
document.addEventListener("DOMContentLoaded", () => {
    const data = JSON.parse(localStorage.getItem("ThongTinNguoiDung"))
    const tennd = data.TenNguoiDung
    const emailnd = data.EmailNguoiDung
    document.getElementById("TenChenVao").innerText = tennd
    document.getElementById("EmailChenVao").innerText = emailnd
})