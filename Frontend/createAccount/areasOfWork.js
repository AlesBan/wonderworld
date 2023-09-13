function chooseWork() {
    let chooseWork = document.createElement('div');
    document.body.append(chooseWork)
    chooseWork.innerHTML = `
    <div class="createAccount">
  <div class="title-and-subtle">
    <div class="title">Welcome <div class="first-name-output"></div></div>
    <div class="label-and-CTA">
      <div class="label">It’s great to have you with us! To help us optimise your experience, tell us what you plan to use WonderWorld for.</div>
      </div>
  </div>
  <div class="content-body">
    <div class="inputs">
      <div class="first-name">
        <div class="input-title">Areas of work</div>
<div class="select-btn">
    <span class="btn-text">Select..</span>
    <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
</div>
<ul class="list-items">
    
</ul>
        </div>
      </div>
    </div>
    <button onclick="chooseGrades()" class="primary-button">Continue</button>
  </div>
    `
    const selectBtn = document.querySelector('.select-btn');


    selectBtn.addEventListener("click", () => {
        selectBtn.classList.toggle("open");
    });


    const lessons = document.querySelector('.list-items');

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
                let checked = document.querySelectorAll(".checked"),
                    btnText = document.querySelector(".btn-text");
                if(checked && checked.length > 0){
                    btnText.innerText = `${checked.value}`;
                }else{
                    btnText.innerText = "Select..";
                }
            });

        })

    }

}
