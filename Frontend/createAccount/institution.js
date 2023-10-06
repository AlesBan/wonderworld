function chooseInstitution() {
    const inputValueLocation = document.querySelector('#locationValue').value;
    const inputValueLanguages = document.querySelector('#languagesValue').value;

    localStorage.setItem('location', inputValueLocation);
    localStorage.setItem('languages', inputValueLanguages);

    let institution = document.createElement('div');
    document.body.append(institution)
    institution.innerHTML = `
    <div class="createAccount">
  <div class="title-and-subtle">
    <div class="title">Welcome <div class="first-name-output">${localStorage.getItem('firstName')}</div></div>
    <div class="label-and-CTA">
      <div class="label">It’s great to have you with us! To help us optimise your experience, tell us what you plan to use WonderWorld for.</div>
      </div>
  </div>
  <div class="content-body">
    <div class="inputs">
      <div class="first-name">
        <div class="input-title">Institution name</div>
        <div class="">
          <label><input name="first-name" class="first-name-input" id="institutionValue"
           oninput="searchOrg()" type="text" placeholder="e.g. Gymnasium No. 7, Minsk"></label>
        </div>
        <ul class="institution-items">
    
        </ul>
      </div>
    </div>
  </div>
  <button onclick="searchOrg()" class="primary-button" id="search">Search</button>
    <button onclick="chooseWork()" class="primary-button">Continue</button>
  </div>
    `

    document.querySelector('.createAccount').replaceWith(institution);

}

async function fetchOrg(searchText) {
    let response = await fetch(`https://search-maps.yandex.ru/v1/?text=${searchText}&type=biz&lang=ru_RU&apikey=6d742c7a-847a-40eb-b9a2-ae34493ad1f8
    
`);

    let data = await response.json();
    return data;
}




function renderOrg(items) {
    console.log(items);
    let target = document.querySelector('.institution-items')
    const html = items.map(item => {
        return `

 <li class="item">
        <span class="item-text">${item.properties.description}</span>
    </li>
    `;
    })
        .join('');

    target.innerHTML = html;
    target.style.display = items.length > 0 ? 'block' : 'none';

    const itemElements = document.querySelectorAll('.item');
    itemElements.forEach(item => {
        item.addEventListener('click', () => {
            const selectedValue = item.querySelector('.item-text').textContent;
            document.querySelector('#institutionValue').value = selectedValue;
            localStorage.setItem('selectedValue', selectedValue);
        });
    });

}


async function searchOrg() {
    const searchInput = document.querySelector('#institutionValue');
    const text = searchInput.value.toLowerCase();
    const response = await fetchOrg(text);
    let items = response.features.filter(item => {
        return item.properties.description.toLowerCase();
    });
    console.log(items);

    renderOrg(items)
}

