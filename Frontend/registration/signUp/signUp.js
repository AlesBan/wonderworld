document.addEventListener('DOMContentLoaded', function() {
    let input = document.querySelector('[name="email"].email-input');

    if (input) {
        input.value = localStorage.getItem("example-email") || "";

        input.addEventListener('input', function() {
            localStorage.setItem("example-email", this.value);
        });
    }
});

document.addEventListener('DOMContentLoaded', function() {
    let input = document.querySelector('[name="password"].password-input');

    if (input) {
        input.value = localStorage.getItem("password") || "";

        input.addEventListener('input', function() {
            localStorage.setItem("password", this.value);
        });
    }
});

document.addEventListener('DOMContentLoaded', function() {
    let input = document.querySelector('[name="confirm-password"].confirm-password-input');

    if (input) {
        input.value = localStorage.getItem("confirm-password") || "";

        input.addEventListener('input', function() {
            localStorage.setItem("confirm-password", this.value);
        });
    }
});



// const url = 'https://api.example.com/post'; // Замените на нужный URL
//
// const data = {
//     name: 'John Doe',
//     email: 'johndoe@example.com'
// };
//
// fetch(url, {
//     method: 'POST',
//     headers: {
//         'Content-Type': 'application/json'
//     },
//     body: JSON.stringify(data)
// })
//     .then(response => {
//         if (response.ok) {
//             return response.json();
//         } else {
//             throw new Error('Произошла ошибка при выполнении запроса.');
//         }
//     })
//     .then(responseData => {
//         console.log(responseData);
//     })
//     .catch(error => {
//         console.error(error);
//     });