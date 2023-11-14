
// const firstName = localStorage.getItem('firstName');
// const firstNameOutput = document.querySelector(".first-name-output");
// firstNameOutput.textContent = firstName;
//
// const lastName = localStorage.getItem('lastName');
// const lastNameOutput = document.querySelector(".last-name-output");
// lastNameOutput.textContent = lastName;
//
// const getLanguage = localStorage.getItem('languages');
// const languagesOutput = document.querySelector(".language");
// languagesOutput.textContent = getLanguage;
//
// const getLocation = localStorage.getItem('location');
// const locationOutput =  document.querySelector(".location-text");
// locationOutput.textContent = getLocation;
//
// const getEstablishmentDto = localStorage.getItem('selectedValue');
// const EstablishmentDtoOutput =  document.querySelector("#establishment");
// EstablishmentDtoOutput.textContent = getEstablishmentDto;



// const getSubjects = localStorage.getItem('disciplines');
// const subjectsOutput = document.querySelector('.tags');
//
// const subjectsArray = getSubjects.split(',');
// // Создайте элементы DOM для каждого элемента массива
// subjectsArray.forEach(subject => {
//     const tagElement = document.createElement('span');
//     tagElement.textContent = subject;
//     tagElement.className = 'tag';
//     subjectsOutput.appendChild(tagElement);
// });




async function getUserProfile() {
    const url = 'http://localhost:7280/api/user/get-userprofile';

    const response = await fetch(url, {
        method: 'GET',
        referrerPolicy: "origin-when-cross-origin",
        headers: {
            'content-type': 'application/json; charset=utf-8',
            'Transfer-Encoding': 'chunked',
            'Data': new Date().toLocaleString(),
            'Server': "localhost",
            'Authorization': `Bearer ${localStorage.getItem('accessToken')}`
        },
    });

    if (response.ok) {
        const responseData = await response.json();
        console.log(responseData);


        // My profile
        document.querySelector(".first-name-output").textContent = `${responseData.value.firstName}`;
        document.querySelector(".last-name-output").textContent = `${responseData.value.lastName}`;
        document.querySelector(".language").textContent = `${responseData.value.languageTitles}`;
        document.querySelector(".location-text").textContent = `${responseData.value.cityTitle + ' ' + responseData.value.countryTitle}`;
        document.querySelector("#establishment").textContent = `${responseData.value.institution.title}`;

        const isATeacher = responseData.value.isATeacher;
        const statusText = document.querySelector(".status-text");

        if (isATeacher === true) {
            statusText.textContent = 'Teacher';
        } else {
            statusText.textContent = 'Expert';
        }




        const getSubjects= `${responseData.value.disciplineTitles}`
        const subjectsOutput = document.querySelector('.tags');
        const subjectsArray = getSubjects.split(',');
        subjectsArray.forEach(subject => {
            const tagElement = document.createElement('span');
            tagElement.textContent = subject;
            tagElement.className = 'tag';
            subjectsOutput.appendChild(tagElement);
        });

        console.log(...`${responseData.value.classeDtos[0].title}`)

        // User classes

        const getUserClasses = document.querySelector(".class-container");

        responseData.value.classeDtos.forEach(userClass => {
            const classPreview = document.createElement('div');
            classPreview.className = 'class-preview';


            classPreview.innerHTML = `
    <div class="class-preview-image">
      <img src="../images/class-preview-image.svg" alt="">
    </div>
    <div class="class-preview-text">${userClass.title}</div>
    <div class="class-preview-footer">
      <div class="class-preview-tags">${userClass.disciplines}</div>
      <div class="menu-action">
        <img src="../images/menu-action.svg" alt="">
        <div class="pop-over-menu">
          <div class="edit-class-btn">Edit</div>
          <div class="delete-class-btn">Delete</div>
        </div>
      </div>
    </div>
  `;

            getUserClasses.appendChild(classPreview);
        });


    } else {
        throw new Error('Произошла ошибка при выполнении запроса.');
    }


}

document.addEventListener('DOMContentLoaded', getUserProfile);




