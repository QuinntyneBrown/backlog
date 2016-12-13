import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";
import { ProductService } from "../products";

const template = require("./epic-edit.component.html");
const styles = require("./epic-edit.component.scss");

export class EpicEditComponent extends HTMLElement {
    constructor(
        private _epicService: EpicService = EpicService.Instance,
        private _productService: ProductService = ProductService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
        this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
        this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes() {
        return ["epic-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this._addEventListeners();
        this._bind();
    }

    private async _bind() {
        
        this.titleElement.textContent = this.epicId ? "Edit Epic" : "Create Epic";

        let promises = [this._productService.get()];

        if (this.epicId)
            promises.push(this._epicService.getById(this.epicId));

        const results: Array<any> = await Promise.all(promises);

        let products = JSON.parse(results[0]) as Array<any>;

        for (let i = 0; i < products.length; i++) {
            let option = document.createElement("option");
            option.textContent = products[i].name;
            option.value = products[i].id;
            this.selectElement.appendChild(option);
        }

        if (this.epicId) {            
            this.entity = JSON.parse(results[1]) as Epic;
            this.nameInputElement.value = this.entity.name;
            this.priorityElement.value = this.entity.priority;
            this.selectElement.value = this.entity.productId;            
        } else {            
            this.deleteButtonElement.style.display = "none";
        } 
    }

    private _addEventListeners() {
        this.saveButtonElement.addEventListener("click", this.onSave);
        this.deleteButtonElement.addEventListener("click", this.onDelete);
        this.titleElement.addEventListener("click", this.onTitleClick);
    }

    private disconntectedCallback() {
        this.saveButtonElement.removeEventListener("click", this.onSave);
        this.deleteButtonElement.removeEventListener("click", this.onDelete);
        this.titleElement.removeEventListener("click", this.onTitleClick);
    }

    public async onSave() {
        var epic = {
            id: this.epicId,
            productId: this.selectElement.value,
            name: this.nameInputElement.value,
            priority: this.priorityElement.value
        } as any;

        await this._epicService.add(epic);
        const link = ["product", this.selectElement.value, "epic", "list"];
        this._router.navigate(link);
    }

    public async onDelete() {        
        await this._epicService.remove({ id: this.epicId });
        const link = ["epic", "list"];
        this._router.navigate(link);
    }

    public onTitleClick() {
        const link = ["product",this.selectElement.value,"epic","list"];        
        this._router.navigate(link);        
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "epic-id":
                this.epicId = newValue;
				break;
        }        
    }

    public epicId: number;
    public entity: Epic;
    public get priorityElement(): HTMLInputElement { return this.querySelector(".epic-priority") as HTMLInputElement; }
    public get selectElement(): HTMLSelectElement { return this.querySelector("select") as HTMLSelectElement; }
    public get titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    public get saveButtonElement(): HTMLButtonElement { return this.querySelector(".save-button") as HTMLButtonElement; }
    public get deleteButtonElement(): HTMLButtonElement { return this.querySelector(".delete-button") as HTMLButtonElement; }
    public get nameInputElement(): HTMLInputElement { return this.querySelector(".epic-name") as HTMLInputElement; }
}

customElements.define(`ce-epic-edit`,EpicEditComponent);
