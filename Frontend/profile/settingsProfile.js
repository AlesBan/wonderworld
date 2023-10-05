const filters = document.querySelectorAll('.filter');

filters.forEach(filter => {
    filter.addEventListener('click', function() {
        // Удаляем класс "active" у всех фильтров
        filters.forEach(filter => {
            filter.classList.remove('active');
        });

        // Добавляем класс "active" к текущему фильтру
        this.classList.add('active');
    });
});


let profileInfoBtn = document.querySelector('.profile-info')
let loginAndSecurityBtn = document.querySelector('.profile-login');
let settingsProfileHTML = document.querySelector('.content').innerHTML;
loginAndSecurityBtn.addEventListener("click",  () => {
    let loginAndSecurity = document.createElement('div');
    document.body.append(loginAndSecurity)
    loginAndSecurity.innerHTML = `
    <div class="content">
        <div class="email-address">
            <div class="position-verification-title">Email address</div>
            <div class="position-verification-text">
                <span>Lorem ipsum dolor sit amet consectetur. Diam amet eget nam porttitor vitae non viverra.</span>
            </div>
            <div class="description">
                <div class="input-title">Email</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                  placeholder=""></label>
                </div>
            </div>
            <div class="update">
                <button class="update-btn">Update</button>
            </div>
        </div>
        <div class="password-reset">
            <div class="position-verification-title">Password reset</div>
            <div class="position-verification-text">
                <span>Lorem ipsum dolor sit amet consectetur. Diam amet eget nam porttitor vitae non viverra.</span>
            </div>
            <div class="reset">
                <div class="input-title">Old password</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                  placeholder="Enter your old password"></label>
                </div>
            </div>
            <div class="reset">
                <div class="input-title">New password</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                  placeholder="At least 6 characters"></label>
                </div>
            </div>
            <div class="reset">
                <div class="input-title">Confirm new password</div>
                <div class="">
                    <label><input name="institution-name" class="institution-name-input" type="text"
                                  placeholder="Re-enter new password"></label>
                </div>
            </div>
            <div class="update">
                <button class="update-btn">Change password</button>
            </div>
        </div>
        <div class="delete-account">
            <div class="position-verification-title">Delete account</div>
            <div class="position-verification-text">
                <span>You will not be able to restore your account</span>
            </div>
            <div class="delete">
                <span class="delete-btn">Delete account</span>
            </div>
        </div>
        </div>

    `

    profileInfoBtn.addEventListener('click', () => {
        document.querySelector('.content').innerHTML = settingsProfileHTML;
    });

    document.querySelector('.content').replaceWith(loginAndSecurity);

})


