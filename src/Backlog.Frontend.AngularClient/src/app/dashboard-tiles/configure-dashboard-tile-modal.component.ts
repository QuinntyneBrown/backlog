import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { DashboardTile } from "./dashboard-tile.model";
import { ModalService } from "../shared/services/modal.service";

const styles = unsafeHTML(`<style>${require("./configure-dashboard-tile-modal.component.css")}<style>`);

export class ConfigureDashboardTileModalComponent extends HTMLElement {
    constructor(private _modalService: ModalService = ModalService.instance) {
        super();
        this.save = this.save.bind(this);
        this.cancel = this.cancel.bind(this);
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
            this.setAttribute('role', 'configuredashboardtilemodal');

        this._bind();
        this._setEventListeners();
    }

    get template(): TemplateResult {
        return html`
            ${styles}            
            
            <section class="toolbar">
                <h1>Configuration</h1>

                <form autocomplete="off">
                    <label>Top</label>
                    <input type="text" placeholder="Top" id="top" />

                    <label>Left</label>
                    <input type="text" placeholder="Left" id="left" />

                    <label>Width</label>
                    <input type="text" placeholder="Width" id="width" />

                    <label>Height</label>
                    <input type="text" placeholder="Height" id="height" />
                </form>

                <div class="actions">
                    <button class="save">Save</button>
                    <button class="cancel">Cancel</button>
                </div>
            </section>
        `;
    }

    private _bind() {

    }

    private _setEventListeners() {

    }

    public disconnectedCallback() {

    }

    public dashboardTile: DashboardTile;

    public save() {

    }

    public cancel() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "dashboard-tile":
                this.dashboardTile = JSON.parse(newValue);
                break;
        }
    }
}

customElements.define(`ce-configure-dashboard-tile-modal`, ConfigureDashboardTileModalComponent);
