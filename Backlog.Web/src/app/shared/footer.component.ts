import { Router } from "../router";

const template = require("./footer.component.html");
const styles = require("./footer.component.scss");

export class FooterComponent extends HTMLElement {
    constructor(private _router: Router = Router.Instance) {
        super();

        this._onRouteChange = this._onRouteChange.bind(this);
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
        this._router.addEventListener(this._onRouteChange);
    }

    private _onRouteChange(options: any) {
        //this.style.display = options.routeName == "login" ? "none" : "block";
    }

    disconnectedCallback() {
        this._router.removeEventListener(this._onRouteChange);
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-footer`,FooterComponent));
