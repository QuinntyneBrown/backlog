const template = require("./users.component.html");
const styles = require("./users.component.scss");

export class UsersComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        
    }

    disconnectedCallback() {

    }

    private _ractive;

    attributeChangedCallback (name, oldValue, newValue) {
        
    }
}

customElements.define(`ce-users`,UsersComponent);
