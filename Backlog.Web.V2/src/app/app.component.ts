let template = require("./app.component.html");
let styles = require("./app.component.scss");

export class AppComponent extends HTMLElement {
    constructor() {
        super();
        
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style>${template}`;
    }

    disconnectedCallback() {

    }
    
    attributeChangedCallback (name, oldValue, newValue) {

    }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define(`ce-app`, AppComponent));
