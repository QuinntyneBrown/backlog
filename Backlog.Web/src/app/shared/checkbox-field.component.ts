const template = require("./checkbox-field.component.html");
const styles = require("./checkbox-field.component.scss");

export class CheckboxFieldComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    private async _bind() {

    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`ce-checkbox-field`,CheckboxFieldComponent);
