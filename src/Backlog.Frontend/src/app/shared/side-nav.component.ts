import { Router } from "../router";

let template = require("./side-nav.component.html");
let styles = require("./side-nav.component.scss");

export class SideNavComponent extends HTMLElement {
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

    private _onRouteChange(options:any) {
        this.style.display = options.routeName == "login" ? "none" : "block";
    }

    private _bind() {

    }

    private _addEventListeners() {
        this._router.addEventListener(this._onRouteChange.bind(this));
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

customElements.define(`ce-side-nav`,SideNavComponent);
