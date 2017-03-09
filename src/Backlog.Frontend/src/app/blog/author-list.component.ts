import { Author } from "./author.model";
import { AuthorService } from "./author.service";

const template = require("./author-list.component.html");
const styles = require("./author-list.component.scss");

export class AuthorListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _authorService: AuthorService = AuthorService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {
        const authors: Array<Author> = await this._authorService.get() as Array<Author>;
        for (var i = 0; i < authors.length; i++) {
			let el = this._document.createElement(`ce-author-item`);
			el.setAttribute("entity", JSON.stringify(authors[i]));
			this.appendChild(el);
        }	
	}
}

customElements.define("ce-author-list", AuthorListComponent);