import { Router } from "../router";
import { CurrentUser } from "../users";

let template = require("./header.component.html");
let styles = require("./header.component.scss");

export class HeaderComponent extends HTMLElement {
    constructor(
        private _currentUser: CurrentUser= CurrentUser.Instance,
        private _router: Router = Router.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;        
        this._addEventListeners();
    }

    private _addEventListeners() {
        this._titleElement.addEventListener("click", this._onTitleClick.bind(this));
        this._router.addEventListener(this._onRouteChange.bind(this));
    }

    private _onRouteChange(options: any) {
        Array.from(this.querySelectorAll("ce-link[auth-required]"))
            .map((e: HTMLElement) => e.style.display = options.routeName == "login" ? "none" : "inline-block");

        Array.from(this.querySelectorAll("ce-link[anonymous-required]"))
            .map((e: HTMLElement) => e.style.display = options.routeName == "login" ? "inline-block" : "none");
    }

    private _onTitleClick() {
        this._router.navigate([""]);
    }

    private get _titleElement() { return this.querySelector("h1") as HTMLElement; }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-header`,HeaderComponent));
