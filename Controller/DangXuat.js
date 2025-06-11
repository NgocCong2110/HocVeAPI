function DangXuat(event) {
    event.preventDefault()
    setTimeout(() => {
        document.cookie = "ThongTinNguoiDung=0; path=/; max-age=0"
        window.location.href = "../View/TrangDangNhap.html"
    }, 500)
}