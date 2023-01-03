window.addEventListener("load", solve);

function solve() {
    // input
    let type = document.getElementById('type-product');
    let description = document.getElementById('description');
    let name = document.getElementById('client-name');
    let phone = document.getElementById('client-phone');
    let submitBtn = document.querySelector('#right form button');
    submitBtn.addEventListener('click', submit);
    // reseived orders
    let receivedOrders = document.getElementById('received-orders');
    // completed orders
    let completedOrders = document.getElementById('completed-orders');
    let clearBtn = document.querySelector('#completed-orders button');
    clearBtn.addEventListener('click', clearCompletedOrders);

    function submit(e) {
        e.preventDefault();
        if (!description.value || !name.value || !phone.value) {
            return;
        }
        createOrder();
        clearInput();
    }

    function createOrder() {
        // div.container
        let div = document.createElement('div');
        div.classList.add('container');
        // h2
        let h2 = document.createElement('h2');
        h2.textContent = `Product type for repair: ${type.value}`;
        // h3
        let h3 = document.createElement('h3');
        h3.textContent = `Client information: ${name.value}, ${phone.value}`;
        // h4
        let h4 = document.createElement('h4');
        h4.textContent = `Description of the problem: ${description.value}`;
        // start button
        let startBtn = document.createElement('button');
        startBtn.classList.add('start-btn');
        startBtn.textContent = 'Start repair';
        startBtn.addEventListener('click', (e) => {
            startBtn.setAttribute('disabled', true);
            finishBtn.disabled = false;
        });
        // finish button
        let finishBtn = document.createElement('button');
        finishBtn.classList.add('finish-btn');
        finishBtn.textContent = 'Finish repair';
        finishBtn.setAttribute('disabled', true);
        finishBtn.addEventListener('click', (e) => {
            startBtn.remove();
            finishBtn.remove();
            completedOrders.appendChild(div);
        });

        div.appendChild(h2);
        div.appendChild(h3);
        div.appendChild(h4);
        div.appendChild(startBtn);
        div.appendChild(finishBtn);
        receivedOrders.appendChild(div);
    }

    function clearInput() {
        description.value = '';
        name.value = '';
        phone.value = '';
    }

    function clearCompletedOrders(e) {
        e.preventDefault();
        let ordersToClear = Array.from(completedOrders.querySelectorAll('div.container'));
        ordersToClear.forEach(order => order.remove());
    }
}