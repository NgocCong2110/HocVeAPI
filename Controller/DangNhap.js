async function checkdangnhap(event) {

    event.preventDefault();

    const user = document.getElementById("username").value
    const pass = document.getElementById("password").value
    const userdata = {
        TenNguoiDung: user,
        EmailNguoiDung: null,
        MatKhauNguoiDung: pass
    }

    try {
        const response = await fetch("http://localhost:5450/api/TestAPI/TimKiemNguoiDung", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(userdata)
        })

        if (response.ok) {
            const result = await response.json()
            //LayEmail doi thanh layEmail :D
            userdata.EmailNguoiDung = result.layEmail
            localStorage.setItem("ThongTinNguoiDung", JSON.stringify(userdata))
            alert("Đăng Nhập Thành Công")
            window.location.href = "../View/TrangChu.html"
        }
        else {
            const result = await response.json()
            document.getElementById("thongbaoloi").innerHTML = result.message
        }
    } catch (error) {
        console.error("Lỗi kết nối API:", error);
        document.getElementById("thongbaoloi").innerText = "Không thể kết nối đến máy chủ.";
    }
}