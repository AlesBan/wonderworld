function userStatus() {
    const inputValueFirstName = document.querySelector('#first-name-value').value;
    const inputValueLastName = document.querySelector('#last-name-value').value;

    localStorage.setItem('firstName', inputValueFirstName);
    localStorage.setItem('lastName', inputValueLastName);

    let userStatus = document.createElement('div');
    document.body.append(userStatus)
    userStatus.innerHTML = `
    <div class="createAccount">
  <div class="title-and-subtle">
    <div class="title">Welcome <div class="first-name-output">${localStorage.getItem('firstName')}</div></div>
    <div class="label-and-CTA">
      <div class="label">It’s great to have you with us! To help us optimise your experience, tell us what you plan to use WonderWorld for.</div>
      </div>
  </div>
  <div class="content-body">
  <div class="options">
      <div class="option">
        <div class="option-value">
            <div class="option-name">I’m a teacher</div>
            <input type="radio" class="radiobutton" id="teacherValue" name="radio">
        </div>
      <div class="option-text">As a teacher you can add your classes and organise lessons, as well as join lessons as an expert in your field.</div>
      </div>
      <div class="option">
        <div class="option-value">
            <div class="option-name">I’m an expert</div>
            <input type="radio" class="radiobutton" id="expertValue" name="radio">
        </div>
      <div class="option-text">As an expert you can connect with teacher and join lessons.</div>
      </div>
       <button onclick="chooseLocation()" class="primary-button">Continue</button>
       </div>
       </div>
      
    `

    document.querySelector('.createAccount').replaceWith(userStatus);
}


