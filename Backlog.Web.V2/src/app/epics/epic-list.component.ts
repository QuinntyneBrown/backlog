import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { epicActions, EpicDeleteSelect } from "./actions";
import { ProductService } from "../products";

let template = require("./epic-list.component.html");
let styles = require("./epic-list.component.scss");

export class EpicListComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance,
        private _productService: ProductService = ProductService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;

        Promise.all([
            this._productService.get(),
            this._epicService.get()
        ]).then((results: Array<any>) => {
            var resultsJSON: Array<Epic> = JSON.parse(results[1]) as Array<Epic>;
            for (var i = 0; i < resultsJSON.length; i++) {
                var el = document.createElement("ce-epic-item");
                el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
                this.appendChild(el);
            }
        });        
    }    
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-epic-list", EpicListComponent));
