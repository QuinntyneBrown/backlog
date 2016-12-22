import { Storage, TOKEN_KEY } from "../utilities";
import { UserService } from "./user.service";
import { Router } from "../router";
import { LoginRedirect } from "./login-redirect";

const template = require("./register.component.html");
const styles = require("./register.component.scss");

export class RegisterComponent extends HTMLElement {
    constructor(
        private _loginRedirect: LoginRedirect = LoginRedirect.Instance,
        private _router: Router = Router.Instance,
        private _storage: Storage = Storage.Instance,
        private _userService: UserService = UserService.Instance
    ) {
        super();
        this.onSubmit = this.onSubmit.bind(this);
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    private _bind() {

    }

    private _addEventListeners() {
        this.buttonElement.addEventListener("click", this.onSubmit);
    }

    disconnectedCallback() {
        this.buttonElement.removeEventListener("click", this.onSubmit);
    }

    onSubmit() {
        this._userService.register({
            firstname: this.firstnameElement.value,
            lastname: this.lastnameElement.value,
            password: this.passwordElement.value,
            confirmPassword: this.confirmPasswordElement.value,
            emailAddress: this.emailElement.value
        }).then((results: string) => {
            let resultsJSON = JSON.parse(results);
            if (resultsJSON.error)
                throw new Error(resultsJSON.error);
            this._storage.put({ name: TOKEN_KEY, value: resultsJSON.token });
            this._loginRedirect.redirectPreLogin();
        });
    }

    public get firstnameElement(): HTMLInputElement { return this.querySelector(".firstname") as HTMLInputElement; }
    public get lastnameElement(): HTMLInputElement { return this.querySelector(".lastname") as HTMLInputElement; }
    public get emailElement(): HTMLInputElement { return this.querySelector(".email") as HTMLInputElement; }
    public get passwordElement(): HTMLInputElement { return this.querySelector(".password") as HTMLInputElement; }
    public get confirmPasswordElement(): HTMLInputElement { return this.querySelector(".confirm-password") as HTMLInputElement; }
    public get buttonElement(): HTMLElement { return this.querySelector("ce-button") as HTMLElement; }


}

customElements.define(`ce-register`,RegisterComponent);
