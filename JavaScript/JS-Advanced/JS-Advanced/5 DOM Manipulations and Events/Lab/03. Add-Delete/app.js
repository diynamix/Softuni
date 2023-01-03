//0/100
function addItem() {
    let ul = document.getElementById("items");

    let input = document.getElementById("newItemText");
    let value = input.value;
    if (value.length === 0) return;

    let li = document.createElement("li");
    li.textContent = value;

    let deleteBtn = document.createElement("a");
    deleteBtn.textContent = "[Delete]";
    deleteBtn.href = "#";

    deleteBtn.addEventListener("click", function (event) {
        event.target.parentElement.remove();
    })

    li.append(deleteBtn);

    ul.append(li);

    input.value = "";
}

//100/100 Presentation
function addItem2() {
    let newElement = document.getElementById("newItemText").value;
    let list = document.getElementById("items");
    if (newElement.length === 0) return;
    let listItem = document.createElement("li");
    listItem.textContent = newElement;
    let remove = document.createElement("a");
    let linkText = document.createTextNode("[Delete]");
    remove.appendChild(linkText);
    remove.href = "#";
    remove.addEventListener("click", deleteItem);

    listItem.appendChild(remove);
    list.appendChild(listItem);

    function deleteItem() {
        listItem.remove();
    }
}