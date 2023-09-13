const selectBtn = document.querySelector('.select-btn');

selectBtn.addEventListener("click", () => {
    selectBtn.classList.toggle("open");
});

const lessons = document.querySelector('.list-items');
// const grades = document.querySelector('.')

let filterFn = (lesson) => true;
generateItems(ALL_LESSONS);

function generateItems(items) {

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
        });

    })

}




