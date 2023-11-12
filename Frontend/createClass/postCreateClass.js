

async function postCreateClass() {
    const url = 'http://localhost:7280/api/class/create-class';
    // const disciplines = localStorage.getItem('disciplines').split(',');
    const grades = localStorage.getItem('grades').split(',').map(str => parseInt(str)).toString();
    const data = {
        // Title: localStorage.getItem('classTitle'),
        Title: "hiClass",
        GradeNumber: grades,
        PhotoUrl: "photoUrl",
        LanguageTitles:  [
            localStorage.getItem('languages')
        ],
        DisciplineTitles: ["Geography"]
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
            'Authorization':`Bearer ${localStorage.getItem('verificationToken')}`
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

