let addClassBtn = document.querySelector('#addClass');

addClassBtn.addEventListener('click', () => {
    let addClass = document.createElement('div');
    document.body.append(addClass)
    addClass.innerHTML = `
    <div class="modal">
    <div class="modal-top">
        <div class="createClass">Create class</div>
        <div class=""><img src="../images/Cross.svg" alt=""></div>
    </div>
    <div class="modal-bar">
        <div class="modal-bar-section">
            <div class="class-photo-header">Class photo (required)</div>
        </div>
        <div class="modal-bar-column">
            <div class="class-title">
                <div class="input-title">Title</div>
                <div class="">
                    <label><input name="institution-name" class="class-title-input" type="text"
                                  placeholder="Class title"></label>
                </div>
            </div>ые
            <div class="class-grade-and-age">
                <div class="grade-title">
                    <div class="input-title">Grade</div>
                    <div class="select-btn">
                        <span class="btn-text">Select grade</span>
                        <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
                    </div>
                    <ul class="list-items">

                    </ul>
                </div>
                <div class=age-title">
                    <div class="input-title">Age</div>
                    <div class="select-btn">
                        <span class="btn-text">Select age</span>
                        <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
                    </div>
                    <ul class="list-items">

                    </ul>
                </div>
            </div>
            <div class="class-subjects">
                <div class="input-title">Subjects</div>
                <div class="select-btn">
                    <span class="btn-text">Select subjects</span>
                    <span class="arrow-dwn">
        <img src="../images/chevron-down.svg" alt="">
    </span>
                </div>
                <ul class="list-items">

                </ul>
            </div>
            <div class="class-description">
                <div class="input-title">Description</div>
                <div class="">
                    <label><input name="institution-name" class="class-title-input" type="text"
                                  placeholder="Class description"></label>
                </div>
            </div>
        </div>
    </div>
    <div class="modal-bottom">
        <div class="cancel">cancel</div>
        <div class="create">create</div>
    </div>
</div>
    
    `
})