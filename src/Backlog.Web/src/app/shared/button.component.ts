import { insertAfter, createElement } from "../utilities";

let template = require("./button.component.html");
let styles = require("./button.component.scss");

export class ButtonComponent extends HTMLElement {
    constructor(
        private _createElement: Function = createElement,
        private _insertAfter: Function = insertAfter) {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        var textContent = this.textContent;
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this._insertAfter(this._createElement(textContent), this.querySelector("style"));

        this._bind();
        this._addEventListeners();
    }

    private _bind() {

    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-button`,ButtonComponent));
