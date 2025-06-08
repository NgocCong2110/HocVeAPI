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
            document.getElementById("thongbaoloi").innerHTML = "nguoi dung ton tai"
            alert("Dang nhap thanh cong")
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