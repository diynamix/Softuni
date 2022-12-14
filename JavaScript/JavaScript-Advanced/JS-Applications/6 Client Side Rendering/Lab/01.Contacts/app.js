import { contacts as data } from './contacts.js';
import { html, render, nothing } from './node_modules/lit-html/lit-html.js';
// import { styleMap } from './node_modules/lit-html/directives/style-map.js';


// Вариант 2
// ---------------------------------------------------------------------

const contacts = data.map(c => Object.assign({}, c, { active: false }));

const root = document.getElementById('contacts');

const contactCard = (contact, onToggle) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${contact.name}</h2>
        <button id=${contact.id} class="detailsBtn" @click=${onToggle.bind(null, contact)}>Details</button>

        ${contact.active
        ? html
        `<div class="details">
            <p>Phone number: ${contact.phoneNumber}</p>
            <p>Email: ${contact.email}</p>
        </div>`
        : nothing}

    </div>
</div>`;

// root.addEventListener('click', toggleDetails);
update();

function onToggle(contact) {
    contact.active = !contact.active;
    update();
}

// function toggleDetails(event) {
//     if (event.target.classList.contains('detailsBtn')) {
//         const id = event.target.id;
//         const contact = contacts.find(c => c.id == id);
//         contact.active = !contact.active;
//         update();
//     }
// }

function update() {
    render(contacts.map(c => contactCard(c, onToggle)), root);
}


// Вариант 1
// ---------------------------------------------------------------------
/**
const root = document.getElementById('contacts');

const contactCard = (contact, style = {}) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${contact.name}</h2>
        <button class="detailsBtn">Details</button>
        <div style=${styleMap(style)} class="details" id=${contact.id}>
            <p>Phone number: ${contact.phoneNumber}</p>
            <p>Email: ${contact.email}</p>
        </div>
    </div>
</div>`;

root.addEventListener('click', toggleDetails);

render(contacts.map(c => contactCard(c, { display: 'block' })), root);

function toggleDetails(event) {
    if (event.target.classList.contains('detailsBtn')) {
        const parent = event.target.parentElement;
        const details = parent.querySelector('.details');
        if (details.style.display == 'block') {
            details.style.display = 'none';
        } else {
            details.style.display = 'block'
        }
    }
}
*/