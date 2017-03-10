import { Brand } from "./brand.model";
import { BrandService } from "./brand.service";
import { EditorComponent, Modal } from "../shared";
import { Router } from "../router";
import { TemplateService, TemplateModel, templateOverlayEvents } from "../templates";

const template = require("./brand-edit.component.html");
const styles = require("./brand-edit.component.scss");

export class BrandEditComponent extends HTMLElement {
    constructor(
        private _brandService: BrandService = BrandService.Instance,
        private _document: Document = document,
        private _modal: Modal = Modal.Instance,
        private _router: Router = Router.Instance,
        private _templateService: TemplateService = TemplateService.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
        this.onCreateTemplateClick = this.onCreateTemplateClick.bind(this);
        this.onTemplateSaved = this.onTemplateSaved.bind(this);
        this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes() {
        return ["brand-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._setEventListeners();
    }
    
	private async _bind() {
        this._titleElement.textContent = this.brandId ? "Edit Brand" : "Create Brand";
        this._deleteButtonElement.style.display = this.brandId ? this._deleteButtonElement.style.display : "none";

        let promises: Array<any> = [this._templateService.get()];

        if (this.brandId)
            promises.push(this._brandService.getById(this.brandId));

        let resultsArray = await Promise.all(promises) as Array<string>;
        let templates = JSON.parse(resultsArray[0]) as Array<TemplateModel>;

        for (let i = 0; i < templates.length; i++) {
            let option = document.createElement("option");
            option.textContent = `${templates[i].name}`;
            option.value = templates[i].id;
            this._selectElement.appendChild(option);
        }

        if (this.brandId) {
            var brand: Brand = JSON.parse(resultsArray[1]) as Brand;
            this._nameInputElement.value = brand.name;
            this._selectElement.value = brand.templateId;
        }        
	}

	private _setEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._createTemplateElement.addEventListener("click", this.onCreateTemplateClick);
        this._document.addEventListener(templateOverlayEvents.SAVED, this.onTemplateSaved);
        this._titleElement.addEventListener("click", this.onTitleClick);
    }

    private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
        this._createTemplateElement.removeEventListener("click", this.onCreateTemplateClick);
        this._document.removeEventListener(templateOverlayEvents.SAVED, this.onTemplateSaved);
        this._titleElement.removeEventListener("click", this.onTitleClick);
    }

    public async onTemplateSaved() {
        await this._modal.closeAsync();
        const templates = await this._templateService.get() as Array<TemplateModel>;

        this._selectElement.innerHTML = "";

        for (let i = 0; i < templates.length; i++) {
            let option = document.createElement("option");
            option.textContent = `${templates[i].name}`;
            option.value = templates[i].id;
            this._selectElement.appendChild(option);
        }
    }

    public onCreateTemplateClick() {
        this._modal.openAsync({ html: "<ce-template-edit-overlay></ce-template-edit-overlay>" });
    }

    public async onSave() {
        var brand = {
            id: this.brandId,
            templateId: this._selectElement.value,
            name: this._nameInputElement.value
        } as Brand;

        await this._brandService.add(brand);

        this._router.navigate(["brand", "list"]);
    }

    public async onDelete() {        
        await this._brandService.remove({ id: this.brandId })
        this._router.navigate(["brand", "list"]);
    }

    public onTitleClick() {
        this._router.navigate(["brand", "list"]);
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "brand-id":
                this.brandId = newValue;
				break;
        }        
    }

    public brandId: number;
    
    private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _selectElement(): HTMLSelectElement { return this.querySelector("select") as HTMLSelectElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".brand-name") as HTMLInputElement; }
    private get _createTemplateElement(): HTMLElement { return this.querySelector(".template-create") as HTMLElement; }
}

customElements.define(`ce-brand-edit`,BrandEditComponent);