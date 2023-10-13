document.addEventListener('DOMContentLoaded', function () {
    let input = document.querySelector('[name="email"].email-input');

    if (input) {
        input.value = localStorage.getItem("example-email") || "";

        input.addEventListener('input', function () {
            localStorage.setItem("example-email", this.value);
        });
    }
});

document.addEventListener('DOMContentLoaded', function() {
    let emailInput = document.getElementById('email');

    if (emailInput) {
        emailInput.addEventListener('input', function() {
            let email = this.value;
            let isValid = validateEmail(email);

            if (isValid) {
                this.classList.remove('invalid');
            } else {
                this.classList.add('invalid');
            }
        });
    }
});

function validateEmail(email) {
    let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

document.addEventListener('DOMContentLoaded', function () {
    let input = document.querySelector('[name="password"].password-input');

    if (input) {
        input.value = localStorage.getItem("password") || "";

        input.addEventListener('input', function () {
            localStorage.setItem("password", this.value);
        });
    }
});

document.addEventListener('DOMContentLoaded', function () {
    let input = document.querySelector('[name="confirm-password"].confirm-password-input');

    if (input) {
        input.value = localStorage.getItem("confirm-password") || "";

        input.addEventListener('input', function () {
            localStorage.setItem("confirm-password", this.value);
        });
    }
});


function validatePassword(password) {
    return password.length >= 6;
}

async function postData() {

    const url = 'http://localhost:7280/api/user/register';
    const password = document.getElementById("password").value;
    const data = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value
    };

    if (!validatePassword(password)) {
        // Введите дополнительные действия для обработки неправильного пароля
        document.getElementById("password").classList.add("invalid");
        return;
    }


    console.log(JSON.stringify(data));

    fetch(url, {
        method: 'POST',
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
            // const accessToken = responseData.token;
            // document.cookie = `accessToken=${accessToken}`;
            localStorage.setItem('accessToken', responseData.token);
            console.log(responseData.token);

            window.location.href = "../../createAccount/createAccount.html";
        })
        .catch(error => {
            console.log(error);
        });
}



