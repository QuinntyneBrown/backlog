import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";
import { ProductService } from "../products";

const template = require("./epic-edit.component.html");
const styles = require("./epic-edit.component.scss");

export class EpicEditComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance,
        private _productService: ProductService = ProductService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();

    }

    static get observedAttributes() {
        return ["epic-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this.saveButtonElement = this.querySelector(".save-button") as HTMLButtonElement;
        this.deleteButtonElement = this.querySelector(".delete-button") as HTMLButtonElement;
        this.titleElement = this.querySelector("h2") as HTMLElement;
        this.nameInputElement = this.querySelector(".epic-name") as HTMLInputElement;
        this.titleElement.textContent = "Create epic";
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));

        let promises = [this._productService.get()];

        if (this.epicId) {
            promises.push(this._epicService.getById(this.epicId));
            Promise.all(promises).then((results: Array<any>) => { 

                var products = JSON.parse(results[0]) as Array<any>;
                for (let i = 0; i < products.length; i++) {
                    let option = document.createElement("option");
                    option.textContent = products[i].name;
                    option.value = products[i].id;
                    this.selectElement.appendChild(option);
                }

                var resultsJSON: Epic = JSON.parse(results[1]) as Epic;                
                this.nameInputElement.value = resultsJSON.name; 
                this.priorityElement.value = resultsJSON.priority;  
                this.selectElement.value = resultsJSON.productId;           
            });
            this.titleElement.textContent = "Edit Epic";
        } else {

            Promise.all(promises).then((results: Array<any>) => {
                var products = JSON.parse(results[0]) as Array<any>;
                for (let i = 0; i < products.length; i++) {
                    let option = document.createElement("option");
                    option.textContent = products[i].name;
                    option.value = products[i].id;
                    this.selectElement.appendChild(option);
                }
            });

            this.deleteButtonElement.style.display = "none";
        } 
    }
    
    public onSave() {
        var epic = {
            id: this.epicId,
            productId: this.selectElement.value,
            name: this.nameInputElement.value,
            priority: this.priorityElement.value
        } as any;
        
        this._epicService.add(epic).then((results) => {
            this._router.navigate(["epic", "list"]);
        });
    }

    public onDelete() {        
        this._epicService.remove({ id: this.epicId }).then((results) => {
            this._router.navigate(["epic", "list"]);
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "epic-id":
                this.epicId = newValue;
				break;
        }        
    }

    public epicId: number;
    public get priorityElement(): HTMLInputElement { return this.querySelector(".epic-priority") as HTMLInputElement; }
    public get selectElement(): HTMLSelectElement { return this.querySelector("select") as HTMLSelectElement; }
    public titleElement: HTMLElement;
    public saveButtonElement: HTMLButtonElement;
    public deleteButtonElement: HTMLButtonElement;
    public nameInputElement: HTMLInputElement;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-epic-edit`,EpicEditComponent));
