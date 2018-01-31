import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { DashboardTile } from "./dashboard-tile.model";
import { constants } from "./constants";
import { Storage } from "../shared/services/storage.service";
import { constants as sharedConstants } from "../shared/constants";
import { DashboardTileComponent } from "./dashboard-tile.component";

const styles = unsafeHTML(`<style>${require("./digital-assets-dashboard-tile.component.css")}<style>`);

export class DigitalAssetsDashboardTileComponent extends DashboardTileComponent {
    constructor(private _storage: Storage = Storage.instance) {
        super();
    }
    
    public get template(): TemplateResult {
        return html`
        ${this.baseStyles}
        ${styles}
        <ce-dashboard-tile-header dashboard-tile='${JSON.stringify(this.dashboardTile)}'></ce-dashboard-tile-header>
    `;
    }
    
    protected _setEventListeners() {
        //this.addEventListener("click", this.handleClick);
    }

    disconnectedCallback() {
        //this.removeEventListener("click", this.handleClick);
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
}

customElements.define(`ce-digital-assets-dashboard-tile`,DigitalAssetsDashboardTileComponent);
