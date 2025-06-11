function DangXuat(event){
    event.preventDefault()
    localStorage.removeItem("ThongTinNguoiDung")
    window.location.href = "../View/TrangDangNhap.html"
}