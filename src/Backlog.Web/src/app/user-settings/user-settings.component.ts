import { UserSettingsService } from "./user-settings.service";

const template = require("./user-settings.component.html");
const styles = require("./user-settings.component.scss");

export class UserSettingsComponent extends HTMLElement {
    constructor(
        private _userSettingsService: UserSettingsService = UserSettingsService.Instance
    ) { 
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

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-user-settings`,UserSettingsComponent));
