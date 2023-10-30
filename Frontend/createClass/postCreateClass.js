

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
            'Authorization':`Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJhZTY4MDRiZi1lZGYzLTQ5ZTgtYTVjZS1jNDAyZjIxMDQwOTUiLCJlbWFpbCI6ImtsaW1wYXZsb3YyMDAyQGdtYWlsLmNvbSIsImp0aSI6ImY3MzAwYTRmLTY3MTEtNGYwOS05MzI5LTZiMmY0Zjg0NGM4MyIsImlhdCI6MTY5ODY2NzAyOCwiaXNWZXJpZmllZCI6IlRydWUiLCJpc0NyZWF0ZWRBY2NvdW50IjoiRmFsc2UiLCJuYmYiOjE2OTg2NjcwMjgsImV4cCI6MTY5ODc1MzE1NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo3MjgwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3MjgwIn0.ufqzCfvu--Rh54FMCFE6XoJ_O3S5swbuHckEDgFTlfs`
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

