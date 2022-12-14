document.getElementById('user').style.display = 'inline-block';
document.getElementById('guest').style.display = 'none';

let userData = null;
userData = JSON.parse(sessionStorage.getItem('userData'));

document.getElementById('logoutBtn').addEventListener('click', onLogout);
document.getElementById('buyBtn').addEventListener('click', onBuy);
document.getElementById('show-orders-btn').addEventListener('click', showAllOrders);

const createForm = document.getElementById('create');
createForm.addEventListener('submit', onCreate);

const urlFurniture = 'http://localhost:3030/data/furniture';
const urlOrders = 'http://localhost:3030/data/orders';

loadData();

// create product
// async function onCreate(event) {
//     event.preventDefault();
//     try {
//         const formData = new FormData(createForm);

//         const name = formData.get('name');
//         const price = formData.get('price');
//         const decFactor = formData.get('factor');
//         const img = formData.get('img');

//         if (!name || !price || !decFactor || !img) {
//             throw new Error('Invalid Input!');
//         }

//         const response = await fetch(urlFurniture, {
//             method: 'post',
//             headers: {
//                 'Content-type': 'application/json',
//                 'X-Authorization': userData.accessToken
//             },
//             body: JSON.stringify({ img, name, price, decFactor })
//         });

//         if (response.ok != true) {
//             throw new Error(`Error: ${response.statusText}`);
//         }

//         createForm.reset();
//         loadData();

//     } catch (err) {
//         alert(err.message);
//     }
// }

// load products
async function loadData() {
    try {
        const response = await fetch(urlFurniture);
        const data = await response.json();

        const result = Object.values(data).map(createRow);
        document.querySelector('tbody').replaceChildren(...result);
    } catch (err) {
        alert(error.message);
    }
}

function createRow(data) {
    const row = document.createElement('tr');
    row.innerHTML =
        `<tr>
            <td><img src="${data.img}"></td>
            <td><p>${data.name}</p></td>
            <td><p>${data.price}</p></td>
            <td><p>${data.decFactor}</p></td>
            <td><input type="checkbox" /></td>
        </tr>`;
    return row;
}

// buy
async function onBuy(event) {
    // event.preventDefault();
    const checked = Array.from(document.querySelectorAll('tbody tr')).filter(tr => tr.querySelector('[type="checkbox"]').checked);
    checked.forEach(sendOrder);
}

async function sendOrder(data) {
    try {
        const img = data.querySelector('img').src;
        const name = data.querySelector('td:nth-child(2) p').textContent;
        const price = data.querySelector('td:nth-child(3) p').textContent;
        const decFactor = data.querySelector('td:nth-child(4) p').textContent;

        console.log(img, name, price, decFactor);

        const response = await fetch(urlOrders, {
            method: 'post',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': userData.accessToken
            },
            body: JSON.stringify({ img, name, price: Number(price), decFactor })
        });

        if (response.ok != true) {
            throw new Error(`Error: ${response.statusText}`);
        }

        // alert(`${name} bought`);

    } catch (err) {
        alert(err.message);
    }
}

// show all orders
async function showAllOrders(event) {
    // event.preventDefault();
    const allProductsSpan = event.target.parentElement.querySelector('p:nth-child(1) span');
    const totalPriceSpan = event.target.parentElement.querySelector('p:nth-child(2) span');
    // const urlGetOrders = `http://localhost:3030/data/orders?where=_ownerId%3D${userData.id}`
    const urlGetOrders = `http://localhost:3030/data/orders?where=_ownerId%3D%22${userData.id}%22`;

    const response = await fetch(urlGetOrders);
    const result = await response.json();

    let products = new Set();
    let totalPrice = 0;

    result.forEach(p => {
        products.add(p.name);
        totalPrice += Number(p.price);
    });

    allProductsSpan.textContent = Array.from(products).join(', ');
    totalPriceSpan.textContent = `${totalPrice} $`;
}

// log out
function onLogout() {
    if (userData) {
        const url = 'http://localhost:3030/users/logout';
        const token = userData.accessToken;

        fetch(url, {
            method: 'GET',
            headers: {
                'X-Authorization': token
            }
        });

        sessionStorage.clear();
        window.location = 'home.html';
    }
}