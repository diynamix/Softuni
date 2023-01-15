import * as api from './api.js';

const endPoints = {
    'create': '/data/ideas',
    'ideaById': '/data/ideas/',
    'ideas': '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc',
};

export async function getAllIdeas() {
    return api.get(endPoints.ideas);
}

export async function getById(id) {
    return api.get(endPoints.ideaById + id);
}

export async function createIdea(ideaData) {
    return api.post(endPoints.create, ideaData);
}

export async function deleteById(id) {
    return api.delete(endPoints.ideaById + id);
}