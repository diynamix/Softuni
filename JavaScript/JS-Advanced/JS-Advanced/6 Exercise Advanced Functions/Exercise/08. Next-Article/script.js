function getArticleGenerator(articles) {
    const div = document.getElementById('content');

    return function () {
        let article = articles.shift();
        if (article != undefined) {
            let element = document.createElement('article');
            element.textContent = article;
            div.appendChild(element);
        }
    }
}