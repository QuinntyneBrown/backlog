import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { ProductService } from "../products";
import { Router } from "../router";
import { IPagedList, toPageListFromInMemory } from "../pagination";

const template = require("./epic-list.component.html");
const styles = require("./epic-list.component.scss");

export class EpicListComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance,
        private _productService: ProductService = ProductService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
        this.onNext = this.onNext.bind(this);
        this.onPrevious = this.onPrevious.bind(this);
    }

    async connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;

        let resultsArray: Array<any> = await Promise.all([this._productService.get(), this._epicService.get()]);

        let products = JSON.parse(resultsArray[0]) as Array<any>;

        for (let i = 0; i < products.length; i++) {
            let option = document.createElement("option");
            option.textContent = `${products[i].name}`;
            option.value = products[i].id;
            this.selectElement.appendChild(option);
        }

        this.productId = products[0].id;

        if (this._router.activatedRoute.routeParams && this._router.activatedRoute.routeParams.productId)
            this.productId = this._router.activatedRoute.routeParams.productId;

        this.selectElement.value = this.productId;

        var resultsJSON: Array<Epic> = JSON.parse(resultsArray[1]) as Array<Epic>;

        this._epics = resultsJSON;
        for (let i = 0; i < this._epics.length; i++) {
            if (resultsJSON[i].productId == this.productId) {
                let el = document.createElement("ce-epic-item");
                el.setAttribute("entity", JSON.stringify(this._epics[i]));
                this.appendChild(el);
            }
        }

        this._addEventListeners();
    } 

    public disconnectedCallback() {
        this.selectElement.removeEventListener("change", this.onSelectChange.bind(this));
    }

    private _addEventListeners() {
        this.selectElement.addEventListener("change", this.onSelectChange.bind(this));
    }

    public onSelectChange() {
        this._router.navigate(["product", this.selectElement.value, "epic", "list"]);
    }

    private _bind() {
        this._pagedList = toPageListFromInMemory(this._epics, this._pageNumber, this._pageSize);
    }

    private _epics: Array<Epic> = [];

    private _pageSize: number;
    private _pageNumber: number;
    private _pagedList: IPagedList<Epic>;

    public onNext(e: Event) {
        e.stopPropagation();

        if (this._pageNumber == this._pagedList.totalPages) {
            this._pageNumber = 1;
        } else {
            this._pageNumber = this._pageNumber + 1;
        }
        this._bind();
    }

    public onPrevious(e: Event) {
        e.stopPropagation();

        if (this._pageNumber == 1) {
            this._pageNumber = this._pagedList.totalPages;
        } else {
            this._pageNumber = this._pageNumber - 1;
        }
        this._bind();
    }

    public productId: any;

    public get selectElement(): HTMLSelectElement { return this.querySelector("select") as HTMLSelectElement; }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-epic-list", EpicListComponent));
