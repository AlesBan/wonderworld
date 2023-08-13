document.addEventListener('DOMContentLoaded', function () {
    let input = document.querySelector('[name="email"].email-input');

    if (input) {
        input.value = localStorage.getItem("example-email") || "";

        input.addEventListener('input', function () {
            localStorage.setItem("example-email", this.value);
        });
    }
});

function SendData() {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let repeatPassword = document.getElementById("confirm-password").value;


    if (password === repeatPassword) {
        let userDto = {
            Email: email,
            Password: password
        };
        fetch('http://localhost:12193/api/auth/register', {
            method: "POST",
            body: JSON.stringify(userDto),
            headers: {
                "Content-Type": "application/json",
            },
        });

    } else {
        alert("Password don't equal Re-Enter Password");
    }
}

// const postData = async (url = '', data = {}) => {
//     const response = await fetch(url, {
//         method: 'POST',
//         headers: {
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(data)
//     });
//     return response.json();
// }

async function postData() {

    const url = 'https://localhost:7275/api/authentication/register';
    const data = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value
    };

    fetch(url, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Произошла ошибка при выполнении запроса.');
            }
        })
        .then(responseData => {
            console.log(responseData);
        })
        .catch(error => {
            console.error(error);
        });
}





