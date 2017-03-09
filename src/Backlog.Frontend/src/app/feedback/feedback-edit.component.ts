import { Feedback } from "./feedback.model";
import { FeedbackService } from "./feedback.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";
import { CurrentUser } from "../users";

const template = require("./feedback-edit.component.html");
const styles = require("./feedback-edit.component.scss");

export class FeedbackEditComponent extends HTMLElement {
    constructor(
        private _currentUser: CurrentUser = CurrentUser.Instance,
        private _feedbackService: FeedbackService = FeedbackService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
        this.onSave = this.onSave.bind(this);
    }

    static get observedAttributes() {
        return ["feedback-id"];
    }

    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;         
        this.titleElement.textContent = "Feedback";
        this.saveButtonElement.addEventListener("click", this.onSave);
        this.descriptionEditor = new EditorComponent(this.descriptionElement); 
        this.bind();       
    }

    public async bind() {
        if (this.feedbackId) {
            const feedback = await this._feedbackService.getById(this.feedbackId);
            this.descriptionEditor.setHTML(feedback.description);
        }
    }

    public async onSave() {
        const feedback = {
            id: this.feedbackId,
            emailAddress: this._currentUser.username,
            description: this.descriptionEditor.text
        } as any;
        
        await this._feedbackService.add(feedback);           
        this._router.navigate(["feedback", "received"]);
    }


    public feedbackId: number = 0;
    private descriptionEditor: EditorComponent;


    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "feedback-id":
                this.feedbackId = newValue;
                break;
        }
    }

    private get descriptionElement(): HTMLElement { return this.querySelector(".description") as HTMLElement; }
    private get emailAddressElement(): HTMLInputElement { return this.querySelector(".email-address") as HTMLInputElement; }
    public get titleElement() { return this.querySelector("h2") as HTMLElement; }    
    public get saveButtonElement(): HTMLButtonElement { return this.querySelector(".save-button") as HTMLButtonElement; }
    public get nameInputElement(): HTMLInputElement  { return this.querySelector(".name") as HTMLInputElement; }

}

customElements.define(`ce-feedback-edit`,FeedbackEditComponent);
