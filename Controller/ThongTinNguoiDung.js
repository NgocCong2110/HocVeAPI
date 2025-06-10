document.addEventListener("DOMContentLoaded", function LayThongTin() {

    const ThongTin = JSON.parse(localStorage.getItem("ThongTinNguoiDung"))

    const TenND = ThongTin.TenNguoiDung
    const EmailND = ThongTin.EmailNguoiDung

    if (ThongTin) {
        document.getElementById("TenChenVao").innerHTML = TenND
        document.getElementById("EmailChenVao").innerHTML = EmailND
    }
})