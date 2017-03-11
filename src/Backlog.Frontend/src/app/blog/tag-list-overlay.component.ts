import { Modal } from "../shared";

const template = require("./tag-list-overlay.component.html");
const styles = require("./tag-list-overlay.component.scss");

export class TagListOverlayComponent extends HTMLElement {
    constructor(private _modal: Modal = Modal.Instance) {
        super();
    }

    static get observedAttributes () {
        return [
            "tags"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();

        
    }

    private _bind() {

    }

    private _setEventListeners() {
        this.addEventListener("click", this.onClick.bind(this));
    }

    disconnectedCallback() {
        this.removeEventListener("click", this.onClick.bind(this));
    }

    onClick() {
        this._modal.closeAsync();
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`ce-tag-list-overlay`,TagListOverlayComponent);
