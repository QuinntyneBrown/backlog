import { Feature } from "./feature.model";
import { FeatureService } from "./feature.service";

const template = require("./feature-list.component.html");
const styles = require("./feature-list.component.scss");

export class FeatureListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _featureService: FeatureService = FeatureService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private _bind() {
        this._featureService.get().then((results: string) => {
            var resultsJSON: Array<Feature> = JSON.parse(results) as Array<Feature>;
            for (var i = 0; i < resultsJSON.length; i++) {
				let el = this._document.createElement(`ce-feature-item`);
				el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
				this.appendChild(el);
            }
        });	
	}
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-feature-list", FeatureListComponent));
