import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { epicActions, EpicDeleteSelect } from "./actions";

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
                var el = document.createElement("ce-epic-item");
                el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
                this.appendChild(el);
            }
        });
    }    
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-epic-list", EpicListComponent));
