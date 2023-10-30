function choosePhoto() {


    let chooseWork = document.createElement('div');
    document.body.append(chooseWork)
    chooseWork.innerHTML = `
    <div class="createAccount">
  <div class="title-and-subtle">
    <div class="title">Nearly there!</div>
    <div class="label-and-CTA">
      <div class="label">Last but not least, a profile photo will let people know who they are connecting with</div>
      </div>
  </div>
  <div class="content-body">
    
    </div>
    <button onclick="postCreateAccount()" class="primary-button">Finish</button>
  </div>
    `

    document.querySelector('.createAccount').replaceWith(chooseWork);

}