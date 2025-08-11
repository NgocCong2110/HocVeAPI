async function Test(event) {

    event.preventDefault();

    const tv = document.getElementById("truyvanTraiCay").value;

    const response = await fetch("http://localhost:8000/data", {
        //get khong co body
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ text: tv }),
    });
    const data = await response.json();

    const rawText = data.message;

    // Giả sử tên trái cây nằm sau dấu ":" và có thể có dấu cách
    const tentraicay = rawText.split(':').pop().trim();

    console.log("Tên trái cây tách ra:", tentraicay);

    const responsetoCsha = await fetch("http://localhost:5450/api/TestAPI/LayAnh_Text", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ tentraicay: tentraicay })
    })

    const data_Anh = await responsetoCsha.json();
    document.getElementById("12ab").innerHTML = `<img src = "${data_Anh.layAnh_text}"/>`;
}