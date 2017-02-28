import { Product } from "./product.model";
import { ProductService } from "./product.service";
import { createElement } from "../utilities";

const template = require("./product-list.component.html");
const styles = require("./product-list.component.scss");

export class ProductListComponent extends HTMLElement {
    constructor(private _productService: ProductService = ProductService.Instance) {
        super();
    }

    async connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        let results = await this._productService.get() as string;
        var resultsJSON: Array<Product> = JSON.parse(results) as Array<Product>;
        for (var i = 0; i < resultsJSON.length; i++) {
            this.appendChild(createElement(`<ce-product-item entity='${JSON.stringify(resultsJSON[i])}'></ce-product-item>`));
        }
        
    }    
}

customElements.define("ce-product-list", ProductListComponent);
