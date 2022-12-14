window.addEventListener('DOMContentLoaded', () => {
    document.getElementById('register-form').addEventListener('submit', onRegister);

    document.getElementById('user').style.display = 'none';
    document.getElementById('guest').style.display = 'inline-block';
});

async function onRegister(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/register';
    const formData = new FormData(event.target);

    const email = formData.get('email');
    const password = formData.get('password');
    const repass = formData.get('rePass');

    const errorP = document.querySelector('p.notification');
    errorP.textContent = '';

    try {
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok != true) {
            // || response.status != 200
            const error = await response.json();
            throw new Error(error.message);
        }

        if (password != repass) {
            throw new Error('Invalid Password!');
        }

        const result = await response.json();

        // const token = result.accessToken;
        // sessionStorage.setItem('accessToken', token);

        const userData = {
            email: result.email,
            id: result._id,
            accessToken: result.accessToken
        };

        sessionStorage.setItem('userData', JSON.stringify(userData));

        window.location = './index.html';

    } catch (err) {
        errorP.textContent = `Error: ${err.message}`;
    }
}