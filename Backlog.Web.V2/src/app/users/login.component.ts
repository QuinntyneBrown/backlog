import { UserService } from "./user.service";
import { UserLoginSuccess, userActions } from "./actions";

let template = require("./login.component.html");
let styles = require("./login.component.scss");

export class LoginComponent extends HTMLElement {
    constructor(private _userService: UserService = UserService.Instance) {
        super();      
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._addEventListeners();
    }

    private _addEventListeners() {
        this._loginButtonElement.addEventListener("click", this._onTryToLogin.bind(this));
    }

    private _onTryToLogin() {
        this._userService.tryToLogin({
            username: this._usernameElement.value,
            password: this._passwordElement.value
        }).then((results:string) => {
            this.dispatchEvent(new UserLoginSuccess(JSON.parse(results).access_token));
        }).catch((e) => { });
    }

    private get _usernameElement() { return this.querySelectorAll("input")[0] as HTMLInputElement; }
    private get _passwordElement() { return this.querySelectorAll("input")[1] as HTMLInputElement; }
    private get _loginButtonElement() { return this.querySelector("ce-button") as HTMLButtonElement; }

    disconnectedCallback() {
        this._loginButtonElement.removeEventListener("click", this._onTryToLogin.bind(this));        
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-login`,LoginComponent));
