function chooseInstitution() {
    let institution = document.createElement('div');
    document.body.append(institution)
    institution.innerHTML = `
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
        <div class="input-title">Institution name</div>
        <div class="">
          <label><input name="first-name" class="first-name-input" type="text" placeholder="e.g. Gymnasium No. 7, Minsk"></label>
        </div>
      </div>
    </div>
    <button onclick="userStatus()" class="primary-button">Continue</button>
  </div>
    `
}

