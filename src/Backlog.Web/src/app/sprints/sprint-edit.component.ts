import { Sprint } from "./sprint.model";
import { SprintService } from "./sprint.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./sprint-edit.component.html");
const styles = require("./sprint-edit.component.scss");

export class SprintEditComponent extends HTMLElement {
    constructor(
		private _sprintService: SprintService = SprintService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return ["sprint-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._addEventListeners();
    }
    
	private _bind() {
        this._titleElement.textContent = "Create sprint";

        if (this.sprintId) {
            this._sprintService.getById(this.sprintId).then((results: string) => { 
                var resultsJSON: Sprint = JSON.parse(results) as Sprint;                
                this._nameInputElement.value = resultsJSON.name;              
            });
            this._titleElement.textContent = "Edit Sprint";
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _addEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);	
	}

    public onSave() {
        var sprint = {
            id: this.sprintId,
            name: this._nameInputElement.value
        } as Sprint;
        
        this._sprintService.add(sprint).then((results) => {
			this._router.navigate(["sprint","list"]);
        });
    }

    public onDelete() {        
        this._sprintService.remove({ id: this.sprintId }).then((results) => {
            this._router.navigate(["sprint","list"]);
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "sprint-id":
                this.sprintId = newValue;
				break;
        }        
    }

    public sprintId: number;
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".sprint-name") as HTMLInputElement;}
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-sprint-edit`,SprintEditComponent));
