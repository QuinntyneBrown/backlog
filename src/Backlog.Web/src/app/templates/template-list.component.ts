import { TemplateModel } from "./template.model";
import { TemplateService } from "./template.service";

const template = require("./template-list.component.html");
const styles = require("./template-list.component.scss");

export class TemplateListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _templateService: TemplateService = TemplateService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private _bind() {
        this._templateService.get().then((results: string) => {
            var resultsJSON: Array<TemplateModel> = JSON.parse(results) as Array<TemplateModel>;
            for (var i = 0; i < resultsJSON.length; i++) {
				let el = this._document.createElement(`ce-template-item`);
				el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
				this.appendChild(el);
            }
        });	
	}
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-template-list", TemplateListComponent));
