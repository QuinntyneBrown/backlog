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

	private async _bind() {
        const templates: Array<TemplateModel> = await this._templateService.get() as Array<TemplateModel>;
        for (var i = 0; i < templates.length; i++) {
            let el = this._document.createElement(`ce-template-item`);
            el.setAttribute("entity", JSON.stringify(templates[i]));
            this.appendChild(el);
        }
	}
}

customElements.define("ce-template-list", TemplateListComponent);
