function chooseGrades() {
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
        <div class="input-title">Grades</div>
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
    </ul>
     </div>
      </div>
    </div>
    <button onclick="chooseGrades()" class="primary-button">Continue</button>
  </div>
    `

}