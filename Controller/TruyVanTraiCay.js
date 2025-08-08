async function Test(event){

    event.preventDefault();
    
    const tv = document.getElementById("truyvanTraiCay").value;

    console.log(tv);

    const response = await fetch("http://localhost:8000/data", {
        //get khong co body
        method: "POST",  
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({text: tv}),
    });
    const data = await response.json();
    
    document.getElementById("12ab").innerHTML = data.message;
}