import { Router } from "../router";

let template = require("./header.component.html");
let styles = require("./header.component.scss");

export class HeaderComponent extends HTMLElement {
    constructor(private _router: Router = Router.Instance) {
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

    private _bind() {

    }

    private _addEventListeners() {
        this._titleElement.addEventListener("click", this._onTitleClick.bind(this));
    }
    

    private _onTitleClick() {
        this._router.navigate([""]);
    }

    private get _titleElement() { return this.querySelector("h1") as HTMLElement; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-header`,HeaderComponent));
