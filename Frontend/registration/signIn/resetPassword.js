function resetPassword() {
    let resetPassword = document.createElement('div');
    document.body.append(resetPassword)
    resetPassword.innerHTML = `
    <div class="checkEmail">
  <div class="title-and-subtle">
    <div class="title">Reset password</div>
    <div class="label-and-CTA">
      <div class="label">Set up your new password to log in to Wonder World</div>
      </div>
  </div>
  <div class="content-body">
  <div class="inputs">
      <div class="new-password">
        <div class="input-title">New password</div>
        <div class="">
          <label><input name="email" class="email-input" type="text" placeholder="At least 6 characters"></label>
        </div>
      </div>
      <div class="confirm-new-password">
        <div class="input-title">Confirm new password</div>
        <div class="">
          <label><input name="email" class="email-input" type="text" placeholder="Re-enter your password"></label>
        </div>
      </div>
      </div>
        <a href="../signIn/signIn.html" class="CTA-button">Change password</a>
       </div>
       </div>
    `
}