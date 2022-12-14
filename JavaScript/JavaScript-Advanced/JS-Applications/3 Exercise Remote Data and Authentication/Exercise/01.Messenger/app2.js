function attachEvents() {
    document.getElementById('submit').addEventListener('click', onSubmitMsg);
    document.getElementById('refresh').addEventListener('click', getMessages);
}

function onSubmitMsg() {
    const author = document.querySelector('input[name="author"]');
    const content = document.querySelector('input[name="content"]');

    const body = { author: author.value, content: content.value };

    author.value = '';
    content.value = '';

    createMessage(body);
}

async function getMessages() {
    const res = await fetch('http://localhost:3030/jsonstore/messenger');
    const data = await res.json();

    renderMessage(data);
}

async function createMessage(body) {
    const res = await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'post',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(body)
    });
    // const data = await res.json();
    // return data;
    getMessages();

}

function renderMessage(data) {
    const textarea = document.getElementById('messages');
    const content = Object.values(data).map(entry => `${entry.author}: ${entry.content}`).join('\n');
    textarea.textContent = content;
}

attachEvents();