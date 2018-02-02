import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { DashboardTile } from "./dashboard-tile.model";
import { constants } from "./constants";
import { DashboardTileComponent } from "./dashboard-tile.component";

const styles = unsafeHTML(`<style>${require("./digital-assets-dashboard-tile.component.css")}<style>`);

export class ProductsDashboardTileComponent extends DashboardTileComponent {
    constructor() {
        super();
        this.handleClick = this.handleClick.bind(this);
    }

    public get template(): TemplateResult {
        return html`
        ${this.baseStyles}
        ${styles}
        <ce-dashboard-tile-header dashboard-tile='${JSON.stringify(this.dashboardTile)}'></ce-dashboard-tile-header>
    `;
    }

    public handleClick() {
        this.dispatchEvent(new CustomEvent(constants.NAVIGATE_BY_URL, {
            bubbles: true,
            scoped: true,
            cancelable: true,
            detail: {
                url: '/products'
            }
        }));
    }

    protected _setEventListeners() {
        this.addEventListener("click", this.handleClick);
    }

    protected disconnectedCallback() {
        this.removeEventListener("click", this.handleClick);
    }
}

customElements.define(`ce-products-dashboard-tile`, ProductsDashboardTileComponent);
