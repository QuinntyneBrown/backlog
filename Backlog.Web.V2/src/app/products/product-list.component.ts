import { Product } from "./product.model";
import { ProductService } from "./product.service";
import { createElement } from "../utilities";
let template = require("./product-list.component.html");
let styles = require("./product-list.component.scss");

export class ProductListComponent extends HTMLElement {
    constructor(private _productService: ProductService = ProductService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._productService.get().then((results: string) => {
            var resultsJSON: Array<Product> = JSON.parse(results) as Array<Product>;
            for (var i = 0; i < resultsJSON.length; i++) {
                this.appendChild(createElement(`<ce-product-item entity='${JSON.stringify(resultsJSON[i])}'></ce-product-item>`));
            }
        });
    }    
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-product-list", ProductListComponent));
