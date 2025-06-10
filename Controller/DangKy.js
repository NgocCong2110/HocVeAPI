async function dangky(event){
    event.preventDefault();
    const username = document.getElementById("username").value
    const useremail = document.getElementById("useremail").value
    const userpass = document.getElementById("userpass").value
    const checkpass = document.getElementById("checkuserpass").value
    var check = checkdangky(userpass, checkpass)
    const userdata = {
        TenNguoiDung : username,
        EmailNguoiDung : useremail,
        MatKhauNguoiDung : userpass
    }
    if(check == true){
        const response = await fetch("http://localhost:5450/api/TestAPI/ChenThongTinNguoiDung",{
            method : "POST",
            headers : {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify(userdata)
        })
        window.location.href = "../View/TrangChu.html"
    }
    else{
        document.getElementById("thongbao").innerHTML = "Mật khẩu không khớp"
    }
}
function checkdangky(userpass, checkpass){
    if(userpass === checkpass){
        return true
    }
    else{
        return false
    }
}