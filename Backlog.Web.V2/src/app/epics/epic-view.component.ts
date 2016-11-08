import { Epic } from "./epic.model";
import { EpicService } from "./epic.service";
import { Router } from "../router";

let template = require("./epic-view.component.html");
let styles = require("./epic-view.component.scss");

export class EpicViewComponent extends HTMLElement {
    constructor(private _epicService: EpicService = EpicService.Instance,
        private _router: Router = Router.Instance) {
        super();
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

                let el = document.createElement("div");
                el.classList.add("epic-story");
                let title = document.createElement("h4");
                let body = document.createElement("p");
                title.textContent = this.entity.stories[i].name;
                body.innerHTML = this.entity.stories[i].description;
                el.appendChild(title);
                el.appendChild(body);
                documentFragment.appendChild(el);
            }
            this.appendChild(documentFragment);
        });

    }


    private _addEventListeners() {
        this.backLinkElement.addEventListener("click", this.onBackLinkClick.bind(this));
    }

    private onBackLinkClick() {
        this._router.navigate([""]);
    }

    private entity: Epic;
    private epicId: number;
    private get titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get backLinkElement(): HTMLElement { return this.querySelector("a") as HTMLElement; }
    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "epic-id":
                this.epicId = newValue;
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-epic-view`,EpicViewComponent));
