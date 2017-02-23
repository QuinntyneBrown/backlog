import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { Router } from "../router";

const template = require("./epic-view.component.html");
const styles = require("./epic-view.component.scss");

export class EpicViewComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance,
        private _router: Router = Router.Instance) {
        super();
        this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes () {
        return ["epic-id"];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this._epicService.getById(this.epicId).then((results:string) => {
            this.entity = JSON.parse(results);
            
            this.titleElement.textContent = `Epic: ${this.entity.name}`;
            var documentFragment = document.createDocumentFragment();
            for (let i = 0; i < this.entity.stories.length; i++) {
                var storyElement = document.createElement("ce-story");
                storyElement.setAttribute("entity", JSON.stringify(this.entity.stories[i]));                
                documentFragment.appendChild(storyElement);
            }
            this.appendChild(documentFragment);
        });
        
    }


    private _addEventListeners() {
        this.createStoryLinkElement.addEventListener("click", this.onBackLinkClick.bind(this));
        this.titleElement.addEventListener("click", this.onTitleClick);
    }

    public disconnectedCallback() {
        this.createStoryLinkElement.removeEventListener("click", this.onBackLinkClick.bind(this));
        this.titleElement.removeEventListener("click", this.onTitleClick);
    }

    private onBackLinkClick() {
        this._router.navigate(["epic",this.epicId, "story","create"]);
    }

    private onTitleClick() {        
        this._router.navigate(["product",this.entity.productId, "epic", "list"]);
    }

    private entity: Epic;
    private epicId: number;
    
    private get titleElement(): HTMLElement { return this.querySelector(".epic-view-title") as HTMLElement; }
    private get createStoryLinkElement(): HTMLElement { return this.querySelector("a") as HTMLElement; }
    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "epic-id":
                this.epicId = newValue;
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-epic-view`,EpicViewComponent));
