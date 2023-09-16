const selectBtn = document.querySelector('.select-btn');

const selectedValuesDiv = document.querySelector(".selected-values");
const selectedValues = [];


selectBtn.addEventListener("click", () => {
    selectBtn.classList.toggle("open");
});

const lessons = document.querySelector('.list-items');

let filterFn = (lesson) => true;
generateSubjects(ALL_LESSONS);

function generateSubjects(items) {

    const html = items.filter(filterFn).map(lesson => {
        return `

 <li class="item">
        <span class="item-text">${lesson.title}</span>
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
            const itemText = item.querySelector(".item-text").textContent;
            if (item.classList.contains("checked")) {
                selectedValues.push(itemText);
            } else {
                const index = selectedValues.indexOf(itemText);
                if (index !== -1) {
                    selectedValues.splice(index, 1);
                }
            }
            console.log(selectedValues);
        });

    })

}

const applyButton = document.querySelector(".applyButton");
applyButton.addEventListener("click", () => {
    const selectedTags = selectedValues.map(value => `<div class="tag">${value}</div>`).join("");
    selectedValuesDiv.innerHTML = selectedTags;

});


const clearButton = document.querySelector('.clearButton');
clearButton.addEventListener("click", () => {
    selectedValuesDiv.innerHTML = "";
})


