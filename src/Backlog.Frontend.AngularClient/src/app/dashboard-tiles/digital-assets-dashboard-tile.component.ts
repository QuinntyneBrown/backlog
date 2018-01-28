import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { DashboardTile } from "./dashboard-tile.model";
import { constants } from "./constants";
import { Storage } from "../shared/services/storage.service";
import { constants as sharedConstants } from "../shared/constants";

const styles = unsafeHTML(`<style>${require("./digital-assets-dashboard-tile.component.css")}<style>`);

export class DigitalAssetsDashboardTileComponent extends HTMLElement {
    constructor(private _storage: Storage = Storage.instance) {
        super();
    }

    static get observedAttributes () {
        return [
            "dashboard-tile"
        ];
    }

    connectedCallback() {     
        this.attachShadow({ mode: 'open' });
        
		render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'digitalassetsdashboardtile');

        this._bind();
        this._setEventListeners();
    }

    public get template(): TemplateResult {
        return html`
        <style>
            :host {
                grid-column: var(--grid-column-start,${this.dashboardTile.left}) / var(--grid-column-stop,${this.dashboardTile.left + this.dashboardTile.width});
                grid-row: var(--grid-row-start,${this.dashboardTile.top}) / var(--grid-row-stop,${this.dashboardTile.top + this.dashboardTile.height});
            }
        </style>
        ${styles}
        <div class="content">
            <h1>Files</h1>
        </div>
    `;
    }

    private async _bind() {

    }

    private _setEventListeners() {
        this.addEventListener("click", this.handleClick);
    }

    disconnectedCallback() {
        this.removeEventListener("click", this.handleClick);
    }

    public handleClick() {
        this.dispatchEvent(new CustomEvent(constants.NAVIGATE_BY_URL, {
            bubbles: true,
            scoped: true,
            cancelable: true,
            detail: {
                url:'/digitalassets/list'
            }
        }));
    }

    public dashboardTile: Partial<DashboardTile> = {};

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {

            case "dashboard-tile":
                this.dashboardTile = JSON.parse(newValue);
                break;

            default:
                break;
        }
    }
}

customElements.define(`ce-digital-assets-dashboard-tile`,DigitalAssetsDashboardTileComponent);
