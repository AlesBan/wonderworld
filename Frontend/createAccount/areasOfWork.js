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
    <li class="item">
        <span class="item-text">Project activities</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Russian</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Literature</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Math</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">History</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">English</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">French</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">German</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Physics</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Chemistry</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Biology</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Social studies</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Geography</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Computer science</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">World art</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Visual art;</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
     <li class="item">
        <span class="item-text">Technology</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Natural science</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Music</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Economy</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Rhetoric</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    <li class="item">
        <span class="item-text">Local history</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
</ul>
        </div>
      </div>
    </div>
    <button onclick="chooseGrades()" class="primary-button">Continue</button>
  </div>
    `
    const selectBtn = document.querySelector('.select-btn');
    items = document.querySelectorAll('.item');

    selectBtn.addEventListener("click", () => {
        selectBtn.classList.toggle("open");
    });

    items.forEach(item => {
        item.addEventListener("click", () => {
            item.classList.toggle("checked");
            let checked = document.querySelectorAll(".checked"),
                btnText = document.querySelector(".btn-text");
            if(checked && checked.length > 0){
                btnText.innerText = `${btnText.innerText.value}`;
            }else{
                btnText.innerText = "Select..";
            }
        });
    })



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
    }


}

