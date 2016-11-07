import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { EditorComponent } from "../shared";
import { EpicAddSuccess, EpicDeleteSuccess } from "./actions";

const template = require("./epic-edit.component.html");
const styles = require("./epic-edit.component.scss");

export class EpicItemComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes() {
        return ["epic-id"];
    }
    
    connectedCallback() {        

    }




    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "epic-id":
                this.epicId = newValue;
				break;
        }        
    }

    public epicId: number;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-epic-item`,EpicItemComponent));
