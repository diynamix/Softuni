function solve() {
    let [name, hall, ticketPrice] = Array.from(document.querySelectorAll('#container input'));

    document.querySelector('#container button').addEventListener('click', add);
    document.querySelector('#archive button').addEventListener('click', clear);

    let movies = document.querySelector('#movies ul');
    let archive = document.querySelector('#archive ul');

    function add(event) {
        event.preventDefault();
        let price = Number(ticketPrice.value);

        if (!name.value || !hall.value || !ticketPrice.value || isNaN(price)) {
            return;
        }

        const li = document.createElement('li');
        li.appendChild(createElement('span', name.value));

        const strong = createElement('strong', `Hall: ${hall.value}`);
        li.appendChild(strong);

        const div = createElement('div')
        div.appendChild(createElement('strong', `${price.toFixed(2)}`));

        const input = createElement('input', '', 'Tickets Sold');
        div.appendChild(input);

        const archiveBtn = createElement('button', 'Archive');
        const deleteBtn = createElement('button', 'Delete');
        div.appendChild(archiveBtn);

        li.appendChild(div);

        movies.appendChild(li);

        name.value = '';
        hall.value = '';
        ticketPrice.value = '';

        archiveBtn.addEventListener('click', onArchive);
        deleteBtn.addEventListener('click', onDelete);

        function onArchive(event) {
            event.preventDefault();
            let tickets = Number(input.value);
            if (!input.value || isNaN(tickets)) {
                return;
            }
            div.remove();
            let totalPrice = price * tickets;
            strong.textContent = `Total amount: ${totalPrice.toFixed(2)}`;
            li.appendChild(deleteBtn);
            archive.appendChild(li);
        }

        function onDelete(event) {
            event.preventDefault();
            li.remove();
        }
    }

    function clear() {
        archive.innerHTML = '';
    }

    function createElement(type, content, placeHolder) {
        const element = document.createElement(type);
        if (content) {
            element.textContent = content;
        }
        if (placeHolder) {
            element.placeholder = placeHolder;
        }
        return element;
    }
}