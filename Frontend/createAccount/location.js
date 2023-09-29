function chooseLocation() {
    let location = document.createElement('div');
    document.body.append(location)
    location.innerHTML = `
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
        <div class="input-title">Location</div>
        <div class="">
          <label><input name="first-name" class="first-name-input" id="locationValue" type="text" placeholder="e.g. Minsk, Belarus"></label>
        </div>
      </div>
      <div class="last-name">
        <div class="input-title">Languages</div>
        <div class="">
          <label><input name="last-name" class="last-name-input" id="languagesValue" type="text" placeholder="Select languages that you speak"></label>
        </div>
      </div>
    </div>
    <button onclick="chooseInstitution()" class="primary-button">Continue</button>
  </div>
    `

    document.querySelector('.createAccount').replaceWith(location);

}




