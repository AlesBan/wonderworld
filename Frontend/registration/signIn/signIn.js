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


async function post() {

    const url = 'http://localhost:7280/api/authentication/login';
    const data = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value
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
            } else {
                throw new Error('Произошла ошибка при выполнении запроса.');
            }
        })
        .then(responseData => {
            console.log(responseData);
        })
        .catch(error => {
            console.log(error);
        });
}