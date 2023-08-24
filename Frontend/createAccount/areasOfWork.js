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
        <div class="select">
<!--          <label><input name="first-name" class="first-name-input" type="text" placeholder="Select.."></label>-->
<!--          <div class=""><img src="../images/chevron-down.svg" alt=""></div>-->
          <select>
           <option value="" disabled selected>Select..</option>
           <option>Пункт 1</option>
           <option>Пункт 2</option>
           </select>
        </div>
      </div>
    </div>
    <button onclick="" class="primary-button">Continue</button>
  </div>
    `
}

