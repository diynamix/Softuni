import page from './lib/page.mjs';
import { hasUser, isOwner } from './middlewares/guards.js';
import { preloadRoom } from './middlewares/preloader.js';
import { addRender } from './middlewares/render.js';
import { addSession } from './middlewares/session.js';
import { addUserNav } from './middlewares/userNav.js';
import { getUserData } from './util.js';
import { catalogView } from './views/catalog.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { logoutAction } from './views/logout.js';
import { navTemplate } from './views/nav.js';
import { registerView } from './views/register.js';


page(addRender(document.querySelector('main'), document.querySelector('header')));
page(addSession(getUserData));
page(addUserNav(navTemplate));

page('/', homeView);
page('/rooms', catalogView);
page('/rooms/:id', preloadRoom('id', 'rooms'), detailsView);
page('/host', hasUser(), createView);
page('/edit/:id', preloadRoom('id', 'rooms'), isOwner(), editView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutAction);

page.start();


/*
import page from './lib/page.mjs';
import { render, html } from './lib/lit-html.js';
import { until } from './lib/directives/until.js';


// const strings = {
//     BG: { greeting: 'Здравей!' },
//     EN: { greeting: 'Hello!' }
// };

// const locale = 'BG';

// const homeTemplate = (strings) => html`
// <h1>${strings[locale].greeting}</h1>`;

async function delayed() {
    await new Promise(r => setTimeout(r, 1000));

    // return homeTemplate(strings);
    return html`<h1>Hello</h1>`;
}

function home() {
    render(until(delayed(), html`<p>Loading...</p>`), document.body);
}

page('/', home);

page.start();
*/