

async function postCreateClass() {
    const url = 'http://localhost:7280/api/class/create-class';
    const disciplines = localStorage.getItem('disciplines').split(',');
    const grades = localStorage.getItem('grades').split(',').map(str => parseInt(str));
    const data = {
        Title: localStorage.getItem('classTitle'),
        GradeNumber: grades,
        PhotoUrl: "photoUrl",
        LanguageTitles:  [
            localStorage.getItem('languages')
        ],
        DisciplineTitles: disciplines
    };

    console.log(JSON.stringify(data));

    fetch(url, {
        method: 'POST',
        referrerPolicy: "origin-when-cross-origin",
        headers: {
            'content-type': 'application/json; charset=utf-8',
            'Transfer-Encoding': 'chunked',
            'Data': new Date().toLocaleString(),
            'Server': "localhost",
            'Authorization':`Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkZTQ1ZmNkZi03N2VkLTQ4NjEtODI5My02NTNiYmFhNDU0YzciLCJlbWFpbCI6IktsaW1wYXVsYXVAaWNsb3VkLmNvbSIsImp0aSI6ImEzNDg0YTM1LTQ0NzUtNDkzMS1hMGNmLWQwMzYzMjg5ZTQyNiIsImlhdCI6MTY5ODg0ODM0NywiaXNWZXJpZmllZCI6IlRydWUiLCJpc0NyZWF0ZWRBY2NvdW50IjoiRmFsc2UiLCJuYmYiOjE2OTg4NDgzNDcsImV4cCI6MTY5ODkzNDYyMCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo3MjgwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3MjgwIn0.L1du5cvJ8ZUGQ6hZCi27R_h3aTXx6m7Q9j3rLzqeU08`
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

