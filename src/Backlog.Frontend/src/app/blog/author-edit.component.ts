import { Author } from "./author.model";
import { AuthorService } from "./author.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./author-edit.component.html");
const styles = require("./author-edit.component.scss");

export class AuthorEditComponent extends HTMLElement {
    constructor(
		private _authorService: AuthorService = AuthorService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
		this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes() {
        return ["author-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._setEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = this.authorId ? "Edit Author": "Create Author";

        if (this.authorId) {			
            const author: Author = await this._authorService.getById(this.authorId) as Author;                
            this._firstnameInputElement.value = author.firstname;  
            this._lastnameInputElement.value = author.lastname;
            this._avatarUrlInputElement.value = author.avatarUrl;
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _setEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);        
        this._titleElement.addEventListener("click", this.onTitleClick);
        this._deleteButtonElement.addEventListener("click", this.onDelete);
    }

    private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
        this._titleElement.removeEventListener("click", this.onTitleClick);
        this._deleteButtonElement.removeEventListener("click", this.onDelete);
    }

    public async onSave() {
        var author = {
            id: this.authorId,
            firstname: this._firstnameInputElement.value,
            lastname: this._lastnameInputElement.value,
            avatarUrl: this._avatarUrlInputElement.value
        } as Author;
        
        await this._authorService.add(author);
		this._router.navigate(["author","list"]);
    }

    public async onDelete() {        
        await this._authorService.remove({ id: this.authorId });
		this._router.navigate(["author","list"]);
    }

	public onTitleClick() {
        this._router.navigate(["author", "list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "author-id":
                this.authorId = newValue;
				break;
        }        
    }

    public authorId: number;
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _firstnameInputElement(): HTMLInputElement { return this.querySelector(".author-firstname") as HTMLInputElement; }
    private get _lastnameInputElement(): HTMLInputElement { return this.querySelector(".author-lastname") as HTMLInputElement; }
    private get _avatarUrlInputElement(): HTMLInputElement { return this.querySelector(".author-avatar-url") as HTMLInputElement; }
}

customElements.define(`ce-author-edit`,AuthorEditComponent);
