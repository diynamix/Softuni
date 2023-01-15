// global variables
let userData = null;

const navUser = document.getElementById('user');
const navGuest = document.getElementById('guest');

const addFormBtn = document.querySelector('#addForm .add');
const userNamePlaceholder = document.querySelector('nav p span');

const catches = document.getElementById('catches');

loadData();

// onLoadWindow
window.addEventListener('DOMContentLoaded', () => {
    userData = JSON.parse(sessionStorage.getItem('userData'));

    navUser.style.display = userData ? 'inline-block' : 'none';
    navGuest.style.display = userData ? 'none' : 'inline-block';
    addFormBtn.disabled = userData ? false : true;
    userNamePlaceholder.textContent = userData ? userData.email : 'guest';

    document.querySelector('.load').addEventListener('click', loadData);
    document.getElementById('addForm').addEventListener('submit', onCreateSubmit);
    document.getElementById('logout').addEventListener('click', onLogout);
    catches.addEventListener('click', onCatches);

    // loadData();
});

// create catch
async function onCreateSubmit(event) {
    event.preventDefault();
    if (!userData) {
        return;
    }

    const formData = new FormData(event.target);

    const data = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, { [k]: v }), {});

    try {
        if (Object.values(data).some(x => x == '')) {
            throw new Error('All fields are required!');
        }

        const response = await fetch('http://localhost:3030/data/catches', {
            method: 'post',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': userData.accessToken
            },
            body: JSON.stringify(data)
        });

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        event.target.reset();
        loadData();

    } catch (err) {
        alert(err.message);
    }
}

// load data
async function loadData() {
    const res = await fetch('http://localhost:3030/data/catches');
    const data = await res.json();

    catches.replaceChildren(...data.map(createPreview));
}

function createPreview(item) {
    const isOwner = userData && item._ownerId == userData.id;

    const element = document.createElement('div');
    element.className = 'catch';
    element.innerHTML =
        `<label>Angler</label>
        <input type="text" class="angler" value="${item.angler}" ${!isOwner ? 'disabled' : ''}>
        <label>Weight</label>
        <input type="text" class="weight" value="${item.weight}" ${!isOwner ? 'disabled' : ''}>
        <label>Species</label>
        <input type="text" class="species" value="${item.species}" ${!isOwner ? 'disabled' : ''}>
        <label>Location</label>
        <input type="text" class="location" value="${item.location}" ${!isOwner ? 'disabled' : ''}>
        <label>Bait</label>
        <input type="text" class="bait" value="${item.bait}" ${!isOwner ? 'disabled' : ''}>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${item.captureTime}" ${!isOwner ? 'disabled' : ''}>
        <button class="update" data-id="${item._id}" ${!isOwner ? 'disabled' : ''}>Update</button>
        <button class="delete" data-id="${item._id}" ${!isOwner ? 'disabled' : ''}>Delete</button>
        </div>`;

    return element;
}

// update / delete catch
function onCatches(event) {
    if (!userData) {
        return;
    }

    if (event.target.tagName == 'BUTTON' && event.target.textContent == 'Update') {
        updateCatch(event.target);
    } else if (event.target.tagName == 'BUTTON' && event.target.textContent == 'Delete') {
        deleteCatch(event.target);
    }
}

// update catch
async function updateCatch(updateBtn) {
    try {
        const container = updateBtn.parentElement;

        const url = 'http://localhost:3030/data/catches/' + updateBtn.dataset.id;

        const option = {
            method: 'put',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': userData.accessToken
            },
            body: JSON.stringify({
                angler: container.querySelector('.angler').value,
                weight: container.querySelector('.weight').value,
                species: container.querySelector('.species').value,
                location: container.querySelector('.location').value,
                bait: container.querySelector('.bait').value,
                captureTime: container.querySelector('.captureTime').value
            })
        };

        const response = await fetch(url, option);

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }
    } catch (err) {
        alert(err.message);
    }
}

// delete catch
async function deleteCatch(deleteBtn) {
    try {
        const container = deleteBtn.parentElement;

        const url = 'http://localhost:3030/data/catches/' + deleteBtn.dataset.id;

        const option = {
            method: 'delete',
            headers: {
                'X-Authorization': userData.accessToken
            }
        };

        const response = await fetch(url, option);

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        container.remove();
    } catch (err) {
        alert(err.message);
    }
}

// log out
function onLogout() {
    if (userData) {
        const url = 'http://localhost:3030/users/logout';
        const token = userData.accessToken;

        fetch(url, {
            method: 'get',
            headers: {
                'X-Authorization': token
            }
        });

        sessionStorage.clear();
        location.reload();
    }
}