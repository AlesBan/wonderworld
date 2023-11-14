const cookieName = 'accessToken';
const cookieValue = document.cookie
    .split(';')
    .map(cookie => cookie.trim())
    .find(cookie => cookie.startsWith(`${cookieName}=`))
    ?.split('=')[1];

console.log(localStorage.getItem('accessToken'));

// let token = localStorage.getItem('accessToken');


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
    let languages = localStorage.getItem('languages').split(',');
    let grades = localStorage.getItem('grades').split(',').map(str => parseInt(str));
    let expertValue = localStorage.getItem('expert')
    let teacherValue = localStorage.getItem('teacher')
    const data = {
        FirstName: localStorage.getItem('firstName'),
        LastName: localStorage.getItem('lastName'),
        IsATeacher: JSON.parse(teacherValue),
        IsAnExpert: JSON.parse(expertValue),
        CityLocation: localStorage.getItem('locationCity'),
        CountryLocation: localStorage.getItem('locationCountry'),
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
            'Authorization':`Bearer ${localStorage.getItem('accessToken')}`
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
            localStorage.setItem('accessToken', responseData.value.accessToken);

            window.location.href = "../explorePage/explorePage.html";
        })
        .catch(error => {
            console.log(error);
        });
}

