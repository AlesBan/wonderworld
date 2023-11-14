document.getElementById("emailLabel").textContent = "We've sent a verification code to " + `${localStorage.getItem('emailVerif')}`;


async function verifyEmail() {
    const url = 'http://localhost:7280/api/user/confirm-email';


    const verificationCode = document.querySelector('#verificationCode').value;
    localStorage.setItem('verificationCode', verificationCode);

    const requestUrl = `${url}?verificationCode=${localStorage.getItem('verificationCode')}`;

    fetch(requestUrl, {
        method: 'GET',
        referrerPolicy: "origin-when-cross-origin",
        headers: {
            'content-type': 'application/json; charset=utf-8',
            'Transfer-Encoding': 'chunked',
            'Data': new Date().toLocaleString(),
            'Server': "localhost",
            'Authorization':`Bearer ${localStorage.getItem('accessToken')}`
        },
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
            localStorage.setItem('accessToken', responseData.token);
            window.location.href = "../createAccount/createAccount.html";
        })
        .catch(error => {
            console.log(error);
        });
}

console.log(localStorage.getItem('emailVerif'))