


const post = async () => {

    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value
    const firstname = document.querySelector("#firstname").value
    const familyname = document.querySelector("#familyname").value


    const user = {
        email: email, password: password, firstname: firstname, familyname: familyname
    };
    
    try {
        const response = await fetch("api/Users", {
           

            method: "POST",           
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(user)
        })
      


        if (!response.ok)
        {

            throw new Error("error in AddDetailsToServer");
        }
        else
        alert("נרשמת בהצלחה!")
    }
    catch (e) {
        alert(e.message);
    }

}



const login = async () => {

    const email = document.querySelector("#emaillog").value
    const password = document.querySelector("#passwordlog").value

    const userLogin = {
        email: email, password: password
    };

    try {
        const response = await fetch("api/Users/login", {


            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(userLogin)
        })



        if (!response.ok) {

            throw new Error("error finding details");
        }
        else {

            const user = await response.json();
            sessionStorage.setItem("user",JSON.stringify(user))
            alert("התחברת בהצלחה!")



        }
           

    }
    catch (e) {
        alert(e.message);
    }

}




const strongPassword = async () => {

    const password = document.querySelector("#password").value
    const passProgress = document.querySelector("#passProgress").value
    try {
        const response = await fetch("api/password", {
            

            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(password)
        })



        if (!response.ok) {

            throw new Error("error chaking password");
        }
        else {
            alert("check your password...")

            const score = await response.json();
            document.querySelector("#passProgress").value = score;



        }
    }
        catch (e) {
            alert(e.message);
        }


}

