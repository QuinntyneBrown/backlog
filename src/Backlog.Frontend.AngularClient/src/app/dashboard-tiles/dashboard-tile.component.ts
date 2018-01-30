import { html, TemplateResult, render } from "lit-html";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";

export abstract class DashboardTileComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [
            "dashboard-tile"
        ];
    }

    public connectedCallback() {     

        this.attachShadow({ mode: 'open' });
        
		render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'dashboardtile');
        
        this._setEventListeners();
    }

    public abstract get template(): TemplateResult;

    public get baseStyles() {
        return unsafeHTML(`
        <style>
            :host {
                grid-column: var(--grid-column-start,${this.dashboardTile.left}) / var(--grid-column-stop,${this.dashboardTile.left + this.dashboardTile.width});
                grid-row: var(--grid-row-start,${this.dashboardTile.top}) / var(--grid-row-stop,${this.dashboardTile.top + this.dashboardTile.height});
            }
        </style>
        `);
    }

    public dashboardTile: any;

    protected abstract _setEventListeners();
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "dashboard-tile":
                this.dashboardTile = JSON.parse(newValue);
                break;
        }
    }
}

