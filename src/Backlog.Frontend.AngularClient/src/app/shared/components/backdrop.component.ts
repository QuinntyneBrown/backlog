const template = document.createElement("template");
const html = require("./backdrop.component.html");
const css = require("./backdrop.component.css");

export class BackdropComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes() {
        return [];
    }

    async connectedCallback() {
        template.innerHTML = `<style>${css}</style>${html}`;

        this.attachShadow({ mode: 'open' });
        this.shadowRoot.appendChild(document.importNode(template.content, true));

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'backdrop');

        this._bind();
        this._setEventListeners();
    }

    private async _bind() {

    }

    private _setEventListeners() {

    }

    disconnectedCallback() {

    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`cs-backdrop`, BackdropComponent);