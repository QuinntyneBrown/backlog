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

    private async _bind() {
        const sprints: Sprint[] = await this._sprintService.get();
        for (let i = 0; i < sprints.length; i++) {
            let el = this._document.createElement(`ce-sprint-item`);
            el.setAttribute("entity", JSON.stringify(sprints[i]));
            this.appendChild(el);
        }
	}
}

customElements.define("ce-sprint-list", SprintListComponent);
