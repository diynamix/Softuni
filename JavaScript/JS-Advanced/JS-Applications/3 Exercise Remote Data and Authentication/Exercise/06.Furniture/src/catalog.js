document.getElementById('user').style.display = 'none';
document.getElementById('guest').style.display = 'inline-block';

const urlFurniture = 'http://localhost:3030/data/furniture';

loadData();
// load data (not logged)
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
                <td><input type="checkbox" disabled /></td>
            </tr>`;
    return row;
}