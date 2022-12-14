window.addEventListener('DOMContentLoaded', () => {
    document.getElementById('login-form').addEventListener('submit', onLogin);

    document.getElementById('user').style.display = 'none';
    document.getElementById('guest').style.display = 'inline-block';
});

async function onLogin(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/login';
    const formData = new FormData(event.target);

    const email = formData.get('email');
    const password = formData.get('password');

    const errorP = document.querySelector('p.notification');
    errorP.textContent = '';

    try {
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const result = await response.json();

        // const token = result.accessToken;
        // sessionStorage.setItem('accessToken', token);

        const userData = {
            email: result.email,
            id: result._id,
            accessToken: result.accessToken
        };

        // localStorage.setItem('userData', JSON.stringify(userData));
        sessionStorage.setItem('userData', JSON.stringify(userData));

        window.location = './index.html';

    } catch (err) {
        errorP.textContent = `Error: ${err.message}`;
    }
}