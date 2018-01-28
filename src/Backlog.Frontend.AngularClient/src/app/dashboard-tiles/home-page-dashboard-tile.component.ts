import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { DashboardTile } from "./dashboard-tile.model";
import { constants } from "./constants";

const styles = unsafeHTML(`<style>${require("./digital-assets-dashboard-tile.component.css")}<style>`);

export class HomePageDashboardTileComponent extends HTMLElement {
    constructor() {
        super();
        this.handleClick = this.handleClick.bind(this);
    }

    static get observedAttributes() {
        return [
            "dashboard-tile"
        ];
    }

    connectedCallback() {

        this.attachShadow({ mode: 'open' });

        render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'homepagedashboardtile');

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
            <h1>${this.dashboardTile.tile.name}</h1>
        </div>
    `;
    }

    public handleClick() {
        this.dispatchEvent(new CustomEvent(constants.NAVIGATE_BY_URL, {
            bubbles: true,
            scoped: true,
            cancelable: true,
            detail: {
                url: '/homepage'
            }
        }));
    }

    private async _bind() {

    }

    private _setEventListeners() {
        this.addEventListener("click", this.handleClick);
    }

    disconnectedCallback() {
        this.removeEventListener("click", this.handleClick);
    }

    public dashboardTile: Partial<DashboardTile> = {};

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "dashboard-tile":
                this.dashboardTile = JSON.parse(newValue);
                break;

            default:
                break;
        }
    }
}

customElements.define(`ce-home-page-dashboard-tile`, HomePageDashboardTileComponent);
