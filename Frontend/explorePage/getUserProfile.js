let getUserProfileBtn = document.querySelector('.menu-text');

// getUserProfileBtn.addEventListener('click', () => {


    async function getUserProfile(searchText) {
        const url = 'http://localhost:7280/api/user/get-userprofile';



        fetch(url, {
            method: 'GET',
            referrerPolicy: "origin-when-cross-origin",
            headers: {
                'content-type': 'application/json; charset=utf-8',
                'Transfer-Encoding': 'chunked',
                'Data': new Date().toLocaleString(),
                'Server': "localhost",
                'Authorization':`Bearer ${localStorage.getItem('accessToken')}`
            },
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
        console.log(localStorage.getItem('accessToken'))
  }


// })



