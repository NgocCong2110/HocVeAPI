function dangky(event){
    event.preventDefault();
    const userpass = document.getElementById("userpass").value
    const checkpass = document.getElementById("checkuserpass").value
    var check = checkdangky(userpass, checkpass)
    if(check == true){
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