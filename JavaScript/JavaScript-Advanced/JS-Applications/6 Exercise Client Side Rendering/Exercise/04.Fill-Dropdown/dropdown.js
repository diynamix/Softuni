import { html, render } from './node_modules/lit-html/lit-html.js';


const selectTemplate = (items) => html`
<select id="menu">
    ${items.map(i => html`<option value=${i._id}>${i.text}</option>`)}
</select>`;

// start:
// add event lesteners
// call getData
const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const root = document.querySelector('div');
document.querySelector('form').addEventListener('submit', addItem);
getData();


// getData:
// fetch and fetch data
// call update
async function getData() {
    const response = await fetch(url);
    const data = await response.json();

    update(Object.values(data));
}

// update:
// render template
function update(items) {
    const result = selectTemplate(items);
    render(result, root);
}

// add item:
// read input
// make POST request
// on success, call getData
async function addItem(ev) {
    ev.preventDefault();
    const text = document.getElementById('itemText').value;

    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text })
    });

    if (response.ok) {
        getData()
    }
}