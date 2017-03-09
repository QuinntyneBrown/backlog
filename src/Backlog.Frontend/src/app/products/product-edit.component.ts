import { Product } from "./product.model";
import { ProductService } from "./product.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./product-edit.component.html");
const styles = require("./product-edit.component.scss");

export class ProductEditComponent extends HTMLElement {
    constructor(
        private _productService: ProductService = ProductService.Instance,
        private _router: Router = Router.Instance,
        private _window: Window = window
    ) {
        super();
        this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
        this.onBack = this.onBack.bind(this);
    }

    static get observedAttributes() {
        return ["product-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;     
        this._bind();
        this._setEventListeners();   
    }

    private async _bind() {
        this.titleElement.textContent = this.productId ? "Edit Product" : "Create Product";        
        this.deleteButtonElement.style.display = this.productId ? this._window.getComputedStyle(this.deleteButtonElement).getPropertyValue("display"): "none";
        if (this.productId) {
            var product: Product = await this._productService.getById(this.productId) as Product;
            this.nameInputElement.value = product.name;
        }
    }

    private _setEventListeners() {
        this.saveButtonElement.addEventListener("click", this.onSave);
        this.deleteButtonElement.addEventListener("click", this.onDelete);
        this.titleElement.addEventListener("click", this.onBack);
    }
    
    public async onSave() {
        const product = {
            id: this.productId,
            name: this.nameInputElement.value
        } as any;

        await this._productService.add(product);
        this._router.navigate(["product", "list"]);
    }

    public async onDelete() {        
        await this._productService.remove({ id: this.productId });
    }

    onBack() {
        this._router.navigate(["product", "list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "product-id":
                this.productId = newValue;
				break;
        }        
    }

    public productId: number;
    public get titleElement(): HTMLElement { return this.querySelector(".product-edit-title") as HTMLElement; }
    public get saveButtonElement(): HTMLButtonElement { return this.querySelector(".save-button") as HTMLButtonElement; }
    public get deleteButtonElement(): HTMLButtonElement { return this.querySelector(".delete-button") as HTMLButtonElement; }
    public get nameInputElement(): HTMLInputElement { return this.querySelector(".product-name") as HTMLInputElement; }

}

customElements.define(`ce-product-edit`,ProductEditComponent);
