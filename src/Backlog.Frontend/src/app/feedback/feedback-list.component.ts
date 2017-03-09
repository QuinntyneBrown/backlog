import { Feedback } from "./feedback.model";
import { FeedbackService } from "./feedback.service";
import { CurrentUser } from "../users";

const template = require("./feedback-list.component.html");
const styles = require("./feedback-list.component.scss");

export class FeedbackListComponent extends HTMLElement {
    constructor(
        private _currentUser: CurrentUser = CurrentUser.Instance,
		private _document: Document = document,
		private _feedbackService: FeedbackService = FeedbackService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {
        const feedbacks = await this._feedbackService.get({ username: this._currentUser.username }); 
        for (var i = 0; i < feedbacks.length; i++) {
			let el = this._document.createElement(`ce-feedback-item`);
			el.setAttribute("entity", JSON.stringify(feedbacks[i]));
			this.appendChild(el);
        }	
	}
}

customElements.define("ce-feedback-list", FeedbackListComponent);
