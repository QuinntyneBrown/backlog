import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { PopoverService } from "../shared/services/popover.service";
import { DashboardTile } from "./dashboard-tile.model";

const styles = unsafeHTML(`<style>${require("./dashboard-tile-header.component.css")}<style>`);

export class DashboardTileHeaderComponent extends HTMLElement {
    constructor(popoverService: PopoverService = PopoverService.instance) {
        super();

        this._popoverService = popoverService.createInstance(); 
        this.handleMenuClick = this.handleMenuClick.bind(this);
    }

    static get observedAttributes () {
        return [
            "dashboard-tile"
        ];
    }

    private _popoverService: PopoverService;

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
            <h1>${this.dashboardTile.tile.name}</h1><ce-dots-button></ce-dots-button>
        `;
    }

    public handleMenuClick($event) {
        alert("?");
        $event.stopPropagation();

        if (this._popoverService.isOpen) {
            this._popoverService.hide();
        } else {
            this._popoverService.show({ target: this.buttonElement, html: `<ce-dashboard-tile-menu dashboard-tile='${JSON.stringify(this.dashboardTile)}'></ce-dashboard-tile-menu>` });
        }
    }
    

    private async _bind() {
        
    }

    private _setEventListeners() {
        this.buttonElement.addEventListener("click", this.handleMenuClick);
    }

    disconnectedCallback() {
        this.buttonElement.removeEventListener("click", this.handleMenuClick);
    }

    public get buttonElement(): HTMLElement { return this.shadowRoot.querySelector("ce-dots-button") as HTMLElement; }

    public dashboardTile: DashboardTile;

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "dashboard-tile":
                this.dashboardTile = JSON.parse(newValue);
                break;
        }
    }
}

customElements.define(`ce-dashboard-tile-header`,DashboardTileHeaderComponent);
