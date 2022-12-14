const form = document.getElementById('form');
form.addEventListener('submit', onSubmit);

const url = 'http://localhost:3030/jsonstore/collections/students';

loadData();

async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(form);

    const firstName = formData.get('firstName');
    const lastName = formData.get('lastName');
    const facultyNumber = formData.get('facultyNumber');
    const grade = formData.get('grade');

    try {
        if (!firstName || !lastName || !facultyNumber || !grade) {
            throw new Error('Invalid Input!');
        }

        const response = await fetch(url, {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({ firstName, lastName, facultyNumber, grade })
        });

        if (!response.ok) {
            throw new Error(response.statusText);
        }

        form.reset();
        loadData();

    } catch (err) {
        alert(err.message);
    }
}

async function loadData() {
    try {
        const response = await fetch(url);

        if (!response.ok) {
            throw new Error(response.statusText);
        }

        const data = await response.json();

        const result = Object.values(data).map(createRow);

        document.querySelector('tbody').replaceChildren(...result);

    } catch (err) {
        alert(err.message);
    }
}

function createRow(data) {
    const row = document.createElement('tr');

    row.innerHTML =
        `<td>${data.firstName}</td>
        <td>${data.lastName}</td>
        <td>${data.facultyNumber}</td>
        <td>${data.grade}</td>`

    return row;
}