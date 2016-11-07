import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { createElement } from "../utilities";
import { epicActions, EpicEditSelect } from "./actions";
let template = require("./epic-list.component.html");
let styles = require("./epic-list.component.scss");

export class EpicListComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._epicService.get().then((results: string) => {
            var resultsJSON: Array<Epic> = JSON.parse(results) as Array<Epic>;
            for (var i = 0; i < resultsJSON.length; i++) {
                this.appendChild(createElement(`<ce-epic-item entity='${JSON.stringify(resultsJSON[i])}'></ce-epic-item>`));
                this.children[this.children.length - 1].addEventListener(epicActions.SELECT, this.onEpicListelect.bind(this));
                this.children[this.children.length - 1].addEventListener(epicActions.DELETE, this.onEpicDeleteSelect.bind(this));
            }
        });
    }

    public onEpicListelect(event: EpicEditSelect) {
        this.dispatchEvent(new EpicEditSelect(event.detail.epicId));
    }

    public onEpicDeleteSelect(event: EpicEditSelect) {
        this._epicService.remove({ id: event.detail.epicId }).then((results) => {
            event.target.removeEventListener(epicActions.SELECT, this.onEpicListelect.bind(this));
            event.target.removeEventListener(epicActions.DELETE, this.onEpicDeleteSelect.bind(this));
            this.removeChild(event.target as any);
        });
    }

}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-epic-list", EpicListComponent));
