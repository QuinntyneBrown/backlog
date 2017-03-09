import { TemplateModel } from "./template.model";
import { TemplateService } from "./template.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./template-edit.component.html");
const styles = require("./template-edit.component.scss");

export class TemplateEditComponent extends HTMLElement {
    constructor(
		private _templateService: TemplateService = TemplateService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return ["template-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._addEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = "Create Template";
        if (this.templateId) {
            const template: TemplateModel = await this._templateService.getById(this.templateId) as TemplateModel;
            this._nameInputElement.value = template.name;   
            this._titleElement.textContent = "Edit Template";
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _addEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);	
	}

    public onSave() {
        var template = {
            id: this.templateId,
            name: this._nameInputElement.value
        } as TemplateModel;
        
        this._templateService.add(template).then((results) => {
			this._router.navigate(["template","list"]);
        });
    }

    public async onDelete() {  
        await this._templateService.remove({ id: this.templateId });      
        this._router.navigate(["template", "list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "template-id":
                this.templateId = newValue;
				break;
        }        
    }

    public templateId: number;
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".template-name") as HTMLInputElement;}
}

customElements.define(`ce-template-edit`,TemplateEditComponent);
