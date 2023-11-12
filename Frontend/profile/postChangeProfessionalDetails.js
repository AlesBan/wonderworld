async function postChangeProfessionalDetails() {
    const url = 'http://localhost:7280/api/edituser/professional-info';
    const data = {
        Languages: localStorage.getItem('editedLanguages').split(','),
        Disciplines: localStorage.getItem('editedLessons').split(','),
        Grades: localStorage.getItem('editedGrades').split(','),
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