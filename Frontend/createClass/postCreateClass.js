

async function postCreateClass() {
    const url = 'http://localhost:7280/api/class/create-class';
    const disciplines = localStorage.getItem('disciplines').split(',');
    const grades = localStorage.getItem('grades');
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
            'Authorization':`Bearer ${localStorage.getItem('accessToken')}`
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

