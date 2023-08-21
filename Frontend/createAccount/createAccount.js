function userStatus() {
    let userStatus = document.createElement('div');
    document.body.append(userStatus)
    userStatus.innerHTML = `
    <div class="createAccount">
  <div class="title-and-subtle">
    <div class="title">Welcome <div class="first-name-output"></div></div>
    <div class="label-and-CTA">
      <div class="label">It’s great to have you with us! To help us optimise your experience, tell us what you plan to use WonderWorld for.</div>
      </div>
  </div>
  <div class="content-body">
  <div class="options">
      <div class="option">
        <div class="option-value">
            <div class="option-name">I’m a teacher</div>
            <input type="radio" class="radiobutton" name="radio">
        </div>
      <div class="option-text">As a teacher you can add your classes and organise lessons, as well as join lessons as an expert in your field.</div>
      </div>
      <div class="option">
        <div class="option-value">
            <div class="option-name">I’m an expert</div>
            <input type="radio" class="radiobutton" name="radio">
        </div>
      <div class="option-text">As an expert you can connect with teacher and join lessons.</div>
      </div>
       <button onclick="resetPassword()" class="primary-button">Sign in again</button>
       </div>
       </div>
    `
}

let usernameInput = document.querySelector('.first-name-input');
let usernameOutput = document.querySelector('.first-name-output');

usernameInput.addEventListener('input', userName)
function userName() {
    let inputValue = usernameInput.value;
    usernameOutput.textContent = inputValue;
}

usernameInput.oninput = function() {
    usernameOutput.innerHTML = usernameInput.value;
};