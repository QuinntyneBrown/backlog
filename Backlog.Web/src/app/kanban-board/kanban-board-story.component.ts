import { KanbanBoardStory } from "./kanban-board-story.model";
import { KanbanBoardTaskContainerComponent } from "./kanban-board-task-container.component";

const template = require("./kanban-board-story.component.html");
const styles = require("./kanban-board-story.component.scss");

export class KanbanBoardStoryComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this._nameElement.textContent = this.story.name;
        this._descriptionElement.textContent = this.story.description;
        this._tasksContainerElement.innerHTML = "";
        for (var i = 0; i < this.story.tasks.length; i++) {
            let kanbanBoardTaskContainerComponent = document.createElement("ce-kanban-board-task-container") as KanbanBoardTaskContainerComponent;
            kanbanBoardTaskContainerComponent.task = this.story.tasks[i];
            this._tasksContainerElement.appendChild(kanbanBoardTaskContainerComponent);
        }
    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }

    private get _nameElement(): HTMLElement { return this.querySelector(".kanban-board-story-name") as HTMLElement; }

    private get _descriptionElement(): HTMLElement { return this.querySelector(".kanban-board-story-description") as HTMLElement; }

    private get _tasksContainerElement(): HTMLElement { return this.querySelector(".kanban-board-story-tasks-container") as HTMLElement; }

    private _story: KanbanBoardStory;

    public get story(): KanbanBoardStory { return this._story; }

    public set story(value: KanbanBoardStory) {
        this._story = value;
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-kanban-board-story`,KanbanBoardStoryComponent));
