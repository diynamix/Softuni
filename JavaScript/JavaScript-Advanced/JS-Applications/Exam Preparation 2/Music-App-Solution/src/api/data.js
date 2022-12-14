import { get, post, put, del } from "./api.js"

export async function getAll() {
    return get('/data/albums?sortBy=_createdOn%20desc&distinct=name');
}

export async function getById(id) {
    return get('/data/albums/' + id);
}

export async function deleteById(id) {
    return del('/data/albums/' + id);
}

export async function createAlbum(petData) {
    return post('/data/albums', petData);
}

export async function editAlbum(id, petData) {
    return put('/data/albums/' + id, petData);
}

export async function search(query) {
    return get(`/data/albums?where=name%20LIKE%20%22${query}%22`);
}