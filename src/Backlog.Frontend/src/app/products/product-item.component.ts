import { Product } from "./product.model";
import { Router } from "../router";

const template = require("./product-item.component.html");
const styles = require("./product-item.component.scss");

export class ProductItemComponent extends HTMLElement {
    constructor(private _router: Router = Router.Instance) {
        super();        
    }

    static get observedAttributes() {
        return ["entity"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;         
        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this._nameElement.textContent = this.entity.name;
    }

    private _addEventListeners() {
        this._editLinkElement.addEventListener("click", this._onEditClick.bind(this));
    }

    private _onEditClick() {
        this._router.navigate(["product", "edit", this.entity.id]);
    }
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "entity":
                this.entity = JSON.parse(newValue);
				break;
        }        
    }

    public entity: Product;
    public get _nameElement(): HTMLElement { return this.querySelector("p") as HTMLElement; }
    public get _editLinkElement() { return this.querySelector(".entity-item-edit") as HTMLElement; }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-product-item`,ProductItemComponent));
