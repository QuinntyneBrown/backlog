import { Brand } from "./brand.model";
import { BrandService } from "./brand.service";
import { TemplateService, TemplateModel } from "../templates";

const template = require("./brand-list.component.html");
const styles = require("./brand-list.component.scss");

export class BrandListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
        private _brandService: BrandService = BrandService.Instance,
        private _templateService: TemplateService = TemplateService.Instance
    ) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

    private async _bind() {
        const results = await Promise.all([this._templateService.get(), this._brandService.get()]) as Array<any>;        
        const templates: Array<TemplateModel> = JSON.parse(results[0]) as Array<TemplateModel>;
        const brands: Array<Brand> = JSON.parse(results[1]) as Array<Brand>;

        for (var i = 0; i < brands.length; i++) {
			let el = this._document.createElement(`ce-brand-item`);
			el.setAttribute("entity", JSON.stringify(brands[i]));
			this.appendChild(el);
        }
        
	}
}

customElements.define("ce-brand-list", BrandListComponent);
