let template = require("./option.component.html");
let styles = require("./option.component.scss");

export const optionEvents = {
    CLICK: "[Option] Click"
};

export class OptionClick extends CustomEvent {
    constructor(option: { name: string, id: number }) {
        super(optionEvents.CLICK, { detail: { option } });
    }
}

export class OptionComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes() {
        return ["option"];
    }

    connectedCallback() {
        this.textContent = this.option.name;
        this._addEventListeners();
    }

    private _addEventListeners() {
        this.addEventListener("click", this._onClick.bind(this));
    }

    private _onClick() {
        this.dispatchEvent(new OptionClick(this.option));
    }

    disconnectedCallback() {
        this.removeEventListener("click", this._onClick.bind(this));
    }

    public option: { name: string, id: number };

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "option":
                this.option = JSON.parse(newValue);
                break;
        }
    }
}

customElements.define(`ce-option`, OptionComponent);
