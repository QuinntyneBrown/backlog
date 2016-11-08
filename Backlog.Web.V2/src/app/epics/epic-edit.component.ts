import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { EditorComponent } from "../shared";
import { EpicAddSuccess, EpicDeleteSuccess } from "./actions";
import { Router } from "../router";

const template = require("./epic-edit.component.html");
const styles = require("./epic-edit.component.scss");

export class EpicEditComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();

    }

    static get observedAttributes() {
        return ["epic-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this.saveButtonElement = this.querySelector(".save-button") as HTMLButtonElement;
        this.deleteButtonElement = this.querySelector(".delete-button") as HTMLButtonElement;
        this.titleElement = this.querySelector("h2") as HTMLElement;
        this.nameInputElement = this.querySelector(".epic-name") as HTMLInputElement;
        this.titleElement.textContent = "Create epic";
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));
        
        if (this.epicId) {
            this._epicService.getById(this.epicId).then((results: string) => { 
                var resultsJSON: Epic = JSON.parse(results) as Epic;                
                this.nameInputElement.value = resultsJSON.name;              
            });
            this.titleElement.textContent = "Edit Epic";
        } else {
            this.deleteButtonElement.style.display = "none";
        } 
    }
    
    public onSave() {
        var epic = {
            id: this.epicId,
            name: this.nameInputElement.value
        } as Epic;
        
        this._epicService.add(epic).then((results) => {
            this._router.navigate(["epic", "list"]);
        });
    }

    public onDelete() {        
        this._epicService.remove({ id: this.epicId }).then((results) => {
            this.dispatchEvent(new EpicDeleteSuccess(this.epicId));
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "epic-id":
                this.epicId = newValue;
				break;
        }        
    }

    public epicId: number;
    public titleElement: HTMLElement;
    public saveButtonElement: HTMLButtonElement;
    public deleteButtonElement: HTMLButtonElement;
    public nameInputElement: HTMLInputElement;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-epic-edit`,EpicEditComponent));
