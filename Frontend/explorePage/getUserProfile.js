
const firstName = localStorage.getItem('firstName');
const firstNameOutput = document.querySelector(".first-name-output");
firstNameOutput.textContent = firstName;

const lastName = localStorage.getItem('lastName');
const lastNameOutput = document.querySelector(".last-name-output");
lastNameOutput.textContent = lastName;

const getLanguage = localStorage.getItem('languages');
const languagesOutput = document.querySelector(".language");
languagesOutput.textContent = getLanguage;

const getLocation = localStorage.getItem('location');
const locationOutput =  document.querySelector(".location-text");
locationOutput.textContent = getLocation;

const getEstablishmentDto = localStorage.getItem('selectedValue');
const EstablishmentDtoOutput =  document.querySelector("#establishment");
EstablishmentDtoOutput.textContent = getEstablishmentDto;



const getSubjects = localStorage.getItem('disciplines');
const subjectsOutput = document.querySelector('.tags');

const subjectsArray = getSubjects.split(',');
// Создайте элементы DOM для каждого элемента массива
subjectsArray.forEach(subject => {
    const tagElement = document.createElement('span');
    tagElement.textContent = subject;
    tagElement.className = 'tag';
    subjectsOutput.appendChild(tagElement);
});



    async function getUserProfile() {
        const url = 'http://localhost:7280/api/user/get-userprofile';



        fetch(url, {
            method: 'GET',
            referrerPolicy: "origin-when-cross-origin",
            headers: {
                'content-type': 'application/json; charset=utf-8',
                'Transfer-Encoding': 'chunked',
                'Data': new Date().toLocaleString(),
                'Server': "localhost",
                'Authorization':`Bearer ${localStorage.getItem('verificationToken')}`
            },
        })
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                else {
                    throw new Error('Произошла ошибка при выполнении запроса.');
                }

            })
            .then(responseData => {
                console.log(responseData);
                localStorage.setItem('responseUserInfo', responseData)
            })
            .catch(error => {
                console.log(error);
            });
        console.log(localStorage.getItem('verificationToken'))
  }




