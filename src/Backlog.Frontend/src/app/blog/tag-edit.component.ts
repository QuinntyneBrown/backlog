import { Tag } from "./tag.model";
import { TagService } from "./tag.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./tag-edit.component.html");
const styles = require("./tag-edit.component.scss");

export class TagEditComponent extends HTMLElement {
    constructor(
		private _tagService: TagService = TagService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
		this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes() {
        return ["tag-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._setEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = this.tagId ? "Edit Tag": "Create Tag";

        if (this.tagId) {
            const tag: Tag = await this._tagService.getById(this.tagId);                
			this._nameInputElement.value = tag.name;  
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _setEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
		this._deleteButtonElement.addEventListener("click", this.onDelete);
        this._titleElement.addEventListener("click", this.onTitleClick);
    }

    private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
		this._deleteButtonElement.removeEventListener("click", this.onDelete);
        this._titleElement.removeEventListener("click", this.onTitleClick);
    }

    public async onSave() {
        const tag = {
            id: this.tagId,
            name: this._nameInputElement.value
        } as Tag;
        
        await this._tagService.add(tag);
		this._router.navigate(["tag","list"]);
    }

    public async onDelete() {        
        await this._tagService.remove({ id: this.tagId });
		this._router.navigate(["tag","list"]);
    }

	public onTitleClick() {
        this._router.navigate(["tag", "list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "tag-id":
                this.tagId = newValue;
				break;
        }        
    }

    public tagId: number;
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".tag-name") as HTMLInputElement;}
}

customElements.define(`ce-tag-edit`,TagEditComponent);
