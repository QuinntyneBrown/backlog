import { Router } from "../router";
import { CurrentUser } from "../users";
import { Storage, TOKEN_KEY } from "../utilities";

let template = require("./header.component.html");
let styles = require("./header.component.scss");

export class HeaderComponent extends HTMLElement {
    constructor(
        private _currentUser: CurrentUser= CurrentUser.Instance,
        private _router: Router = Router.Instance,
        private _storage: Storage = Storage.Instance) {
        super();
    }

    static get observedAttributes() {
        return [
            "background-color"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;         
        this._addEventListeners();
    }

    private _addEventListeners() {
        this._titleElement.addEventListener("click", this._onTitleClick.bind(this));
        this._router.addEventListener(this._onRouteChange.bind(this));
        this._logoutElement.addEventListener("click", this._onLogoutClick.bind(this));
    }

    private _onRouteChange(options: any) {
        Array.from(this.querySelectorAll("ce-link[auth-required]"))
            .map((e: HTMLElement) => e.style.display = this._router.activatedRoute.authRequired ? "inline-block" : "none");

        Array.from(this.querySelectorAll("ce-link[anonymous-required]"))
            .map((e: HTMLElement) => e.style.display = this._router.activatedRoute.authRequired ? "none" : "inline-block");
    }

    private _onLogoutClick() {
        this._storage.put({ name: TOKEN_KEY, value: null });
    }

    private _onTitleClick() {
        this._router.navigate([""]);
    }
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "background-color":
                this.style.setProperty("background-color",newValue);
                break;
        }
    }

    private get _titleElement() { return this.querySelector("h1") as HTMLElement; }
    private get _logoutElement() { return this.querySelector(".logout") as HTMLElement; }


}

customElements.define(`ce-header`,HeaderComponent);
