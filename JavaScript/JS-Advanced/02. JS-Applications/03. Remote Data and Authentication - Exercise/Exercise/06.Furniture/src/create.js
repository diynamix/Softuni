document.getElementById('user').style.display = 'inline-block';
document.getElementById('guest').style.display = 'none';

let userData = null;
userData = JSON.parse(sessionStorage.getItem('userData'));

document.getElementById('logoutBtn').addEventListener('click', onLogout);
// document.getElementById('buyBtn').addEventListener('click', onBuy);
// document.getElementById('show-orders-btn').addEventListener('click', showAllOrders);

const createForm = document.getElementById('create');
createForm.addEventListener('submit', onCreate);

const urlFurniture = 'http://localhost:3030/data/furniture';
// const urlOrders = 'http://localhost:3030/data/orders';

loadData();

// create product
async function onCreate(event) {
    event.preventDefault();
    try {
        const formData = new FormData(createForm);

        const name = formData.get('name');
        const price = formData.get('price');
        const decFactor = formData.get('factor');
        const img = formData.get('img');

        if (!name || !price || !decFactor || !img) {
            throw new Error('Invalid Input!');
        }

        const response = await fetch(urlFurniture, {
            method: 'post',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': userData.accessToken
            },
            body: JSON.stringify({ img, name, price, decFactor })
        });

        if (response.ok != true) {
            throw new Error(`Error: ${response.statusText}`);
        }

        createForm.reset();
        loadData();

    } catch (err) {
        alert(err.message);
    }
}