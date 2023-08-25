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
<!--        <div class="select">-->
<!--&lt;!&ndash;          <label><input name="first-name" class="first-name-input" type="text" placeholder="Select.."></label>&ndash;&gt;-->
<!--&lt;!&ndash;          <div class=""><img src="../images/chevron-down.svg" alt=""></div>&ndash;&gt;-->
<!--          <select>-->
<!--           <option value="" disabled selected>Select..</option>-->
<!--           <option>Пункт 1</option>-->
<!--           <option>Пункт 2</option>-->
<!--           </select>-->
<div class="select-btn">
    <span class="btn-text">Select..</span>
    <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
</div>
<ul class="list-items">
    <li class="item">
        <span class="item-text">Art</span>
        <span class="checkbox"></span>
    </li>
     <li class="item">
        <span class="item-text">Biology</span>
        <span class="checkbox"></span>
    </li>
     <li class="item">
        <span class="item-text">Chemistry</span>
        <span class="checkbox"></span>
    </li>
     <li class="item">
        <span class="item-text">Computer science</span>
        <span class="checkbox"></span>
    </li>
</ul>
        </div>
      </div>
    </div>
    <button onclick="" class="primary-button">Continue</button>
  </div>
    `
    const selectBtn = document.querySelector('.select-btn');
    items = document.querySelectorAll('.item');

    selectBtn.addEventListener("click", () => {
        selectBtn.classList.toggle("open");
    })
}

