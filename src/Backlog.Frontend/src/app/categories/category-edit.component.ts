import { Category } from "./category.model";
import { CategoryService } from "./category.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./category-edit.component.html");
const styles = require("./category-edit.component.scss");

export class CategoryEditComponent extends HTMLElement {
    constructor(
		private _categoryService: CategoryService = CategoryService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
		this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes() {
        return ["category-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._setEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = this.categoryId ? "Edit Category": "Create Category";

        if (this.categoryId) {
            const category: Category = await this._categoryService.getById(this.categoryId);                
			this._nameInputElement.value = category.name;  
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
        const category = {
            id: this.categoryId,
            name: this._nameInputElement.value
        } as Category;
        
        await this._categoryService.add(category);
		this._router.navigate(["category","list"]);
    }

    public async onDelete() {        
        await this._categoryService.remove({ id: this.categoryId });
		this._router.navigate(["category","list"]);
    }

	public onTitleClick() {
        this._router.navigate(["category", "list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "category-id":
                this.categoryId = newValue;
				break;
        }        
    }

    public categoryId: number;
    
	private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".category-name") as HTMLInputElement;}
}

customElements.define(`ce-category-edit`,CategoryEditComponent);
