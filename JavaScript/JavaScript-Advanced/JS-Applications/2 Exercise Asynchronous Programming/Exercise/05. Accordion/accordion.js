async function solution() {
    const main = document.getElementById('main');
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

    const res = await fetch(url);
    const data = await res.json();
    const idList = Object.values(data).map(d => Object.values(d)[0]);

    idList.forEach(id => {
        getArticle(id);
    });

    async function getArticle(id) {
        const articleUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
        const articleRes = await fetch(articleUrl);
        const articleData = await articleRes.json();

        main.appendChild(createHtml(articleData));
    }

    function createHtml(articleData) {
        const [id, title, content] = Object.values(articleData);
        const accordion = document.createElement('div');
        accordion.classList.add('accordion');

        const head = document.createElement('div');
        head.classList.add('head');

        const titleSpan = document.createElement('span');
        titleSpan.textContent = title;

        const button = document.createElement('button');
        button.classList.add('button');
        button.id = id;
        button.textContent = 'More';
        button.addEventListener('click', (e) => {
            const hidden = e.target.parentElement.parentElement.querySelector('.extra');
            if (e.target.textContent == 'More') {
                e.target.textContent = 'Less';
                hidden.style.display = 'block';
            } else {
                e.target.textContent = 'More';
                hidden.style.display = 'none';
            }
        });

        head.appendChild(titleSpan);
        head.appendChild(button);

        const extra = document.createElement('div');
        extra.classList.add('extra');

        const contentParagraph = document.createElement('p');
        contentParagraph.textContent = content;

        extra.appendChild(contentParagraph);

        accordion.appendChild(head);
        accordion.appendChild(extra);

        return accordion;
    }

}
solution();