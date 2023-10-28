const inviteForm = document.createElement('div');
inviteForm.innerHTML = `
     <div class="invite-form" id="invite-form">
     <div class="invite-container">
    <div class="invite-form-top">
        <div class="createClass">Invite for a call</div>
        <div class=""><img src="../images/Cross.svg" alt=""></div>
    </div>
    <div class="invite-dropdowns">
        <div class="dropdown-section-left">
            <div class="class-subjects">
                <div class="input-title">Subject</div>
                <div class="select-btn" id="select-subjects">
                    <span class="btn-text" id="output-subjects">Select subjects</span>
                    <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
                </div>
                <ul class="list-items" id="list-subjects">

                </ul>
            </div>  
        </div>
        <div class="dropdown-section-right">
                    <div class="class-subjects">
                <div class="input-title">Date</div>
                <div class="select-btn" id="select-subjects">
                  <input class="calendar" type="date" name="Date" id="davaToday">
                </div>
                <ul class="list-items" id="list-subjects">

                </ul>
            </div>
           
        </div>
    </div>
    <div class="select-your-class">
        <div class="class-preview">
                <div class="class-preview-content">
                    <div class="class-preview-image"><img src="../images/class-preview-image.svg" alt=""></div>
                    <div class="personal-info">
                        <div class="avatar-explorePage"><img src="../images/avatar.svg" alt=""></div>
                        <div class="username">Elizaveta Ermakova</div>
                    </div>
                    <div class="class-preview-text">Lorem ipsum dolor sit amet consectetur. Dictumst faucibus ac sit
                        amet
                    </div>
                    <div class="class-preview-footer">
                        <div class="class-preview-tags">
                            <div class="class-preview-tag">Geography</div>
                            <div class="class-preview-tag">10th grade</div>
                            <div class="class-preview-tag">Math</div>
                            <div class="class-preview-tag">10th grade</div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    <div class="invite-form-bottom">
        <div class="username"></div>
        <div class="cancel-btn" id="cancel-invite-form">cancel</div>
        <div class="update-btn" id="send-invite-btn">Send call invite</div>
    </div>
    <div>
</div>
`






function inviteClass() {
    document.body.append(inviteForm)

    const selectBtn = document.querySelector('#select-subjects');
    const selectedValues = [];
    const selectedValuesDiv = document.querySelector("#output-subjects");


    selectBtn.addEventListener("click", () => {
        selectBtn.classList.toggle("open");
    });


    const lessons = document.querySelector('#list-subjects');

    let filterFn = (lesson) => true;
    generateItems(ALL_LESSONS);

    function generateItems(items) {

        const html = items.filter(filterFn).map(lesson => {
            return `

 <li class="item">
        <span class="item-text" id="item-lessons">${lesson.title}</span>
        <span class="checkbox"><i class="fa-solid fa-check check-icon"></i></span>
    </li>
    `;
        })

            .join('');

        lessons.innerHTML = html;




        items = document.querySelectorAll('.item');
        items.forEach(item => {
            item.addEventListener("click", () => {
                item.classList.toggle("checked");
                const itemText = item.querySelector("#item-lessons").textContent;
                if (item.classList.contains("checked")) {
                    selectedValues.push(itemText);
                } else {
                    const index = selectedValues.indexOf(itemText);
                    if (index !== -1) {
                        selectedValues.splice(index, 1);
                    }
                }
                selectedValuesDiv.innerHTML = selectedValues.map(value => `<span>${value}</span>`).join(", ");


            });


        })

    }


    closeInviteForm()
}

function closeInviteForm() {
    const cancelInviteButton = document.querySelector('#cancel-invite-form');
    cancelInviteButton.addEventListener('click', () => {
        inviteForm.remove()


    })

    document.removeEventListener('click', closeInviteForm);


}




