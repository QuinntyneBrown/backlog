import { Product } from "./product.model";

const template = require("./product-item.component.html");
const styles = require("./product-item.component.scss");

export class ProductItemComponent extends HTMLElement {
    constructor() {
        super();        
    }

    static get observedAttributes() {
        return ["entity"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this.nameElement.textContent = this.entity.name;

    }
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "entity":
                this.entity = JSON.parse(newValue);
				break;
        }        
    }

    public entity: Product;
    public get nameElement(): HTMLElement {
        return this.querySelector("p") as HTMLElement;
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-product-item`,ProductItemComponent));
