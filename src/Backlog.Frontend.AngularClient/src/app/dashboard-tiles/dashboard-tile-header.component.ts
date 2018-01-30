import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";

const styles = unsafeHTML(`<style>${require("./dashboard-tile-header.component.css")}<style>`);

export class DashboardTileHeaderComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [
            "dashboard-tile-heading"
        ];
    }

    connectedCallback() {     

        this.attachShadow({ mode: 'open' });
        
		render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'dashboardtileheader');

        this._bind();
        this._setEventListeners();
    }

    get template(): TemplateResult {
        return html`
            ${styles}
            <h1>${this.dashboardTileHeading}</h1><ce-dots-button></ce-dots-button>
        `;
    }

    private async _bind() {

    }

    private _setEventListeners() {

    }

    disconnectedCallback() {

    }

    public dashboardTileHeading: string;

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "dashboard-tile-heading":
                this.dashboardTileHeading = newValue;
                break;
        }
    }
}

customElements.define(`ce-dashboard-tile-header`,DashboardTileHeaderComponent);
