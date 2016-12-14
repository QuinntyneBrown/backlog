import { TemplateModel } from "./template.model";
import { TemplateService } from "./template.service";
import { EditorComponent, Modal } from "../shared";
import { Router } from "../router";

const template = require("./template-edit-overlay.component.html");
const styles = require("./template-edit-overlay.component.scss");

export const templateOverlayEvents = {
    SAVED: "[Template Overlay] Saved"
};

export class TemplateSavedEvent extends CustomEvent {
    constructor(template:TemplateModel) {
        super(templateOverlayEvents.SAVED, {
            detail: { template },
            bubbles: true,
            cancelable:true
        });
    }
}

export class TemplateEditOverlayComponent extends HTMLElement {
    constructor(
        private _modal:Modal = Modal.Instance,
        private _templateService: TemplateService = TemplateService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
        this.onSave = this.onSave.bind(this);
        this.onClose = this.onClose.bind(this);
    }
    
    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();       
    }

    private _bind() {

    }

    public async onSave() {
        var template = {
            name: this._nameInputElement.value
        } as TemplateModel;

        await this._templateService.add(template);

        this.dispatchEvent(new TemplateSavedEvent(template));
    }

    public async onClose() {
        await this._modal.closeAsync();
    }

    private _addEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._closeElement.addEventListener("click", this.onClose);
    }

    disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
        this._closeElement.removeEventListener("click", this.onClose);
    }

    private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".template-name") as HTMLInputElement; }
    private get _closeElement() { return this.querySelector("span"); }
}

customElements.define(`ce-template-edit-overlay`,TemplateEditOverlayComponent);
