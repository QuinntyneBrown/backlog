import { Category } from "./category.model";
import { CategoryService } from "./category.service";

const template = require("./category-list.component.html");
const styles = require("./category-list.component.scss");

export class CategoryListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _categoryService: CategoryService = CategoryService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {
		const categorys: Array<Category> = await this._categoryService.get();
        for (var i = 0; i < categorys.length; i++) {
			let el = this._document.createElement(`ce-category-item`);
			el.setAttribute("entity", JSON.stringify(categorys[i]));
			this.appendChild(el);
        }	
	}
}

customElements.define("ce-category-list", CategoryListComponent);
