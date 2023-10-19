function chooseLocation() {
    const inputValueTeacher = document.querySelector('#teacherValue').checked;
    const inputValueExpert = document.querySelector('#expertValue').checked;
    if (inputValueTeacher === true) {
        localStorage.setItem('teacher', true);
    }
     if(inputValueTeacher === false) {
        localStorage.setItem('teacher', false);
    }

    if (inputValueExpert === true) {
        localStorage.setItem('expert', true);
    }
     if(inputValueExpert === false) {
        localStorage.setItem('expert', false);
    }


    let location = document.createElement('div');
    document.body.append(location)
    location.innerHTML = `
    <div class="createAccount">
  <div class="title-and-subtle">
    <div class="title">Welcome <div class="first-name-output">${localStorage.getItem('firstName')}</div></div>
    <div class="label-and-CTA">
      <div class="label">It’s great to have you with us! To help us optimise your experience, tell us what you plan to use WonderWorld for.</div>
      </div>
  </div>
  <div class="content-body">
    <div class="inputs">
      <div class="first-name">
        <div class="input-title">Location</div>
        <div class="">
          <label><input name="first-name" class="first-name-input" id="locationValue" type="text" placeholder="e.g. Minsk, Belarus"></label>
        </div>
      </div>
      <div class="last-name">
<!--        <div class="input-title">Languages</div>-->
<!--        <div class="">-->
<!--          <label><input name="last-name" class="last-name-input" id="languagesValue" type="text" placeholder="Select languages that you speak"></label>-->
<!--        </div>-->
        <div class="dropdown">
                    <div class="input-title">Languages</div>
                    <div class="select-btn" id="select-languages">
                        <span class="btn-text" id="output-languages">Select..</span>
                        <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
                    </div>
                    <ul class="list-items" id="list-languages">

                    </ul>
                </div>
      </div>
    </div>
    <button onclick="chooseInstitution()" class="primary-button">Continue</button>
  </div>
    `
    const selectLanguageBtn = document.querySelector('#select-languages');
    const selectedLanguage = [];
    const selectedLanguageDiv = document.querySelector("#output-languages");


    selectLanguageBtn.addEventListener("click", () => {
        selectLanguageBtn.classList.toggle("open");
    });


    const languages = document.querySelector('#list-languages');


    generateLanguages(ALL_LANGUAGES);

    function generateLanguages(items) {

        const html = items.map(language => {
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
                const itemText = item.querySelector(".item-text").textContent;
                if (item.classList.contains("checked")) {
                    selectedLanguage.push(itemText);
                } else {
                    const index = selectedLanguage.indexOf(itemText);
                    if (index !== -1) {
                        selectedLanguage.splice(index, 1);
                    }
                }
                selectedLanguageDiv.innerHTML = selectedLanguage.map(value => `<span>${value}</span>`).join(", ");

                localStorage.setItem('languages', selectedLanguage)
            });

        })

    }

    document.querySelector('.createAccount').replaceWith(location);

}



