const cookieName = 'accessToken';
const cookieValue = document.cookie
    .split(';')
    .map(cookie => cookie.trim())
    .find(cookie => cookie.startsWith(`${cookieName}=`))
    ?.split('=')[1];

console.log(localStorage.getItem('accessToken'));

let token = localStorage.getItem('accessToken');


// function getCookie(name) {
//     let matches = document.cookie.match(new RegExp("(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"));
//     return matches ? decodeURIComponent(matches[1]) : undefined;
// }
//
// console.log(getCookie('accessToken'));

// let token = getCookie('accessToken');


async function postCreateAccount() {
    const url = 'http://localhost:7280/api/user/create-account';
    const apiData = await fetchOrg(localStorage.getItem('selectedValue'));
    const establishmentFields = apiData.features[0].properties;
    const disciplines = localStorage.getItem('areasOfWork').split(',')
    let types = ["School"];
    let location = localStorage.getItem('location')
    let languages = localStorage.getItem('languages').split(',');
    let grades = localStorage.getItem('grades').split(',').map(str => parseInt(str));
    const data = {
        FirstName: localStorage.getItem('firstName'),
        LastName: localStorage.getItem('lastName'),
        IsATeacher: true,
        IsAnExpert: false,
        CityLocation: location.split(' ')[0],
        CountryLocation: location.split(' ')[1],
        Languages: languages,
        InstitutionDto: {
            Types: types,
            Address: establishmentFields.description,
            Title: establishmentFields.name,
        },
        Disciplines: disciplines,
        Grades: grades,
        PhotoUrl: "dede"
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
            'Authorization':`Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJhZTY4MDRiZi1lZGYzLTQ5ZTgtYTVjZS1jNDAyZjIxMDQwOTUiLCJlbWFpbCI6ImtsaW1wYXZsb3YyMDAyQGdtYWlsLmNvbSIsImp0aSI6ImY3MzAwYTRmLTY3MTEtNGYwOS05MzI5LTZiMmY0Zjg0NGM4MyIsImlhdCI6MTY5ODY2NzAyOCwiaXNWZXJpZmllZCI6IlRydWUiLCJpc0NyZWF0ZWRBY2NvdW50IjoiRmFsc2UiLCJuYmYiOjE2OTg2NjcwMjgsImV4cCI6MTY5ODc1MzE1NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo3MjgwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3MjgwIn0.ufqzCfvu--Rh54FMCFE6XoJ_O3S5swbuHckEDgFTlfs`
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
            window.location.href = "../explorePage/explorePage.html";
        })
        .catch(error => {
            console.log(error);
        });
}

