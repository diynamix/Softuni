function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', onLoad);
    document.getElementById('btnCreate').addEventListener('click', onCreate);
}

async function onLoad() {
    const res = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await res.json();

    return renderRecord(data);
}

function renderRecord(data) {
    const ul = document.getElementById('phonebook');
    ul.innerHTML = '';

    Object.values(data).forEach(rec => {
        const li = document.createElement('li');
        li.textContent = `${rec.person}: ${rec.phone}`;
        li.setAttribute('data-id', rec._id);

        const btn = document.createElement('button');
        btn.textContent = 'Delete';
        btn.addEventListener('click', onDelete);
        li.appendChild(btn);

        ul.appendChild(li);
    });
}

function onCreate() {
    const person = document.getElementById('person');
    const phone = document.getElementById('phone');

    handleCreate(person.value, phone.value);

    person.value = '';
    phone.value = '';
}

async function handleCreate(person, phone) {
    const res = await fetch('http://localhost:3030/jsonstore/phonebook',
        getHeader('post', { person, phone }));

    const data = await res.json();

    onLoad();
    return data;
}

function onDelete(ev) {
    const li = ev.target.parentElement;
    const id = li.getAttribute('data-id');
    handleDelete(id);
    li.remove();
}

async function handleDelete(id) {
    const res = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`,
        getHeader('delete', null));

    const data = await res.json();

    return data;
}

function getHeader(method, body) {
    return {
        method,
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(body)
    };
}

attachEvents();