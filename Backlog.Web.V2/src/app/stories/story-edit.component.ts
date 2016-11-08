import { Story } from "./story.model";
import { StoryService } from "./story.service";
import { EditorComponent } from "../shared";
import { StoryAddSuccess, StoryDeleteSuccess } from "./actions";

const template = require("./story-edit.component.html");
const styles = require("./story-edit.component.scss");

export class StoryEditComponent extends HTMLElement {
    constructor(private _storyService: StoryService = StoryService.Instance) {
        super();

    }

    static get observedAttributes() {
        return ["story-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this.saveButtonElement = this.querySelector(".save-button") as HTMLButtonElement;
        this.deleteButtonElement = this.querySelector(".delete-button") as HTMLButtonElement;
        this.titleElement = this.querySelector("h2") as HTMLElement;
        this.nameInputElement = this.querySelector(".story-name") as HTMLInputElement;
        this.titleElement.textContent = "Create story";
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));
        
        if (this.storyId) {
            this._storyService.getById(this.storyId).then((results: string) => { 
                var resultsJSON: Story = JSON.parse(results) as Story;                
                this.nameInputElement.value = resultsJSON.name;              
            });
            this.titleElement.textContent = "Edit Story";
        } else {
            this.deleteButtonElement.style.display = "none";
        } 
    }
    
    public onSave() {
        var story = {
            id: this.storyId,
            name: this.nameInputElement.value
        } as Story;
        
        this._storyService.add(story).then((results) => {
            this.dispatchEvent(new StoryAddSuccess(story));
        });
    }

    public onDelete() {        
        this._storyService.remove({ id: this.storyId }).then((results) => {
            this.dispatchEvent(new StoryDeleteSuccess(this.storyId));
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "story-id":
                this.storyId = newValue;
				break;
        }        
    }

    public storyId: number;
    public titleElement: HTMLElement;
    public saveButtonElement: HTMLButtonElement;
    public deleteButtonElement: HTMLButtonElement;
    public nameInputElement: HTMLInputElement;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-story-edit`,StoryEditComponent));
