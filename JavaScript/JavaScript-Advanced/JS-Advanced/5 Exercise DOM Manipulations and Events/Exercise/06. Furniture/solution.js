function solve() {
  let generateBtn = document.getElementsByTagName('button')[0];
  generateBtn.addEventListener('click', generate);

  let buyBtn = document.getElementsByTagName('button')[1];
  buyBtn.addEventListener('click', buy);

  function generate() {
    let textarea = document.getElementsByTagName('textarea')[0];
    let input = JSON.parse(textarea.value);

    for (let obj of input) {
      let tr = document.createElement('tr');
      tr.innerHTML =
        `<td><img src="${obj.img}"></td>` +
        `<td><p>${obj.name}</p></td>` +
        `<td><p>${(obj.price)}</p></td>` +
        `<td><p>${obj.decFactor}</p></td>` +
        '<td><input type="checkbox" /></td>';

      document.getElementsByTagName('tbody')[0].appendChild(tr);
    }

    textarea.value = "";
  }

  function buy() {
    let textArea = Array.from(document.querySelectorAll('textarea'))[1];
    let output = [];

    let toBuy = Array.from(document.querySelectorAll('input[type="checkbox"]'))
      .filter(e => e.checked === true)
      .map(e => e.parentNode.parentNode);

    let bought = toBuy
      .map(e => Array.from(e.querySelectorAll('td'))[1].innerText)
      .join(', ');

    output.push(`Bought furniture: ${bought}`);

    let totalPrice = toBuy
      .map(e => Array.from(e.querySelectorAll('td'))[2].innerText)
      .map(Number)
      .reduce((a, b) => a + b);

    output.push(`Total price: ${totalPrice.toFixed(2)}`);

    let averageFactor = toBuy
      .map(e => Array.from(e.querySelectorAll('td'))[3].innerText)
      .map(Number)
      .reduce((a, b) => a + b) / toBuy.length;

    output.push(`Average decoration factor: ${averageFactor}`);

    textArea.value = output.join('\n');
  }
}


//100/100 - from the web
function solve2() {
  let textarea = document.querySelectorAll('textarea');
  let tbody = document.querySelector('tbody');

  [...document.querySelectorAll('button')].forEach(btn => btn.addEventListener('click', execute));
  function execute(btn) {
    if (!textarea[0].value) return;
    if (btn.target.textContent === 'Generate') {
      let input = JSON.parse(textarea[0].value);
      input.forEach(furniture => {
        tbody.innerHTML += `<tr>
          <td><img src=${furniture.img}></td>
          <td><p>${furniture.name}</p></td>
          <td><p>${furniture.price}</p></td>
          <td><p>${furniture.decFactor}</p></td>
          <td><input type="checkbox"/></td>
          </tr>`
      })
    } else {
      let furnitureName = [];
      let totalPrice = 0;
      let averageDecFactor = 0;
      [...document.querySelectorAll('input:checked')]
        .forEach(furniture => {
          let parentRow = furniture.parentNode.parentNode;
          averageDecFactor += Number(parentRow.children[3].textContent);
          totalPrice += Number(parentRow.children[2].textContent);
          furnitureName.push(parentRow.children[1].textContent);
        });
      textarea[1].textContent += `Bought furniture: ${furnitureName.join(', ')}\n`;
      textarea[1].textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
      textarea[1].textContent += `Average decoration factor: ${averageDecFactor / furnitureName.length}`;
    }
  }
}