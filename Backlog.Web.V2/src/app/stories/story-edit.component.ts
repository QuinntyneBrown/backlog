import { Story } from "./story.model";
import { StoryService } from "./story.service";
import { EditorComponent, dropZoneEvents, DropZoneComponent } from "../shared";
import { StoryAddSuccess, StoryDeleteSuccess } from "./actions";
import { Router } from "../router";

const template = require("./story-edit.component.html");
const styles = require("./story-edit.component.scss");

export class StoryEditComponent extends HTMLElement {
    constructor(private _storyService: StoryService = StoryService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
    }

    static get observedAttributes() {
        return ["story-id","epic-id"];
    }
    
    connectedCallback() {        
        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this.saveButtonElement = this.querySelector(".save-button") as HTMLButtonElement;
        this.deleteButtonElement = this.querySelector(".delete-button") as HTMLButtonElement;
        this.titleElement = this.querySelector("h2") as HTMLElement;
        this.nameInputElement = this.querySelector(".story-name") as HTMLInputElement;
        this.titleElement.textContent = "Create Story";
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));
        this.descriptionEditor = new EditorComponent(this.descriptionElement);
        this.notesEditor = new EditorComponent(this.notesElement);
        this.descriptionEditor.setHTML("<p><strong>As a </strong>product owner</p> <p><strong>I want/can</strong> &lt;action&gt;</p> <p><strong>so that</strong> &lt;reason&gt;</p>");

        if (this.storyId) {
            this._storyService.getById(this.storyId).then((results: string) => { 
                var resultsJSON: Story = JSON.parse(results) as Story;                    
                this.nameInputElement.value = resultsJSON.name;   
                this.descriptionEditor.setHTML(resultsJSON.description);       
                this.priorityElement.value = resultsJSON.priority;    
                this.notesEditor.setHTML(resultsJSON.notes);
                this.pointsInputElement.value = resultsJSON.points;
                this.architecturePointsInputElement.value = resultsJSON.architecturePoints;

                resultsJSON.digitalAssets.map(d => {
                    let el = document.createElement("ce-story-digital-asset") as HTMLElement;
                    el.setAttribute("relative-path", d.relativePath);
                    el.setAttribute("digital-asset-id", d.id);
                    this.digitalAssetsContainer.appendChild(el);
                });
            });
            this.titleElement.textContent = "Edit Story";
        } else {
            this.deleteButtonElement.style.display = "none";
            this.imageDropZoneElement.style.display = "none";
        } 

        
        this._addEventListeners();
    }


    private _addEventListeners() {
        this.imageDropZoneElement.addEventListener(dropZoneEvents.DROP, this.onImageDrop.bind(this));
    }

    public onImageDrop(e) {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", `/api/digitalasset/upload?id=${this.storyId}`, true);
        xhr.onload = (e) => {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    this._router.navigate(["epic", this.epicId, "story", "edit",this.storyId]);
                }
                else {
                    console.error(xhr.statusText);
                }
            }
        };
        xhr.send(e.detail.files);
    }

    public onSave() {
        var story = {
            id: this.storyId,
            epicId: this.epicId,
            name: this.nameInputElement.value,
            priority: this.priorityElement.id,
            description: this.descriptionEditor.text,
            notes: this.notesEditor.text,
            points: this.pointsInputElement.value,
            architecturePoints: this.architecturePointsInputElement.value
        } as Story;


        this._storyService.add(story).then((results) => {
            this._router.navigate(["epic", "view", this.epicId]);
        });
    }

    public onDelete() {        
        this._storyService.remove({ id: this.storyId }).then((results) => {
            this._router.navigate(["epic", "view", this.epicId]);            
        });        
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "story-id":
                this.storyId = newValue;
                break;

            case "epic-id":
                this.epicId = newValue;
                break;
        }        
    }

    public storyId: number;
    public epicId: number;
    public get imageDropZoneElement(): DropZoneComponent { return this.querySelector("ce-drop-zone") as DropZoneComponent; }
    public get descriptionElement(): HTMLElement { return this.querySelector(".story-description") as HTMLElement; }
    public descriptionEditor: EditorComponent;
    public get notesElement(): HTMLElement { return this.querySelector(".story-notes") as HTMLElement; }
    public notesEditor: EditorComponent;
    public get priorityElement(): HTMLInputElement { return this.querySelector(".priority") as HTMLInputElement; }
    public get pointsInputElement(): HTMLInputElement { return this.querySelector(".points") as HTMLInputElement; }
    public get architecturePointsInputElement(): HTMLInputElement { return this.querySelector(".architecture-points") as HTMLInputElement; }
    public get digitalAssetsContainer(): HTMLElement { return this.querySelector(".story-digital-assets") as HTMLElement; }
    public titleElement: HTMLElement;
    public saveButtonElement: HTMLButtonElement;
    public deleteButtonElement: HTMLButtonElement;
    public nameInputElement: HTMLInputElement;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-story-edit`,StoryEditComponent));
