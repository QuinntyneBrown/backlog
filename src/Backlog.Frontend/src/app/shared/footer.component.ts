import { Router } from "../router";

const template = require("./footer.component.html");
const styles = require("./footer.component.scss");

export class FooterComponent extends HTMLElement {
    constructor(private _router: Router = Router.Instance, private _window:Window = window) {
        super();

        this._onRouteChange = this._onRouteChange.bind(this);
        this._onDevelopedByClick = this._onDevelopedByClick.bind(this);
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
        this.developedByElement.addEventListener("click", this._onDevelopedByClick);
    }

    private _onDevelopedByClick() {
        this._window.open("https://ca.linkedin.com/in/quinntyne-brown-15830729", '_blank');
    }

    private _onRouteChange(options: any) {
        //this.style.display = options.routeName == "login" ? "none" : "block";
    }

    disconnectedCallback() {
        this._router.removeEventListener(this._onRouteChange);
        this.developedByElement.removeEventListener("click", this._onDevelopedByClick);
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }

    private get developedByElement(): HTMLParagraphElement { return this.querySelector("p"); }
}

customElements.define(`ce-footer`,FooterComponent);
