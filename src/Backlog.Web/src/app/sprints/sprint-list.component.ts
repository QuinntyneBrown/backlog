import { Sprint } from "./sprint.model";
import { SprintService } from "./sprint.service";

const template = require("./sprint-list.component.html");
const styles = require("./sprint-list.component.scss");

export class SprintListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _sprintService: SprintService = SprintService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private _bind() {
        this._sprintService.get().then((results: string) => {
            var resultsJSON: Array<Sprint> = JSON.parse(results) as Array<Sprint>;
            for (var i = 0; i < resultsJSON.length; i++) {
				let el = this._document.createElement(`ce-sprint-item`);
				el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
				this.appendChild(el);
            }
        });	
	}
}

customElements.define("ce-sprint-list", SprintListComponent);
