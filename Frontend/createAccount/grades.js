function chooseGrades() {
    const inputValueDisciplines = document.querySelector('#disciplines').value;

    localStorage.setItem('disciplines', inputValueDisciplines);

    let chooseWork = document.createElement('div');
    document.body.append(chooseWork)
    chooseWork.innerHTML = `
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
        <div class="input-title">Grades</div>
<div class="select-btn">
    <span class="btn-text-grades" id="grades">Select..</span>
    <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
</div>
<ul class="grades-items">
    
</ul>
        </div>
      </div>
    </div>
    <button onclick="choosePhoto()" class="primary-button">Continue</button>
  </div>
    `

    const selectBtn = document.querySelector('.select-btn');
    const selectedValues = [];
    const selectedValuesDiv = document.querySelector(".btn-text-grades");

    selectBtn.addEventListener("click", () => {
        selectBtn.classList.toggle("open");
    });


    const grades = document.querySelector('.grades-items');

    let filterFn = (grade) => true;
    generateItems(ALL_GRADES);

    function generateItems(items) {

        const html = items.filter(filterFn).map(grade => {
            return `

 <li class="item">
        <span class="item-text">${grade.classNum}</span>
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
                const itemText = item.querySelector(".item-text").textContent;
                if (item.classList.contains("checked")) {
                    selectedValues.push(itemText);
                } else {
                    const index = selectedValues.indexOf(itemText);
                    if (index !== -1) {
                        selectedValues.splice(index, 1);
                    }
                }
                selectedValuesDiv.innerHTML = selectedValues.map(value => `<span>${value}</span>`).join(',');

                localStorage.setItem('grades', selectedValues);

            });

        });

    }

    document.querySelector('.createAccount').replaceWith(chooseWork);

}