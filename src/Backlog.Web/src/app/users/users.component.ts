let template = require("./users.component.html");
let styles = require("./users.component.scss");

export class UsersComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this._ractive = new Ractive({ el: this, template: `<style>${styles}</style> ${template}`, data: this }); 
    }

    disconnectedCallback() {

    }

    private _ractive;

    attributeChangedCallback (name, oldValue, newValue) {
        this._ractive.set(name, newValue);
    }
}

customElements.define(`ce-users`,UsersComponent);
