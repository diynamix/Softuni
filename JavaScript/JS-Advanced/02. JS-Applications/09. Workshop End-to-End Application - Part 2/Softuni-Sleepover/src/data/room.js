import { addOwner, createPointer, encodeObject, filterRelation } from "../util.js";
import { get, post, put, del } from "./api.js";


const endPoint = {
    'rooms': `/classes/Room?where=${encodeObject({ openForBooking: true })}&include=owner`,

    'roomsWithUser': (userId) => `/classes/Room?where=${encodeObject({ $or: [{ openForBooking: true }, filterRelation('owner', '_User', userId)] })}&include=owner`,

    'roomById': '/classes/Room/'
};

export async function getAll(userId) {
    if (userId) {
        return get(endPoint.roomsWithUser(userId));
    } else {
        return get(endPoint.rooms);
    }
}

export async function getById(id) {
    return get(endPoint.roomById + id);
}

export async function create(roomData, userId) {
    return post(endPoint.rooms, addOwner(roomData, userId));
}

export async function update(id, roomData, userId) {
    return put(endPoint.roomById + id, addOwner(roomData, userId));
}

export async function deleteById(id) {
    return del(endPoint.roomById + id);
}