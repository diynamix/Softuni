const tmp = document.getElementById('popup-template');


class InfoPopup extends HTMLElement {
    constructor() {
        super();

        this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        this.shadowRoot.appendChild(tmp.content.cloneNode(true));
        const imgSrc = this.getAttribute('img');
        if (imgSrc) {
            this.shadowRoot.querySelector('img').src = imgSrc;
        }
    }
}

customElements.define('info-popup', InfoPopup);