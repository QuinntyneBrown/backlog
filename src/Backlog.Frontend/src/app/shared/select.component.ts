import { OptionClick, optionEvents, OptionComponent } from "./option.component";

let template = require("./select.component.html");
let styles = require("./select.component.scss");

export const selectEvents = {
    SELECT: "[Select] Select"
};

export class SelectEvent extends CustomEvent {
    constructor(option: { name: string, id: number }) {
        super(selectEvents.SELECT, {
            detail: { option }
        });
    }
}

export class SelectComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
        this._addEventListeners();
    }

    private _addEventListeners() {
        this._optionsSlot.map(o => o.addEventListener(optionEvents.CLICK, this._onClick.bind(this)));
    }

    private _onClick(optionClick: OptionClick) {
        this.selectedOption = optionClick.detail.option;
        this._optionsSlot.map(o => {
            o.classList.remove("selected");
            if (o.option.id == this.selectedOption.id)
                o.classList.add("selected");
        });
        this.dispatchEvent(new SelectEvent(this.selectedOption));
    }

    disconnectedCallback() {
        this._optionsSlot.map(o => o.removeEventListener(optionEvents.CLICK, this._onClick.bind(this)));
    }

    public selectedOption: { name: string, id: number };

    private get _optionsSlot(): Array<OptionComponent> { return Array.from(this.querySelectorAll("[name='option']")) as Array<OptionComponent>; }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`ce-select`, SelectComponent);
