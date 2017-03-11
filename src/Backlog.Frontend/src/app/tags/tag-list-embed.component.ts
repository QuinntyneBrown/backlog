import { Tag } from "./tag.model";

const template = require("./tag-list-embed.component.html");
const styles = require("./tag-list-embed.component.scss");

export class TagListEmbedComponent extends HTMLElement {
    constructor(
        private _document: Document = document
    ) {
        super();
    }


    static get observedAttributes() {
        return [
			"tags"
		];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {		
        for (let i = 0; i < this.tags.length; i++) {
			let el = this._document.createElement(`ce-tag-item-embed`);
			el.setAttribute("entity", JSON.stringify(this.tags[i]));
			this.appendChild(el);
        }	
	}

	tags:Array<Tag> = [];

	attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "tags":
                this.tags = JSON.parse(newValue);
                break;
        }
    }
}

customElements.define("ce-tag-list-embed", TagListEmbedComponent);
