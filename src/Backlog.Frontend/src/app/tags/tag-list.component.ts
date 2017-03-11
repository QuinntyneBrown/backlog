import { Tag } from "./tag.model";
import { TagService } from "./tag.service";

const template = require("./tag-list.component.html");
const styles = require("./tag-list.component.scss");

export class TagListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _tagService: TagService = TagService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {
		const tags: Array<Tag> = await this._tagService.get();
        for (var i = 0; i < tags.length; i++) {
			let el = this._document.createElement(`ce-tag-item`);
			el.setAttribute("entity", JSON.stringify(tags[i]));
			this.appendChild(el);
        }	
	}
}

customElements.define("ce-tag-list", TagListComponent);
