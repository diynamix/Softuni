import { html } from '../lib/lit-html.js';

export const navTemplate = (hasUser, username) => html`
    <nav>
        <a href="/">Home</a>
        <a href="/rooms">Rooms</a>
        ${hasUser
            ? html`
                <a href="/host">Host</a>
                <span>Welcome, ${username}!</span>
                <a href="/logout">Logout</a>`
            : html`
                <a href="/login">Login</a>
                <a href="/register">Register</a>`}
    </nav>`;