let template = require("./drop-zone.component.html");
let styles = require("./drop-zone.component.scss");

export const dropZoneEvents = {
    DROP: "[Drop Zone] Drop"
};

export class Drop extends CustomEvent {
    constructor(files: FormData) {
        super(dropZoneEvents.DROP, {
            detail: { files }
        });
    }
}

export class DropZoneComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes() {
        return [
            "caption",
            "height",
            "width",
            "background-color",
            "font-family",
            "color"
        ];
    }

    connectedCallback() {
        let root = (this as any).attachShadow({ mode: 'open' });
        root.innerHTML = `<style>${styles}</style> ${template}`;
        this._dropZoneHTMLElement = root.querySelector(".drop-zone") as HTMLElement;
        this._dropZoneHTMLElement.addEventListener("dragover", this.onDragOver.bind(this));
        this._dropZoneHTMLElement.addEventListener("drop", this.onDrop.bind(this), false);
        this._dropZoneHTMLElement.querySelector("a").textContent = this._caption || "Drop Zone";
    }

    onDragOver(dragEvent: DragEvent) {
        dragEvent.stopPropagation();
        dragEvent.preventDefault();
    }

    disconnectedCallback() {
        this._dropZoneHTMLElement.removeEventListener("drop", this.onDrop.bind(this), false);
    }

    public onDrop(dragEvent: DragEvent) {
        dragEvent.stopPropagation();
        dragEvent.preventDefault();

        if (dragEvent.dataTransfer && dragEvent.dataTransfer.files) {
            var packageFiles = function (fileList: FileList) {
                var formData = new FormData();
                for (var i = 0; i < fileList.length; i++) {
                    formData.append(fileList[i].name, fileList[i]);
                }
                return formData;
            }
            this.dispatchEvent(new Drop(packageFiles(dragEvent.dataTransfer.files)));
        }
    }

    private _dropZoneHTMLElement: HTMLElement;
    private _caption: string;

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "caption":
                this._caption = newValue;
                break;

            case "height":
                this.style.setProperty('--height', newValue);
                break;

            case "width":
                this.style.setProperty('--width', newValue);
                break;

            case "background-color":
                this.style.setProperty('--backgroundColor', newValue);
                break;

            case "color":
                this.style.setProperty('--color', newValue);
                break;

            case "font-family":
                this.style.setProperty('--fontFamily', newValue);
                break;
        }
    }
}

customElements.define(`ce-drop-zone`, DropZoneComponent);
