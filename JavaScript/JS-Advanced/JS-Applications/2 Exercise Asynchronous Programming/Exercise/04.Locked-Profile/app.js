async function lockedProfile() {
    const main = document.getElementById('main');

    main.innerHTML = '';

    const peopleUrl = 'http://localhost:3030/jsonstore/advanced/profiles';

    const res = await fetch(peopleUrl);
    const data = await res.json();

    let index = 1;

    for (let person of Object.values(data)) {
        const [id, username, email, age] = Object.values(person);
        let personHTMLProfile = createProfile(index++, username, email, age);
        main.appendChild(personHTMLProfile);
    }

    function createProfile(id, username, email, age) {
        const profileContainer = document.createElement('div');
        profileContainer.classList.add('profile');

        const profileImg = document.createElement('img');
        profileImg.classList.add('userIcon');
        profileImg.src = './iconProfile2.png';

        const labelLock = document.createElement('label');
        labelLock.textContent = 'Lock';
        const inputLock = createInputElement('radio', `user${id}Locked`, 'lock', 'checked');
        inputLock.addEventListener('click', function () { btn.disabled = true; });

        const labelUnlock = document.createElement('label');
        labelUnlock.textContent = 'Unlock';
        const inputUnlock = createInputElement('radio', `user${id}Locked`, 'unlock');
        inputUnlock.addEventListener('click', function () { btn.disabled = false; });
        // <br>
        // <hr>
        const labelUsername = document.createElement('label');
        labelUsername.textContent = 'Username';
        const inputUsername = createInputElement('text', `user${id}Username`, username, 'disabled', 'readonly');

        // div
        const profileInfoContainer = document.createElement('div');
        profileInfoContainer.id = `user1HiddenFields`;
        // <hr>
        const labelEmail = document.createElement('label');
        labelEmail.textContent = 'Email:';
        const inputEmail = createInputElement('email', `user${id}Email`, email, 'disabled', 'readonly');

        const labelAge = document.createElement('label');
        labelAge.textContent = 'Age:';
        const inputAge = createInputElement('text', `user${id}Age`, age, 'disabled', 'readonly');

        profileInfoContainer.appendChild(document.createElement('hr'));
        profileInfoContainer.appendChild(labelEmail);
        profileInfoContainer.appendChild(inputEmail);
        profileInfoContainer.appendChild(labelAge);
        profileInfoContainer.appendChild(inputAge);
        // profileInfoContainer.style.display = 'none';

        // button
        const btn = document.createElement('button');
        btn.textContent = 'Show more';
        btn.addEventListener('click', function (event) {
            if (event.target.parentNode.children[4].checked && event.target.textContent === 'Show more') {
                event.target.parentNode.children[9].style.display = 'inline';
                event.target.textContent = 'Hide it';
            } else if (event.target.parentNode.children[4].checked) {
                event.target.parentNode.children[9].style.display = 'none';
                event.target.textContent = 'Show more';
            }
            // if (btn.textContent == 'Show more') {
            //     btn.textContent = 'Hide it';
            //     profileInfoContainer.style.display = 'inline';
            // } else {
            //     btn.textContent = 'Show more';
            //     profileInfoContainer.style.display = 'none';
            // }
        });
        // btn.disabled = inputLock.checked ? true : false;

        // assemblying
        profileContainer.appendChild(profileImg);
        profileContainer.appendChild(labelLock);
        profileContainer.appendChild(inputLock);
        profileContainer.appendChild(labelUnlock);
        profileContainer.appendChild(inputUnlock);
        profileContainer.appendChild(document.createElement('br'));
        profileContainer.appendChild(document.createElement('hr'));
        profileContainer.appendChild(labelUsername);
        profileContainer.appendChild(inputUsername);
        profileContainer.appendChild(profileInfoContainer);
        profileContainer.appendChild(btn);
        return profileContainer;
    }

    function createInputElement(type, name, value, ...attributes) {
        const element = document.createElement('input');
        element.type = type;
        element.name = name;
        element.value = value;
        for (let attribute of attributes) {
            element.setAttribute(attribute, '');
        }
        return element;
    }
}

