import { html, nothing } from '../lib/lit-html.js';
import { repeat } from '../lib/directives/repeat.js';
import * as reservatioService from '../data/reservation.js';
import * as roomService from '../data/room.js';
import { submitHandler } from '../util.js';


const detailsTemplate = (room, hasUser, onDelete, onBook) => html`
<h2>${room.name}</h2>
<p>Location: ${room.location}</p>
<p>Beds: ${room.beds}</p>
${hasUser && !room.isOwner ? reservationForm(onBook) : nothing}
${hasUser && room.isOwner ? html`
<a href="/edit/${room.objectId}">Edit</a>
<a @click=${onDelete} href="javascript:void(0)">Delete</a>` : nothing}
${hasUser ? html`
<ul>
    ${repeat(room.reservations, r => r.objectId, reservationCard)}
</ul>` : nothing}`;

const reservationForm = (onSubmit) => html`
<form @submit=${onSubmit}>
    <label>From <input type="date" name="startDate"></label>
    <label>To <input type="date" name="endDate"></label>
    <button>Request reservation</button>
</form>`;

const reservationCard = (res) => html`
<li>
    From: ${res.startDate.toISOString().slice(0, 10)}
    To: ${res.startDate.toISOString().slice(0, 10)}
    By: ${res.owner.username}
</li>`;

export async function detailsView(ctx) {
    const id = ctx.params.id;
    const room = ctx.data;
    const hasUser = Boolean(ctx.user);
    room.isOwner = room.owner.objectId === ctx.user?.objectId;
    room.reservations = [];

    if (hasUser) {
        const result = await reservatioService.getByRoomId(id);
        room.reservations = result.results;
    }

    ctx.render(detailsTemplate(room, hasUser, onDelete, submitHandler(book)));

    async function onDelete() {
        const choice = confirm('Are you sure you want to take down this offer?');
        if (choice) {
            await roomService.deleteById(id);
            ctx.page.redirect('/rooms');
        }
    }

    async function book({ startDate, endDate }) {
        startDate = new Date(startDate);
        endDate = new Date(endDate);

        if (Number.isNaN(startDate.getDate())) {
            return alert('Invalid star date!');
        } else if (Number.isNaN(endDate.getDate())) {
            return alert('Invalid end date!');
        }
        if (endDate <= startDate) {
            return alert('End date must be after start date!');
        }

        const reservationDate = {
            startDate,
            endDate,
            room: id,
            host: ctx.data.owner.objectId
        };

        const result = await reservatioService.create(reservationDate, ctx.user.objectId);

        ctx.page.redirect('/rooms/' + id);
    }
}