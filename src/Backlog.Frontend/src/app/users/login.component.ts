import { UserService } from "./user.service";
import { Router } from "../router";
import { LoginRedirect } from "./login-redirect";
import { Storage, TOKEN_KEY } from "../utilities";

const template = require("./login.component.html");
const styles = require("./login.component.scss");

export class LoginComponent extends HTMLElement {
    constructor(
        private _document: Document = document,
        private _router: Router = Router.Instance,
        private _loginRedirect: LoginRedirect = LoginRedirect.Instance,
        private _storage: Storage = Storage.Instance,
        private _userService: UserService = UserService.Instance) {
        super();      
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._addEventListeners();
    }

    private _addEventListeners() {
        this._loginButtonElement.addEventListener("click", this._onTryToLogin.bind(this));
        this._usernameElement.addEventListener("keyup", this._onKeyUp.bind(this));
        this._passwordElement.addEventListener("keyup", this._onKeyUp.bind(this));
        this._document.body.addEventListener("keyup", this._onKeyUp.bind(this));
    }

    private _onKeyUp(e: KeyboardEvent) {    
        switch (e.keyCode) {
            case 13:
                this._onTryToLogin();
                break;

            default:
                this._errorElement.textContent = "";
                break;
        }
    }

    private _onTryToLogin() {
        this._userService.tryToLogin({
            username: this._usernameElement.value,
            password: this._passwordElement.value
        }).then((results: string) => {
            let resultsJSON = JSON.parse(results);
            if (resultsJSON.error)
                throw new Error(resultsJSON.error);
            this._storage.put({ name: TOKEN_KEY, value: resultsJSON.access_token });
            this._loginRedirect.redirectPreLogin();
        }).catch((e:Error) => {
            this._errorElement.textContent = "Invalid username or password.";
            this._usernameElement.value = "";
            this._passwordElement.value = "";
            setTimeout(() => this._errorElement.textContent = "", 3000);
        });
    }

    private get _usernameElement() { return this.querySelectorAll("input")[0]; }
    private get _passwordElement() { return this.querySelectorAll("input")[1]; }
    private get _errorElement():HTMLElement { return this.querySelector(".error") as HTMLElement; }
    private get _loginButtonElement() { return this.querySelector("ce-button") as HTMLButtonElement; }

    disconnectedCallback() {
        this._loginButtonElement.removeEventListener("click", this._onTryToLogin.bind(this));
        this._usernameElement.removeEventListener("keyup", this._onKeyUp.bind(this));
        this._passwordElement.removeEventListener("keyup", this._onKeyUp.bind(this));    
        this._document.body.removeEventListener("keyup", this._onKeyUp.bind(this)); 
    }
}

customElements.define(`ce-login`,LoginComponent);
