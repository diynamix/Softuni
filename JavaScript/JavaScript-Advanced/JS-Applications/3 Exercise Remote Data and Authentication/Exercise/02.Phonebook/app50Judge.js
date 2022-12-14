function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadContacts);
    document.getElementById('btnCreate').addEventListener('click', onCreate);

    list.addEventListener('click', onDelete);

    loadContacts();
}

const list = document.getElementById('phonebook');
const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

attachEvents();

async function onCreate() {
    const person = personInput.value;
    const phone = phoneInput.value;
    const contact = { person, phone };

    const result = await createContact(contact);

    list.appendChild(createItem(result));

    personInput.value = '';
    phoneInput.value = '';
}

async function loadContacts() {
    const res = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await res.json();
    list.replaceChildren(...Object.values(data).map(createItem));
}

function createItem(contact) {
    const li = document.createElement('li');
    li.innerHTML = `${contact.person}: ${contact.phone} <button data-id="${contact.id}">Delete</button>`;
    return li;
}

async function createContact(contact) {
    const res = await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(contact)
    });
    const data = await res.json();

    return data;
}

async function onDelete(ev) {
    const id = ev.target.dataset.id;
    if (id != undefined) {
        await deleteContact(id);
        ev.target.parentElement.remove();
    }
}

async function deleteContact(id) {
    const res = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
        method: 'delete'
    });
    const data = await res.json();

    return data;
}