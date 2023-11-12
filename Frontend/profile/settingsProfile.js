const filters = document.querySelectorAll('.filter');

filters.forEach(filter => {
    filter.addEventListener('click', function() {
        // Удаляем класс "active" у всех фильтров
        filters.forEach(filter => {
            filter.classList.remove('active');
        });

        // Добавляем класс "active" к текущему фильтру
        this.classList.add('active');
    });
});


/* dropdowns professional details */


const selectBtn = document.querySelector('#select-subjects');
const selectedValues = [];
const selectedValuesDiv = document.querySelector("#output-subjects");


selectBtn.addEventListener("click", () => {
    selectBtn.classList.toggle("open");
});


const lessons = document.querySelector('#list-subjects');

let filterFn = (lesson) => true;
generateItems(ALL_LESSONS);

function generateItems(items) {

    const html = items.filter(filterFn).map(lesson => {
        return `

 <li class="item">
        <span class="item-text" id="item-lessons">${lesson.title}</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    `;
    })

        .join('');

    lessons.innerHTML = html;


    items = document.querySelectorAll('.item');
    items.forEach(item => {
        item.addEventListener("click", () => {
            item.classList.toggle("checked");
            const itemText = item.querySelector("#item-lessons").textContent;
            if (item.classList.contains("checked")) {
                selectedValues.push(itemText);
            } else {
                const index = selectedValues.indexOf(itemText);
                if (index !== -1) {
                    selectedValues.splice(index, 1);
                }
            }
            selectedValuesDiv.innerHTML = selectedValues.map(value => `<span>${value}</span>`).join(", ");

            localStorage.setItem('editedLessons', selectedValues)
        });

    })

}






const selectGradesBtn = document.querySelector('#select-grades');
const selectedGrades = [];
const selectedGradesDiv = document.querySelector("#output-grades");


selectGradesBtn.addEventListener("click", () => {
    selectGradesBtn.classList.toggle("open");
});


const grades = document.querySelector('#list-grades');


generateGrades(ALL_GRADES);

function generateGrades(items) {

    const html = items.filter(filterFn).map(grade => {
        return `

 <li class="item">
        <span class="item-text" id="item-grades">${grade.classNum}</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    `;
    })

        .join('');

    grades.innerHTML = html;


    items = document.querySelectorAll('.item');
    items.forEach(item => {
        item.addEventListener("click", () => {
            item.classList.toggle("checked");
            const itemText = item.querySelector("#item-grades").textContent;
            if (item.classList.contains("checked")) {
                selectedGrades.push(itemText);
            } else {
                const index = selectedGrades.indexOf(itemText);
                if (index !== -1) {
                    selectedGrades.splice(index, 1);
                }
            }
            selectedGradesDiv.innerHTML = selectedGrades.map(value => `<span>${value}</span>`).join(", ");

            localStorage.setItem('editedGrades', selectedGrades)
        });

    })

}




const selectLanguageBtn = document.querySelector('#select-languages');
const selectedLanguage = [];
const selectedLanguageDiv = document.querySelector("#output-languages");


selectLanguageBtn.addEventListener("click", () => {
    selectLanguageBtn.classList.toggle("open");
});


const languages = document.querySelector('#list-languages');


generateLanguages(ALL_LANGUAGES);

function generateLanguages(items) {

    const html = items.filter(filterFn).map(language => {
        return `

 <li class="item">
        <span class="item-text" id="item-ages">${language.title}</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    `;
    })

        .join('');

    languages.innerHTML = html;


    items = document.querySelectorAll('.item');
    items.forEach(item => {
        item.addEventListener("click", () => {
            item.classList.toggle("checked");
            const itemText = item.querySelector("#item-ages").textContent;
            if (item.classList.contains("checked")) {
                selectedLanguage.push(itemText);
            } else {
                const index = selectedLanguage.indexOf(itemText);
                if (index !== -1) {
                    selectedLanguage.splice(index, 1);
                }
            }
            selectedLanguageDiv.innerHTML = selectedLanguage.map(value => `<span>${value}</span>`).join(", ");

            localStorage.setItem('editedLanguages', selectedLanguage)
        });

    })

}



/* api search */


async function fetchInstitution(searchText) {
    let response = await fetch(`https://search-maps.yandex.ru/v1/?text=${searchText}&type=biz&lang=ru_RU&apikey=6d742c7a-847a-40eb-b9a2-ae34493ad1f8
    
`);

    let data = await response.json();
    return data;
}

function renderInstitution(items) {
    console.log(items);
    let target = document.querySelector('.institution-items')
    const html = items.map(item => {
        return `

 <li class="item">
        <span class="item-text">${item.properties.description}</span>
    </li>
    `;
    })
        .join('');

    target.innerHTML = html;
    target.style.display = items.length > 0 ? 'block' : 'none';

    const itemElements = document.querySelectorAll('.item');
    itemElements.forEach(item => {
        item.addEventListener('click', () => {
            const selectedValue = item.querySelector('.item-text').textContent;
            document.querySelector('#changeInstitution').value = selectedValue;

            localStorage.setItem('selectedValue', selectedValue);
        });
    });

}


async function searchInstitution() {
    const searchInput = document.querySelector('#changeInstitution');
    const text = searchInput.value.toLowerCase();
    const response = await fetchInstitution(text);
    let items = response.features.filter(item => {
        return item.properties.description.toLowerCase();
    });
    console.log(items);

    renderInstitution(items)
}



/* render login/security page */

let profileInfoBtn = document.querySelector('.profile-info')
let loginAndSecurityBtn = document.querySelector('.profile-login');
let settingsProfileHTML = document.querySelector('.content').innerHTML;
loginAndSecurityBtn.addEventListener("click",  () => {
    let loginAndSecurity = document.createElement('div');
    document.body.append(loginAndSecurity)
    loginAndSecurity.innerHTML = `
    <div class="content">
        <div class="email-address">
            <div class="position-verification-title">Email address</div>
            <div class="position-verification-text">
                <span>Lorem ipsum dolor sit amet consectetur. Diam amet eget nam porttitor vitae non viverra.</span>
            </div>
            <div class="description">
                <div class="input-title">Email</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                 id="new-email" placeholder=""></label>
                </div>
            </div>
            <div class="update">
                <button onclick="postChangeEmail()" class="update-btn">Update</button>
            </div>
        </div>
        <div class="password-reset">
            <div class="position-verification-title">Password reset</div>
            <div class="position-verification-text">
                <span>Lorem ipsum dolor sit amet consectetur. Diam amet eget nam porttitor vitae non viverra.</span>
            </div>
            <div class="reset">
                <div class="input-title">Old password</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                  placeholder="Enter your old password"></label>
                </div>
            </div>
            <div class="reset">
                <div class="input-title">New password</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                 id="new-password" placeholder="At least 6 characters"></label>
                </div>
            </div>
            <div class="reset">
                <div class="input-title">Confirm new password</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                  placeholder="Re-enter new password"></label>
                </div>
            </div>
            <div class="update">
                <button onclick="postChangePassword()" class="update-btn">Change password</button>
            </div>
        </div>
        <div class="delete-account">
            <div class="position-verification-title">Delete account</div>
            <div class="position-verification-text">
                <span>You will not be able to restore your account</span>
            </div>
            <div class="delete">
                <button onclick="deleteUser()" class="delete-btn">Delete account</button>
            </div>
        </div>
        </div>

    `

    profileInfoBtn.addEventListener('click', () => {
        document.querySelector('.content').innerHTML = settingsProfileHTML;
    });

    document.querySelector('.content').replaceWith(loginAndSecurity);

})


