// Получаем все элементы с классом "class-preview"
const classPreviews = document.querySelectorAll('.class-preview');

// Добавляем слушатель события клика на каждый элемент "class-preview"
classPreviews.forEach((classPreview) => {
    classPreview.addEventListener('click', () => {

        // Проверяем, содержит ли блок "class-preview" класс "expanded"
        const isExpanded = classPreview.classList.contains('expanded');
        // Создаем элемент крестика для закрытия

        if (!isExpanded) {
            const closeButton = document.createElement('span');
            closeButton.classList.add('class-preview-close');
            closeButton.innerHTML = '&times;';

            const inviteClassButton = document.createElement('button');
            inviteClassButton.classList.add('invite-class-btn');
            inviteClassButton.innerHTML = 'Invite class';

            // Добавляем крестик в блок "class-preview"
            const classPreviewContent = classPreview.querySelector('.class-preview-content');
            classPreviewContent.appendChild(closeButton);
            classPreviewContent.appendChild(inviteClassButton);

            // Добавляем класс "expanded" к выбранному элементу
            classPreview.classList.add('expanded');


            // Добавляем слушатель события клика на крестик
            closeButton.addEventListener('click', (event) => {
                event.stopPropagation();
                closeExpandedClassPreview(classPreview);
            });

            inviteClassButton.addEventListener('click', ()=> {
                closeExpandedClassPreview(classPreview);
                inviteClass()
                const inviteFormContainer = document.createElement('div');
                inviteFormContainer.classList.add('invite-form-container');

                // Добавляем inviteForm в контейнер
                inviteFormContainer.appendChild(inviteForm);

                // Добавляем контейнер с inviteForm в body
                document.body.appendChild(inviteFormContainer);

                // Добавляем стили для ограничения прокрутки только внутри inviteForm
                document.body.style.overflow = 'hidden';
                inviteFormContainer.style.overflow = 'auto';

                // Изменяем цвет фона страницы на серый
                document.body.style.backgroundColor = '#ccc';

            })

            // Добавляем слушатель события клика на весь документ
            document.addEventListener('click', (event) => {
                if (!event.target.closest('.class-preview')) {
                    closeExpandedClassPreview(classPreview);
                }
            });


        }
    });
});

// Функция для закрытия раскрытого блока "class-preview"
function closeExpandedClassPreview(classPreview) {
    // Удаляем крестик из блока "class-preview"
    const closeButton = classPreview.querySelector('.class-preview-close');
    const inviteClassButton = classPreview.querySelector('.invite-class-btn');
    if (closeButton) {
        closeButton.remove();
        inviteClassButton.remove();

    }

    // Удаляем класс "expanded" у выбранного элемента
    classPreview.classList.remove('expanded');

    // Удаляем слушатель события клика с документа
    document.removeEventListener('click', closeExpandedClassPreview);
}
