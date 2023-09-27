const cookieName = 'accessToken';
const cookieValue = document.cookie
    .split(';')
    .map(cookie => cookie.trim())
    .find(cookie => cookie.startsWith(`${cookieName}=`))
    ?.split('=')[1];

console.log(cookieName);


let token = cookieValue;

async function postCreateAccount() {
    const url = 'http://localhost:7280/api/authentication/register';
    const data = {
        FirstName: document.querySelector("#first-name-value").value,
        LastName: document.querySelector("#last-name-value").value,
        IsATeacher: document.querySelector("#teacherValue").value,
        IsAnExpert: document.querySelector("#expertValue").value,
        CityLocation: document.querySelector("#locationValue").value,
        Languages: document.querySelector("#languagesValue").value,
        EstablishmentDto: document.querySelector("#institutionValue").value,
        Disciplines: document.querySelector("#disciplinesValue").value,
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
            'Authorization':`Bearer ${token}`
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
