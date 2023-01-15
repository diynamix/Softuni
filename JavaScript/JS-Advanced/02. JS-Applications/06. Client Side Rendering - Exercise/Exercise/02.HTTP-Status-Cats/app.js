import { cats as catData } from './catSeeder.js';
import { html, render } from './node_modules/lit-html/lit-html.js';

// template:
// contains cat info
// has toggle button
const catCard = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button @click=${()=> toggleInfo(cat)} class="showBtn">${cat.info ? 'Hide' : 'Show'} status code</button>
        ${cat.info ? html`<div class="status" id=${cat.id}>
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>` : null}
    </div>
</li>`;

// start:
// parse imported data
// pass to template
const root = document.getElementById('allCats');
catData.forEach(c => c.info = false);
update();

function update() {
    render(html`<ul>${catData.map(catCard)}</ul>`, root);
}

function toggleInfo(cat) {
    cat.info = !cat.info;
    update();
}

//-------------------------------------------------------------------
/**
import { cats as catData } from './catSeeder.js';
import { html, render } from './node_modules/lit-html/lit-html.js';

// template:
// contains cat info
// has toggle button
const catCard = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id=${cat.id}>
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>`;

// start:
// parse imported data
// pass to template
const root = document.getElementById('allCats');
render(html`<ul>${catData.map(catCard)}</ul>`, root);

root.addEventListener('click', (ev) => {
    if (ev.target.tagName == 'BUTTON') {
        const element = ev.target.parentNode.querySelector('.status');
        if (element.style.display == 'none') {
            element.style.display = 'block';
            ev.target.textContent = 'Hide status code';
        } else {
            element.style.display = 'none';
            ev.target.textContent = 'Show status code';
        }
    }
});
*/