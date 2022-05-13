// var btn = document.querySelector("#login-btn");
// btn.addEventListener("click", async e => {
//     e.preventDefault();
//     var uname = document.querySelector("#username").value;
//     var pass = document.querySelector("#password").value;

//     console.log(`${uname} cu parola ${pass}`)

//     try {
//         var res = await fetch('https://localhost:7148/user/login', {
//             method: "POST",
//             headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
//             body: JSON.stringify({
//                 Username: uname,
//                 Password: pass
//             })
//         });

//         console.log(res);
//         if(res.redirected) window.location.href = res.url;
//         var obj = await res.json();
//         console.log(obj);

//         //window.location.href = `${obj}`;
//     } catch(e) {
//         console.log(e);
//     }

// })

var btn = document.querySelector("#login-btn");
btn.addEventListener("click", async e => {
    e.preventDefault();
    var uname = document.querySelector("#username").value;
    var pass = document.querySelector("#password").value;

    console.log(`${uname} cu parola ${pass}`)

    try {
        var res = await fetch('https://localhost:7148/user/login', {
            method: "POST",
            headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
            body: JSON.stringify({
                Username: uname,
                Password: pass
            })
        });

        console.log(res);
        if(res.redirected) window.location.href = res.url;
        var obj = await res.json();
        console.log(obj);

        //window.location.href = `${obj}`;
    } catch(e) {
        console.log(e);
    }

})