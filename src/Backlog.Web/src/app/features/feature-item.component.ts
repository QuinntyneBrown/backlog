import { Feature } from "./feature.model";
import { FeatureService } from "./feature.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./feature-item.component.html");
const styles = require("./feature-item.component.scss");

export class FeatureItemComponent extends HTMLElement {
    constructor(
        private _featureService: FeatureService = FeatureService.Instance,
        private _router: Router = Router.Instance) {
        super();
    }

    static get observedAttributes() {
        return ["entity"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    disconnectedCallback() {
        this._deleteLinkElement.removeEventListener("click", this._onDeleteClick.bind(this));
        this._editLinkElement.removeEventListener("click", this._onEditClick.bind(this));
        this._viewLinkElement.removeEventListener("click", this._onViewClick.bind(this));
    }

    private _bind() {
        this._nameElement.textContent = this.entity.name;
    }

    private _addEventListeners() {
        this._deleteLinkElement.addEventListener("click", this._onDeleteClick.bind(this));
        this._editLinkElement.addEventListener("click", this._onEditClick.bind(this));
        this._viewLinkElement.addEventListener("click", this._onViewClick.bind(this));
    }

    private _onDeleteClick(e:Event) {
        this._featureService.remove({ id: this.entity.id }).then(() => {
            this.parentNode.removeChild(this);
        });
    }

    private _onEditClick() {
        this._router.navigate(["feature", "edit", this.entity.id]);
    }

    private _onViewClick() {
        this._router.navigate(["feature","view",this.entity.id]);
    }
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "entity":
                this.entity = JSON.parse(newValue);
				break;
        }        
    }

    private get _nameElement() { return this.querySelector("p") as HTMLElement; }
    private get _deleteLinkElement() { return this.querySelector(".entity-item-delete") as HTMLElement; }
    private get _editLinkElement() { return this.querySelector(".entity-item-edit") as HTMLElement; }
    private get _viewLinkElement() { return this.querySelector(".entity-item-view") as HTMLElement; }
    public entity: Feature;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-feature-item`,FeatureItemComponent));
