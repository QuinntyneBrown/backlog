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

            var products = JSON.parse(results[0]) as Array<any>;
            for (let i = 0; i < products.length; i++) {
                let option = document.createElement("option");
                option.textContent = products[i].name;
                option.value = products[i].id;
                this.selectElement.appendChild(option);
            }
            this.productId = products[0].id;

            var resultsJSON: Array<Epic> = JSON.parse(results[1]) as Array<Epic>;
            for (let i = 0; i < resultsJSON.length; i++) {
                let el = document.createElement("ce-epic-item");
                el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
                this.appendChild(el);
            }
            
            this._addEventListeners();
        });        
    } 

    private _addEventListeners() {
        this.selectElement.addEventListener("change", this.onSelectChange.bind(this));
    }

    public onSelectChange() {
        this.productId = this.selectElement.value;
    }

    public productId: any;

    public get selectElement(): HTMLSelectElement { return this.querySelector("select") as HTMLSelectElement; }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-epic-list", EpicListComponent));
