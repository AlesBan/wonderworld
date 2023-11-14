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
        <div class="dropdown">
                    <div class="input-title">Country</div>
                    <div class="" >
        <input type="text" id="countryInput" class="first-name-input" oninput="filterCountries()" placeholder="Country">
                    </div>
                    <ul class="list-items" id="countryDropdown">

                    </ul>
                </div>
                <div class="dropdown">
                    <div class="input-title">City</div>
                    <div class="" >
        <input type="text" id="cityInput" class="first-name-input" oninput="filterCities()" placeholder="Cities">
                    </div>
                    <ul class="list-items" id="cityDropdown">

                    </ul>
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


var countriesData = []; // Local variable to store the countries data
var citiesData = []; // Local variable to store the cities data

function getCountries() {
    var xhr = new XMLHttpRequest();

    xhr.open("GET", "https://countriesnow.space/api/v0.1/countries", true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);
            countriesData = response.data.map(function (item) {
                return item.country;
            });
            console.log(countriesData); // Output countries data in the console
        } else if (xhr.readyState === 4) {
            console.error("Error: " + xhr.status);
        }
    };

    xhr.send();
}

function filterCountries() {
    var countryInput = document.getElementById("countryInput").value.toLowerCase();
    var filteredCountries = countriesData.filter(function (country) {
        return country.toLowerCase().startsWith(countryInput);
    });

    var dropdown = document.getElementById("countryDropdown");
    dropdown.innerHTML = "";

    filteredCountries.forEach(function (country) {
        var option = document.createElement("div");
        option.className = "dropdown-list-item";
        option.textContent = country;
        option.addEventListener("click", function () {
            document.getElementById("countryInput").value = country;
            dropdown.style.display = "none";
            getCities();
        });
        dropdown.appendChild(option);
    });

    if (filteredCountries.length > 0) {
        dropdown.style.display = "block";
    } else {
        dropdown.style.display = "none";
    }
}

function getCities() {
    var countryName = document.getElementById("countryInput").value;
    var xhr = new XMLHttpRequest();

    xhr.open("POST", "https://countriesnow.space/api/v0.1/countries/cities", true);
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);
            citiesData = response.data;
            console.log(citiesData); // Output cities data in the console
        } else if (xhr.readyState === 4) {
            console.error("Error: " + xhr.status);
        }
    };

    var requestBody = JSON.stringify({ country: countryName });
    xhr.send(requestBody);
}

function filterCities() {
    var cityInput = document.getElementById("cityInput").value.toLowerCase();
    var filteredCities = citiesData.filter(function (city) {
        return city.toLowerCase().startsWith(cityInput);
    });

    var dropdown = document.getElementById("cityDropdown");
    dropdown.innerHTML = "";

    filteredCities.forEach(function (city) {
        var option = document.createElement("div");
        option.className = "dropdown-list-item";
        option.textContent = city;
        option.addEventListener("click", function () {
            document.getElementById("cityInput").value = city;
            dropdown.style.display = "none";
        });
        dropdown.appendChild(option);
    });

    if (filteredCities.length > 0) {
        dropdown.style.display = "block";
    } else {
        dropdown.style.display = "none";
    }
}
function showCityDropdown() {
    var dropdown = document.getElementById("cityDropdown");
    if (dropdown.style.display === "none") {
        dropdown.style.display = "block";
    } else {
        dropdown.style.display = "none";
    }
}

// Загрузка списка стран при загрузке страницы
window.addEventListener("DOMContentLoaded", function () {
    getCountries();
});
