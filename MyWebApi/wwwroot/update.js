const user1 =JSON.parse(sessionStorage.getItem("user"));

const name = document.querySelector("#name")
const lastName = document.querySelector("#lastName")
const password = document.querySelector("#password")
const email = document.querySelector("#email")

email.value = user1.email
name.value = user1.name
lastName.value = user1.lastName
password.value = user1.password

const update = async () => {
    const id = user1.id
    const name = document.querySelector("#name").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value
    const email = document.querySelector("#email").value
    const updateUser = {
        email: email || user1.email, password: password || user1.password, name: name || user1.name, lastName: lastName || user1.lastName, id: user1.id
    }
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
