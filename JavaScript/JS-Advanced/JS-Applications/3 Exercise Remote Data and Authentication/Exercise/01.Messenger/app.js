function attachEvents() {
    document.getElementById('submit').addEventListener('click', onSubmit);
    document.getElementById('refresh').addEventListener('click', loadMessages);
    loadMessages();
}

const authorInput = document.querySelector('input[name="author"]');
const contentInput = document.querySelector('input[name="content"]');
const list = document.getElementById('messages');

attachEvents();

// add single message to list
async function onSubmit() {
    const author = authorInput.value;
    const content = contentInput.value;

    const result = await createMessage({ author, content });

    // authorInput.value = '';
    contentInput.value = '';

    list.value += '\n' + `${author}: ${content}`;
}

// load and display all messages
async function loadMessages() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const res = await fetch(url);
    const data = await res.json();

    const messages = Object.values(data);

    list.value = messages.map(m => `${m.author}: ${m.content}`).join('\n');
}

// post message
async function createMessage(message) {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const option = {
        method: 'post',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(message)
    };

    const res = await fetch(url, option);
    const result = await res.json();

    return result;
}