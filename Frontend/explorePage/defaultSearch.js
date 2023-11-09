async function defaultSearchRequest() {
    const url = 'http://localhost:7280/api/search/default-search-request';



    fetch(url, {
        method: 'GET',
        referrerPolicy: "origin-when-cross-origin",
        headers: {
            'content-type': 'application/json; charset=utf-8',
            'Transfer-Encoding': 'chunked',
            'Data': new Date().toLocaleString(),
            'Server': "localhost",
            'Authorization':`Bearer ${localStorage.getItem('verificationToken')}`
        },
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            else {
                throw new Error('Произошла ошибка при выполнении запроса.');
            }

        })
        .then(responseData => {
            console.log(responseData);
            localStorage.setItem('responseUserInfo', responseData)
        })
        .catch(error => {
            console.log(error);
        });
    console.log(localStorage.getItem('verificationToken'))
}