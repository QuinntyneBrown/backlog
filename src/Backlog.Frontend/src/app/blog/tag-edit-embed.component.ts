import { Tag } from "./tag.model";
import { EditorComponent } from "../shared";
import {  TagDelete, TagEdit, TagAdd} from "./tag.actions";

const template = require("./tag-edit-embed.component.html");
const styles = require("./tag-edit-embed.component.scss");

export class TagEditEmbedComponent extends HTMLElement {
    constructor() {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return [
			"tag",
			"tag-id"
		];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._setEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = this.tag ? "Edit Tag": "Create Tag";

        if (this.tag) {                
			this._nameInputElement.value = this.tag.name;  
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _setEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
		this._deleteButtonElement.addEventListener("click", this.onDelete);
    }

    private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
		this._deleteButtonElement.removeEventListener("click", this.onDelete);
    }

    public onSave() {
        const tag = {
            id: this.tag != null ? this.tag.id : null,
            name: this._nameInputElement.value
        } as Tag;
		
		this.dispatchEvent(new TagAdd(tag)); 	       
    }

    public onDelete() {        
        const tag = {
            id: this.tag != null ? this.tag.id : null,
            name: this._nameInputElement.value
        } as Tag;

        this.dispatchEvent(new TagDelete(tag)); 		
    }

    public tag: Tag;
    public tagId: any;

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "tag-id":
                this.tagId = newValue;
                break;
            case "achievement":
                this.tag = JSON.parse(newValue);
                if (this.parentNode) {
                    this.tagId = this.tag.id;
                    this._nameInputElement.value = this.tag.name != undefined ? this.tag.name : "";
                    this._titleElement.textContent = this.tagId ? "Edit Tag" : "Create Tag";
                }
                break;
        }           
    }
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".tag-name") as HTMLInputElement;}
}

customElements.define(`ce-tag-edit-embed`,TagEditEmbedComponent);
