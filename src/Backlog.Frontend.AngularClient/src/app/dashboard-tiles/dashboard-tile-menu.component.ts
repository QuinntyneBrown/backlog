import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { REMOVE_DASHBOARD_TILE_MENU_CLICK, CONFIGURE_DASHBOARD_TILE_MENU_CLICK } from "./dashboard-tile.actions";

const styles = unsafeHTML(`<style>${require("./dashboard-tile-menu.component.css")}<style>`);

export class DashboardTileMenuComponent extends HTMLElement {
    constructor() {
        super();
        this.configure = this.configure.bind(this);
        this.remove = this.remove.bind(this);
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {     

        this.attachShadow({ mode: 'open' });
        
		render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'dashboardtilemenu');

        this._setEventListeners();
    }

    get template(): TemplateResult {
        return html`
            ${styles}
            <ul>
                <li><a class="configure">Configure</a></li>
                <li><a class="remove">Remove</a></li>
            </ul>
        `;
    }

    private _setEventListeners() {
        this.shadowRoot.querySelector("a.remove").addEventListener("click", this.remove);
        this.shadowRoot.querySelector("a.configure").addEventListener("click", this.configure);
    }

    disconnectedCallback() {
        this.shadowRoot.querySelector("a.remove").removeEventListener("click", this.remove);
        this.shadowRoot.querySelector("a.configure").removeEventListener("click", this.configure);
    }

    public remove() {
        this.dispatchEvent(new CustomEvent(REMOVE_DASHBOARD_TILE_MENU_CLICK, {
            scoped: true,
            bubbles: true,
            cancelable:true,
            detail: {
                dashboardTile: this.dashboardTile
            }
        }));
    }

    public configure() {
        this.dispatchEvent(new CustomEvent(CONFIGURE_DASHBOARD_TILE_MENU_CLICK, {
            scoped: true,
            bubbles: true,
            cancelable: true,
            detail: {
                dashboardTile:this.dashboardTile
            }
        }));
    }

    public dashboardTile: any;

    public get configureElement() { return this.shadowRoot.querySelector(".configure") as HTMLElement; }

    public get removeElement() { return this.shadowRoot.querySelector(".remove") as HTMLElement; }
    
    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "dashboard-tile":
                this.dashboardTile = JSON.parse(newValue);
                break;
        }
    }
}

customElements.define(`ce-dashboard-tile-menu`,DashboardTileMenuComponent);
