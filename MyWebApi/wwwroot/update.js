
const user1=sessionStorage.getItem("user")

const email = document.querySelector("#email").value
const password = document.querySelector("#password").value
const firstname = document.querySelector("#firstname").value
const familyname = document.querySelector("#familyname").value


email.value = user1.email
password.value = user1.password
firstname.value = user1.firstname
familyname.value = user1.familyname


const update = async () => {

    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value
    const firstname = document.querySelector("#firstname").value
    const familyname = document.querySelector("#familyname").value

    const user = {
        email: email, password: password, firstname: firstname, familyname: familyname
    };

    try {
        const response = await fetch("api/Users"+id, {


            method: "PUT",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(user)
        })



        if (!response.ok) {

            throw new Error("error finding details");
        }
    }
    catch (e) {
        alert(e.message);
    }

}