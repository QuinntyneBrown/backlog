import { Feedback } from "./feedback.model";
import { FeedbackService } from "./feedback.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./feedback-edit.component.html");
const styles = require("./feedback-edit.component.scss");

export class FeedbackEditComponent extends HTMLElement {
    constructor(private _feedbackService: FeedbackService = FeedbackService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;         
        this.titleElement.textContent = "Add Your 2 Cents";
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.descriptionEditor = new EditorComponent(this.descriptionElement);        
    }
    
    public onSave() {
        var feedback = {
            id: this.feedbackId,
            emailAddress: this.emailAddressElement.value,
            description: this.descriptionEditor.text
        } as any;
        
        this._feedbackService.add(feedback).then((results) => {
            this._router.navigate(["feedback","received"]);
        });
    }
    
    public feedbackId: number;
    private descriptionEditor: EditorComponent;

    private get descriptionElement(): HTMLElement { return this.querySelector(".description") as HTMLElement; }
    private get emailAddressElement(): HTMLInputElement { return this.querySelector(".email-address") as HTMLInputElement; }
    public get titleElement() { return this.querySelector("h2") as HTMLElement; }    
    public get saveButtonElement(): HTMLButtonElement { return this.querySelector(".save-button") as HTMLButtonElement; }
    public get nameInputElement(): HTMLInputElement  { return this.querySelector(".name") as HTMLInputElement; }

}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-feedback-edit`,FeedbackEditComponent));
