async function postChangeInstitution() {
    const url = 'http://localhost:7280/api/edituser/institution';
    const apiData = await fetchInstitution(document.querySelector('#changeInstitution').value);
    let types = ["School"];
    const establishmentFields = apiData.features[0].properties;
    const data = {
        InstitutionTitle: establishmentFields.name,
        Address: establishmentFields.description,
        Types: types,
    };

    console.log(JSON.stringify(data));

    fetch(url, {
        method: 'PUT',
        referrerPolicy: "origin-when-cross-origin",
        headers: {
            'content-type': 'application/json; charset=utf-8',
            'Transfer-Encoding': 'chunked',
            'Data': new Date().toLocaleString(),
            'Server': "localhost",
            'Authorization': `Bearer ${localStorage.getItem('verificationToken')}`
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Произошла ошибка при выполнении запроса.');
            }
        })
        .then(responseData => {
            console.log(responseData);
        })
        .catch(error => {
            console.log(error);
        });
}