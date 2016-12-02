import { Product } from "./product.model";
import { ProductService } from "./product.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./product-edit.component.html");
const styles = require("./product-edit.component.scss");

export class ProductEditComponent extends HTMLElement {
    constructor(private _productService: ProductService = ProductService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
    }

    static get observedAttributes() {
        return ["product-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;     
        this._bind();
        this._addEventListeners();   
    }

    private _bind() {
        this.titleElement.textContent = "Create product";
        if (this.productId) {
            this._productService.getById(this.productId).then((results: string) => {
                var resultsJSON: Product = JSON.parse(results) as Product;
                this.nameInputElement.value = resultsJSON.name;
            });
            this.titleElement.textContent = "Edit Product";
        } else {
            this.deleteButtonElement.style.display = "none";
        } 
    }

    private _addEventListeners() {
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));
    }
    
    public onSave() {
        var product = {
            id: this.productId,
            name: this.nameInputElement.value
        } as Product;
        
        this._productService.add(product).then((results) => {
            this._router.navigate(["product", "list"]);
        });
    }

    public onDelete() {        
        this._productService.remove({ id: this.productId }).then((results) => {
            
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "product-id":
                this.productId = newValue;
				break;
        }        
    }

    public productId: number;
    public get titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    public get saveButtonElement(): HTMLButtonElement { return this.querySelector(".save-button") as HTMLButtonElement; }
    public get deleteButtonElement(): HTMLButtonElement { return this.querySelector(".delete-button") as HTMLButtonElement; }
    public get nameInputElement(): HTMLInputElement { return this.querySelector(".product-name") as HTMLInputElement; }

}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-product-edit`,ProductEditComponent));
