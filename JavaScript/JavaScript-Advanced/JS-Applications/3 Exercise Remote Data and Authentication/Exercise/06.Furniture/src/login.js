document.getElementById('user').style.display = 'none';
document.getElementById('guest').style.display = 'inline-block';

// document.getElementById('register-form').addEventListener('submit', onRegister);
document.getElementById('login-form').addEventListener('submit', onLogin);

// register
// async function onRegister(event) {
//     event.preventDefault();
//     console.log('in register');
//     const url = 'http://localhost:3030/users/register';
//     const formData = new FormData(event.target);

//     const email = formData.get('email');
//     const password = formData.get('password');
//     const repass = formData.get('rePass');

//     try {
//         if (!email || !password || !repass) {
//             throw new Error('Invalid Input!');
//         }

//         if (password != repass) {
//             throw new Error('Invalid Password!');
//         }

//         const response = await fetch(url, {
//             method: 'post',
//             headers: {
//                 'Content-type': 'application/json',
//             },
//             body: JSON.stringify({ email, password })
//         });

//         if (response.ok != true) {
//             // || response.status != 200
//             const error = await response.json();
//             throw new Error(error.message);
//         }

//         const result = await response.json();

//         const userData = {
//             email: result.email,
//             id: result._id,
//             accessToken: result.accessToken
//         };
//         sessionStorage.setItem('userData', JSON.stringify(userData));

//         // const token = result.accessToken;
//         // sessionStorage.setItem('accessToken', token);
//         // localStorage.setItem('accessToken', token);

//         window.location = 'catalogLogged.html';

//     } catch (err) {
//         alert(`Error: ${err.message}`);
//     }
// }

// login
async function onLogin(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/login';
    const formData = new FormData(event.target);

    const email = formData.get('email');
    const password = formData.get('password');

    try {
        if (!email || !password) {
            throw new Error('Invalid Input!');
        }

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

        const userData = {
            email: result.email,
            id: result._id,
            accessToken: result.accessToken
        };
        sessionStorage.setItem('userData', JSON.stringify(userData));

        // const token = result.accessToken;
        // sessionStorage.setItem('accessToken', token);

        window.location = 'catalogLogged.html';

    } catch (err) {
        alert(`Error: ${err.message}`);
    }
}