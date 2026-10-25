const user1 = JSON.parse(sessionStorage.getItem("user"));

const firstname = document.querySelector("#firstname")
const familyname = document.querySelector("#familyname")
const password = document.querySelector("#password")
const email = document.querySelector("#email")

email.value = user1.email
firstname.value = user1.firstname
familyname.value = user1.familyname
password.value = user1.password

document.querySelector("#welcome").textContent =
    `Hello ${user1.firstname}, you succeeded login!`;

const update = async () => {
    const userId = user1.userId
    const firstname = document.querySelector("#firstname").value
    const lastName = document.querySelector("#familyname").value
    const password = document.querySelector("#password").value
    const email = document.querySelector("#email").value
    const updateUser = {
        email: email || user1.email,
        password: password || user1.password,
        firstname: firstname || user1.firstname,
        familyname: familyname || user1.familyname,
        userId: user1.userId
    }
    alert("after updateUser");
    try {
        const response = await fetch(`api/Users/${id}`, {
            method: "PUT",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(updateUser)

        })
        if (!response.ok)
            throw new Error("error changing details")
        else {

            sessionStorage.setItem("user", JSON.stringify(updateUser));
            alert("הפרטים עודכנו")
        }
    }
    catch (error) {
        alert(error.message)
    }
}
