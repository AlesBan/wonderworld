// const subjectBtnFilter = document.querySelector('.select-btn');
//
// const SubjectFilterValuesDiv = document.querySelector(".selected-values");
// const subjectFilterValues = [];
//
//
// subjectBtnFilter.addEventListener("click", () => {
//     subjectBtnFilter.classList.toggle("open");
// });
//
// const subjects = document.querySelector('#subject-items');
//
// let filterFn = (lesson) => true;
// generateSubjects(ALL_LESSONS);
//
// function generateSubjects(items) {
//
//     const html = items.filter(filterFn).map(lesson => {
//         return `
//
//  <li class="item">
//         <span class="item-text">${lesson.title}</span>
//         <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
//     </li>
//     `;
//     })
//
//         .join('');
//
//     subjects.innerHTML = html;
//
//     items = document.querySelectorAll('.item');
//     items.forEach(item => {
//         item.addEventListener("click", () => {
//             item.classList.toggle("checked");
//             const itemText = item.querySelector(".item-text").textContent;
//             if (item.classList.contains("checked")) {
//                 subjectFilterValues.push(itemText);
//             } else {
//                 const index = subjectFilterValues.indexOf(itemText);
//                 if (index !== -1) {
//                     subjectFilterValues.splice(index, 1);
//                 }
//             }
//             console.log(subjectFilterValues);
//         });
//
//     })
//
// }
//
//
//
//
//
//
// const gradeBtnFilter = document.querySelector('#grade');
//
// // const selectedSubjectValuesDiv = document.querySelector(".selected-values");
// const selectedGradeValues = [];
//
//
// gradeBtnFilter.addEventListener("click", () => {
//     gradeBtnFilter.classList.toggle("open");
// });
//
// const grades = document.querySelector('#grades-items');
//
// generateGrades(ALL_GRADES);
//
// function generateGrades(items) {
//
//     const html = items.filter(filterFn).map(grade => {
//         return `
//
//  <li class="item">
//         <span class="item-text">${grade.title}</span>
//         <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
//     </li>
//     `;
//     })
//
//         .join('');
//
//     grades.innerHTML = html;
//
//     items = document.querySelectorAll('.item');
//     items.forEach(item => {
//         item.addEventListener("click", () => {
//             item.classList.toggle("checked");
//             const itemText = item.querySelector(".item-text").textContent;
//             if (item.classList.contains("checked")) {
//                 selectedGradeValues.push(itemText);
//             } else {
//                 const index = selectedGradeValues.indexOf(itemText);
//                 if (index !== -1) {
//                     selectedGradeValues.splice(index, 1);
//                 }
//             }
//             console.log(selectedGradeValues);
//         });
//
//     })
//
// }


const subjectBtnFilter = document.querySelector('#select-subjects');
const subjectFilterValues = [];
const subjectFilterValuesDiv = document.querySelector(".selected-values");

subjectBtnFilter.addEventListener("click", () => {
    subjectBtnFilter.classList.toggle("open");
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
                subjectFilterValues.push(itemText);
            } else {
                const index = subjectFilterValues.indexOf(itemText);
                if (index !== -1) {
                    subjectFilterValues.splice(index, 1);
                }
            }
            // selectedValuesDiv.innerHTML = subjectFilterValues.map(value => `<span>${value}</span>`).join(", ");

            // localStorage.setItem('editedLessons', subjectFilterValues)
        });

    })

}






const gradesBtnFilter = document.querySelector('#select-grades');
const gradesFilterValues = [];
const gradesFilterValuesDiv = document.querySelector(".selected-values");


gradesBtnFilter.addEventListener("click", () => {
    gradesBtnFilter.classList.toggle("open");
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
                gradesFilterValues.push(itemText);
            } else {
                const index = gradesFilterValues.indexOf(itemText);
                if (index !== -1) {
                    gradesFilterValues.splice(index, 1);
                }
            }
            // gradesFilterValuesDiv.innerHTML = gradesFilterValues.map(value => `<span>${value}</span>`).join(", ");

            // localStorage.setItem('editedGrades', gradesFilterValues)
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






const applyButton = document.querySelector(".applyButton");
applyButton.addEventListener("click", () => {
    console.log('apply')
    const selectedTags = subjectFilterValues.map(value => `<div class="tag">${value}</div>`).join("");
    subjectFilterValuesDiv.innerHTML = selectedTags;
});


const clearButton = document.querySelector('.clearButton');
clearButton.addEventListener("click", () => {
    subjectFilterValuesDiv.innerHTML = "";
})


