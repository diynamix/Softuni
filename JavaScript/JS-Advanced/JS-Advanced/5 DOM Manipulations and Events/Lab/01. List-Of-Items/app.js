function addItem() {
    let list = document.getElementById("items");

    let input = document.getElementById("newItemText");

    let newItemValue = input.value;

    let liItem = document.createElement("li");

    liItem.textContent = newItemValue;

    list.appendChild(liItem);

    input.value = "";
}