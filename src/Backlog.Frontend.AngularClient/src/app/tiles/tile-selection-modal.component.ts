import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../node_modules/lit-html/lib/unsafe-html.js";
import { Subject } from "rxjs";
import { Tile } from "./tile.model";
import { Storage } from "../shared/services/storage.service";
import { constants } from "../shared/constants";
import { tilesEvents } from "./tiles.events";
import { ModalService } from "../shared/services/modal.service";

const formsStyles = unsafeHTML(`<style>${require("../shared/components/forms.css")}</style>`);
const styles = unsafeHTML(`<style>${require("./tile-selection-modal.component.css")}<style>`);

export class TileSelectionModalComponent extends HTMLElement {
    constructor(
        private _modalService: ModalService = ModalService.instance,
        private _storage: Storage = Storage.instance) {
        super();
        this.handleAdd = this.handleAdd.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    static get observedAttributes () {
        return [];
    }

    async connectedCallback() {    
        this.attachShadow({ mode: 'open' });

        let headers = new Headers();

        headers.append('Authorization', `Bearer ${this._storage.get({ name: constants.ACCESS_TOKEN_KEY })}`);

        headers.append('Tenant', `${this._storage.get({ name: constants.TENANT_KEY })}`);

        let response = await fetch("/api/tiles/get", { headers });

        let result = await response.json();
            
        this.tiles = result.tiles;

        render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'tileselectionmodal');

        this._bind();
        this._setEventListeners();
    }

    private async _bind() {

    }

    private _setEventListeners() {
        this.cancelButtonElement.addEventListener("click", this.handleCancel);
        this.addButtonElement.addEventListener("click", this.handleAdd);
    }

    disconnectedCallback() {
        this.cancelButtonElement.removeEventListener("click", this.handleCancel);
        this.addButtonElement.removeEventListener("click", this.handleAdd);
        this.disconnected.next();
    }

    public handleCancel() {
        this._modalService.close();
    }

    public handleAdd() {
        this.dispatchEvent(new CustomEvent(tilesEvents.TILES_SELECTED, {
            cancelable: true,
            bubbles: true,
            composed: true,
            detail: { tiles: this.shadowRoot.querySelectorAll(".is-selected") }
        } as CustomEventInit));
        this._modalService.close();
    }

    public get template(): TemplateResult {
        return html`
            ${formsStyles}
            ${styles}
            <section>
                <h1>Tile Catalog</h1>
                <a>Select a tile to add to the current dashboard</a>
                <div class="tile-catalog-items">
                    ${repeat(this.tiles, (i) => i.name, i => html`<ce-tile-selection-item tile-name="${i.name}" tile-id="${i.id}"></ce-tile-selection-item>`)}
                </div>
                <div class="actions">
                    <button class="add">Add</button>
                    <button class="cancel">Cancel</button>
                </div>
            </section>
        `;
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }

    public disconnected: Subject<void> = new Subject();

    public tiles: Array<Tile> = [];

    public get cancelButtonElement(): HTMLElement { return this.shadowRoot.querySelector("button.cancel") as HTMLElement; }

    public get addButtonElement(): HTMLElement { return this.shadowRoot.querySelector("button.add") as HTMLElement; }
}

customElements.define(`ce-tile-selection-modal`,TileSelectionModalComponent);
