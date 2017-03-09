import { Feature } from "./feature.model";
import { FeatureService } from "./feature.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./feature-edit.component.html");
const styles = require("./feature-edit.component.scss");

export class FeatureEditComponent extends HTMLElement {
    constructor(
		private _featureService: FeatureService = FeatureService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return ["feature-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._addEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = this.featureId ? "Edit Feature": "Create feature";

        if (this.featureId) {
            const resultsJSON: Feature = await this._featureService.getById(this.featureId) as Feature;                
			this._nameInputElement.value = resultsJSON.name;  
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _addEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);	
	}

	private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
        this._deleteButtonElement.removeEventListener("click", this.onDelete);	
	}

    public async onSave() {
        const feature = {
            id: this.featureId,
            name: this._nameInputElement.value
        } as Feature;
        
        await this._featureService.add(feature);
		this._router.navigate(["feature","list"]);
    }

    public async onDelete() {        
        await this._featureService.remove({ id: this.featureId });
		this._router.navigate(["feature","list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "feature-id":
                this.featureId = newValue;
				break;
        }        
    }

    public featureId: number;
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".feature-name") as HTMLInputElement;}
}

customElements.define(`ce-feature-edit`,FeatureEditComponent);
