 async function postInviteClass() {
    const url = 'http://localhost:7280/api/Invitation/create-invitation';
    const data = {
         ClassSenderId: localStorage.getItem('classSenderId'),
         ClassReceiverId: "122df745-d85a-4753-b8fd-25cfa5b566a3",
         DateOfInvitation: "2023-11-05",
         InvitationText: "lets call"
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


