import { DigitalAssetService } from "./digital-asset.service";

const template = require("./digital-asset-url-input.component.html");
const styles = require("./digital-asset-url-input.component.scss");

export class DigitalAssetUrlInputComponent extends HTMLElement {
    constructor(
        private _digitalAssetService: DigitalAssetService = DigitalAssetService.Instance
    ) {
        super();
        this.onDragOver = this.onDragOver.bind(this);
        this.onDrop = this.onDrop.bind(this);
    }
    
    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._setEventListeners();
    }

    private _setEventListeners() {
        this.addEventListener("dragover", this.onDragOver);
        this.addEventListener("drop", this.onDrop, false);
    }

    onDragOver(e: DragEvent) {
        e.stopPropagation();
        e.preventDefault();
    }

    public async onDrop(e: DragEvent) {
        e.stopPropagation();
        e.preventDefault();

        if (e.dataTransfer && e.dataTransfer.files) {
            const packageFiles = function (fileList: FileList) {
                let formData = new FormData();
                for (var i = 0; i < fileList.length; i++) {
                    formData.append(fileList[i].name, fileList[i]);
                }
                return formData;
            }

            const data = packageFiles(e.dataTransfer.files);

            const results = await this._digitalAssetService.upload({ data: data }) as string;
            this.inputElement.value = JSON.parse(results).digitalAssets[0].relativePath;           
        }
    }

    public get value() { return this.inputElement.value; }

    public set value(value:string) { this.inputElement.value = value; }

    disconnectedCallback() {
        this.removeEventListener("dragover", this.onDragOver);
        this.removeEventListener("drop", this.onDrop, false);
    }
    
    private get inputElement():HTMLInputElement { return this.querySelector("input") as HTMLInputElement; }
}

customElements.define(`ce-digital-asset-url-input`,DigitalAssetUrlInputComponent);
