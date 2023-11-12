// const subjectBtnFilter = document.querySelector('#select-subjects');
// const subjectFilterValues = [];
// const subjectFilterValuesDiv = document.querySelector(".selected-values");
//
// subjectBtnFilter.addEventListener("click", () => {
//     subjectBtnFilter.classList.toggle("open");
// });
//
//
// const lessons = document.querySelector('#list-subjects');
//
// let filterFn = (lesson) => true;
// generateItems(ALL_LESSONS);
//
// function generateItems(items) {
//
//     const html = items.filter(filterFn).map(lesson => {
//         return `
//
//  <li class="item">
//         <span class="item-text" id="item-lessons">${lesson.title}</span>
//         <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
//     </li>
//     `;
//     })
//
//         .join('');
//
//     lessons.innerHTML = html;
//
//
//     items = document.querySelectorAll('.item');
//     items.forEach(item => {
//         item.addEventListener("click", () => {
//             item.classList.toggle("checked");
//             const itemText = item.querySelector("#item-lessons").textContent;
//             if (item.classList.contains("checked")) {
//                 subjectFilterValues.push(itemText);
//             } else {
//                 const index = subjectFilterValues.indexOf(itemText);
//                 if (index !== -1) {
//                     subjectFilterValues.splice(index, 1);
//                 }
//             }
//             // selectedValuesDiv.innerHTML = subjectFilterValues.map(value => `<span>${value}</span>`).join(", ");
//
//             // localStorage.setItem('editedLessons', subjectFilterValues)
//         });
//
//     })
//
//     const dropdownButtons = document.createElement('div');
//     dropdownButtons.classList.add('dropdown-buttons');
//     dropdownButtons.innerHTML = `
//     <button class="clearButton">Clear All</button>
//     <button class="applyButton">Apply</button>
//   `;
//     lessons.appendChild(dropdownButtons);
//
// }
//
//
//
//
//
//
// const gradesBtnFilter = document.querySelector('#select-grades');
// const gradesFilterValues = [];
// const gradesFilterValuesDiv = document.querySelector(".selected-values");
//
//
// gradesBtnFilter.addEventListener("click", () => {
//     gradesBtnFilter.classList.toggle("open");
// });
//
//
// const grades = document.querySelector('#list-grades');
//
//
// generateGrades(ALL_GRADES);
//
// function generateGrades(items) {
//
//     const html = items.filter(filterFn).map(grade => {
//         return `
//
//  <li class="item">
//         <span class="item-text" id="item-grades">${grade.classNum}</span>
//         <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
//     </li>
//     `;
//     })
//
//         .join('');
//
//     grades.innerHTML = html;
//
//
//     items = document.querySelectorAll('.item');
//     items.forEach(item => {
//         item.addEventListener("click", () => {
//             item.classList.toggle("checked");
//             const itemText = item.querySelector("#item-grades").textContent;
//             if (item.classList.contains("checked")) {
//                 gradesFilterValues.push(itemText);
//             } else {
//                 const index = gradesFilterValues.indexOf(itemText);
//                 if (index !== -1) {
//                     gradesFilterValues.splice(index, 1);
//                 }
//             }
//             // gradesFilterValuesDiv.innerHTML = gradesFilterValues.map(value => `<span>${value}</span>`).join(", ");
//
//             // localStorage.setItem('editedGrades', gradesFilterValues)
//         });
//
//     })
//
//     const dropdownButtons = document.createElement('div');
//     dropdownButtons.classList.add('dropdown-buttons');
//     dropdownButtons.innerHTML = `
//     <button class="clearButton">Clear All</button>
//     <button class="applyButton">Apply</button>
//   `;
//     grades.appendChild(dropdownButtons);
//
// }
//
//
//
//
// const languageBtnFilter = document.querySelector('#select-languages');
// const languageFilterValues = [];
// const languageFilterValuesDiv = document.querySelector("#output-languages");
//
//
// languageBtnFilter.addEventListener("click", () => {
//     languageBtnFilter.classList.toggle("open");
// });
//
//
// const languages = document.querySelector('#list-languages');
//
//
// generateLanguages(ALL_LANGUAGES);
//
// function generateLanguages(items) {
//
//     const html = items.filter(filterFn).map(language => {
//         return `
//
//  <li class="item">
//         <span class="item-text" id="item-ages">${language.title}</span>
//         <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
//     </li>
//     `;
//     })
//
//         .join('');
//
//     languages.innerHTML = html;
//
//
//     items = document.querySelectorAll('.item');
//     items.forEach(item => {
//         item.addEventListener("click", () => {
//             item.classList.toggle("checked");
//             const itemText = item.querySelector("#item-ages").textContent;
//             if (item.classList.contains("checked")) {
//                 languageFilterValues.push(itemText);
//             } else {
//                 const index = languageFilterValues.indexOf(itemText);
//                 if (index !== -1) {
//                     languageFilterValues.splice(index, 1);
//                 }
//             }
//             // selectedLanguageDiv.innerHTML = languageFilterValues.map(value => `<span>${value}</span>`).join(", ");
//             //
//             // localStorage.setItem('editedLanguages', languageFilterValues)
//         });
//
//     })
//
//     const dropdownButtons = document.createElement('div');
//     dropdownButtons.classList.add('dropdown-buttons');
//     dropdownButtons.innerHTML = `
//     <button class="clearButton">Clear All</button>
//     <button class="applyButton">Apply</button>
//   `;
//     languages.appendChild(dropdownButtons);
//
// }
//
//
//
//
//
//
// const applyButton = document.querySelector(".applyButton");
// applyButton.addEventListener("click", () => {
//     console.log('apply')
//     const selectedTags = subjectFilterValues.map(value => `<div class="tag">${value}</div>`).join("");
//     subjectFilterValuesDiv.innerHTML = selectedTags;
// });
//
//
// const clearButton = document.querySelector('.clearButton');
// clearButton.addEventListener("click", () => {
//     subjectFilterValuesDiv.innerHTML = "";
// })
//
//



const dropdowns = [
    {
        btnFilter: document.querySelector('#select-subjects'),
        itemsContainer: document.querySelector('#list-subjects'),
        filterValues: [],
        items: ALL_LESSONS
    },
    {
        btnFilter: document.querySelector('#select-grades'),
        itemsContainer: document.querySelector('#list-grades'),
        filterValues: [],
        items: ALL_GRADES
    },
    {
        btnFilter: document.querySelector('#select-languages'),
        itemsContainer: document.querySelector('#list-languages'),
        filterValues: [],
        items: ALL_LANGUAGES
    }
];

const filterValuesDiv = document.querySelector('.selected-values'); // Общий элемент для всех выбранных значений

dropdowns.forEach(dropdown => {
    const { btnFilter, itemsContainer, filterValues, items } = dropdown;

    if (btnFilter) {
        btnFilter.addEventListener('click', () => {
            btnFilter.classList.toggle('open');
        });
    }

    if (itemsContainer) {
        generateItems(itemsContainer, items, filterValues);
    }
});

function generateItems(container, items, filterValues) {
    container.innerHTML = '';
    items.forEach(item => {
        const itemElement = document.createElement('div');
        itemElement.classList.add('item');
        itemElement.innerHTML = `
      <span class="item-text">${item.title || item.classNum}</span>
      <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    `;

        itemElement.addEventListener('click', () => {
            itemElement.classList.toggle('checked');
            const itemText = item.title || item.classNum;

            if (itemElement.classList.contains('checked')) {
                filterValues.push(itemText);
            } else {
                const index = filterValues.indexOf(itemText);
                if (index !== -1) {
                    filterValues.splice(index, 1);
                }
            }
        });

        container.appendChild(itemElement);
    });

    const dropdownButtons = document.createElement('div');
    dropdownButtons.classList.add('dropdown-buttons');
    dropdownButtons.innerHTML = `
    <button class="clearButton">Clear All</button>
    <button class="applyButton">Apply</button>
  `;
    container.appendChild(dropdownButtons);

    const clearButton = dropdownButtons.querySelector('.clearButton');
    clearButton.addEventListener('click', () => {
        filterValues.length = 0;
        updateSelectedValues(); // Обновление выбранных значений
    });
}

function updateSelectedValues() {
    filterValuesDiv.innerHTML = "";

    dropdowns.forEach((dropdown) => {
        const { filterValues } = dropdown;

        filterValues.forEach((value) => {
            const tagElement = document.createElement("div");
            tagElement.classList.add("tag");
            tagElement.textContent = value;

            const deleteTag = document.createElement("span");
            deleteTag.classList.add("delete-tag");
            deleteTag.innerHTML = "&times;";

            deleteTag.addEventListener("click", () => {
                const index = filterValues.indexOf(value);
                if (index !== -1) {
                    filterValues.splice(index, 1);
                    updateSelectedValues(); // Обновление выбранных значений
                }
            });

            tagElement.appendChild(deleteTag);
            filterValuesDiv.appendChild(tagElement);
        });
    });
}

const applyButtons = document.querySelectorAll('.applyButton');
applyButtons.forEach(applyButton => {
    applyButton.addEventListener('click', () => {
        updateSelectedValues();
    });
});



