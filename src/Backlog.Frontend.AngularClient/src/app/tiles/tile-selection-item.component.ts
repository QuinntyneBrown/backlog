import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
const styles = unsafeHTML(`<style>${require("./tile-selection-item.component.css")}<style>`);

import { Tile } from "./tile.model";

export class TileSelectionItemComponent extends HTMLElement {
    constructor() {
        super();
        this.handleClick = this.handleClick.bind(this);
    }

    static get observedAttributes () {
        return [
            "tile-name",
            "tile-id"
        ];
    }

    async connectedCallback() {        
        this.attachShadow({ mode: 'open' });

        render(this.template, this.shadowRoot);
        
        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'tileselectionitem');

        this._setEventListeners();
    }

    private _setEventListeners() {
        this.addEventListener("click", this.handleClick);
    }

    disconnectedCallback() {
        this.removeEventListener("click", this.handleClick);
    }

    get template(): TemplateResult {
        return html`
            ${styles}
            <h1>${this.displayName(this.name)}</h1>
        `;
    }

    public displayName(name: string) {
        if (name == 'Digital Assets')
            return 'Files';

        return name;
    }

    public handleClick() {
        this.isSelected = !this.isSelected;

        if (this.isSelected) {
            this.classList.add("is-selected");
        } else {
            this.classList.remove("is-selected");
        }
    }

    public name: string;

    public tileId: string;

    public tile:Tile

    public isSelected: boolean = false;

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "tile-name":
                this.name = newValue;
                break;

            case "tile-id":                
                this.tileId = newValue;
                break;
        }
    }

}

customElements.define(`ce-tile-selection-item`,TileSelectionItemComponent);
