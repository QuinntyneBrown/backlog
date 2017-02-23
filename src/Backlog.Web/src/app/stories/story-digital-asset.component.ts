import { StoryService } from "./story.service";

let template = require("./story-digital-asset.component.html");
let styles = require("./story-digital-asset.component.scss");

export class StoryDigitalAssetComponent extends HTMLElement {
    constructor(private _storyService: StoryService = StoryService.Instance) {
        super();
    }

    static get observedAttributes () {
        return [
            "relative-path",
            "digital-asset-id"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this.imageElement.src = this._relativePath;
    }

    private _addEventListeners() {
        this.removeElement.addEventListener("click", this.onRemoveClick.bind(this));
    }

    disconnectedCallback() {

    }

    private onRemoveClick() {
        this._storyService.removeDigitalAsset({ id: this._digitalAssetId}).then(r => {
            this.parentNode.removeChild(this);
        });
    }

    private _relativePath: string;

    private _digitalAssetId: number;

    private get imageElement(): HTMLImageElement { return this.querySelector("img") as HTMLImageElement; }

    private get removeElement(): HTMLImageElement { return this.querySelector(".remove") as HTMLImageElement; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "relative-path":
                this._relativePath = newValue;
                break;
            case "digital-asset-id":
                this._digitalAssetId = newValue;
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-story-digital-asset`,StoryDigitalAssetComponent));
