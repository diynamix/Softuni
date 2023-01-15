import { html, render as litRender } from './node_modules/lit-html/lit-html.js';

const template = (info, onToggle) => html`
<article>
    <h2>
        <slot name="title">Title</slot>
    </h2>
    <button @click=${onToggle}>${info ? 'Hide Info' : 'Show More'}</button>
    <!-- <p style="display: ${info ? 'block' : 'none'};"> -->
    <p style="display: xxxxxxxxxxxxxxxxxxxxxxxxxx;">
        <slot></slot>
    </p>
</article>`;

class ToggleArticle extends HTMLElement {
    #root;

    constructor() {
        super();
        this.#root = this.attachShadow({ mode: 'closed' });
    }

    connectedCallback() {
        this.render();
    }

    attributeChangedCallback(name, old, value) {
        if (name == 'info' && this.#root.querySelector('p')) {
            this.render();
        }
    }

    static get observedAttributes() {
        return ['info'];
    }

    toggle() {
        if (this.getAttribute('info') == 'true') {
            this.removeAttribute('info');
        } else {
            this.setAttribute('info', 'true');
        }
    }

    render() {
        litRender(template(this.getAttribute('info') == 'true', this.toggle), this.#root, { host: this });
    }

    // disconnectedCallback() {
    // } 
}

window.customElements.define('toggle-article', ToggleArticle);