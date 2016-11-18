import { Story } from "./story.model";
import { Router } from "../router";
import { debounce } from "../utilities";

const template = require("./story.component.html");
const styles = require("./story.component.scss");


export class StoryComponent extends HTMLElement {
    constructor(
        private _router: Router = Router.Instance) {
        super();
    }

    static get observedAttributes () {
        return [
            "entity"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this.headingElement.textContent = this.entity.name;
        this.bodyElement.innerHTML = this.entity.description;
    }

    private _addEventListeners() {
        this.addEventListener("click", this.onClick.bind(this));        
    }

    disconnectedCallback() {
        this.removeEventListener("click", this.onClick.bind(this));
    }

    public onClick() {
        this._router.navigate(["epic", this.entity.epicId, "story", "edit", this.entity.id]);
    }
 
    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "entity":
                this.entity = JSON.parse(newValue);
                break;
        }
    }
    
    public entity: Story;
    private get bodyElement() { return this.querySelector("div") as HTMLElement; }
    private get headingElement() { return this.querySelector("h4") as HTMLElement; }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-story`,StoryComponent));
