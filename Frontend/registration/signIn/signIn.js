document.addEventListener('DOMContentLoaded', function () {
    let input = document.querySelector('[name="email"].email-input');

    if (input) {
        input.value = localStorage.getItem("example-email") || "";

        input.addEventListener('input', function () {
            localStorage.setItem("example-email", this.value);
        });
    }
});

document.addEventListener('DOMContentLoaded', function () {
    let input = document.querySelector('[name="password"].password-input');

    if (input) {
        input.value = localStorage.getItem("password") || "";

        input.addEventListener('input', function () {
            localStorage.setItem("password", this.value);
        });
    }
});


async function postLoginData() {

    const url = 'http://localhost:7280/api/user/login';
    const data = {
        Email: document.getElementById("email-login").value,
        Password: document.getElementById("password-login").value
    };

    console.log(JSON.stringify(data));

    fetch(url, {
        method: 'POST',
        referrerPolicy: "origin-when-cross-origin",
        headers: {
            'content-type': 'application/json; charset=utf-8',
            'Transfer-Encoding': 'chunked',
            'Data': new Date().toLocaleString(),
            'Server': "localhost",
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else if (response.status === 401) {
                window.location.href = "../../createAccount/createAccount.html"
            } else {
                throw new Error('Произошла ошибка при выполнении запроса.');
            }
        })
        .then(responseData => {
            console.log(responseData);
            localStorage.setItem('verificationToken', responseData.value.verificationToken);
            console.log(responseData.value.verificationToken);
            localStorage.setItem('classSenderId', responseData.value.userId);
            console.log(responseData.value.userId);
            window.location.href = "../../explorePage/explorePage.html";
        })
        .catch(error => {
            console.log(error);
        });
}