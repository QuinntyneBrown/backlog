import { SprintService, Sprint } from "../sprints";
import { TaskService, TaskStatus } from "../tasks";
import { KanbanBoardItemComponent } from "./kanban-board-item.component";

const template = require("./kanban-board.component.html");
const styles = require("./kanban-board.component.scss");

export class KanbanBoardComponent extends HTMLElement {
    constructor(
        private _sprintService: SprintService = SprintService.Instance,
        private _taskService: TaskService = TaskService.Instance
    ) {
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
        Promise.all([
            this._taskService.getTaskStatuses(),
            this._sprintService.getCurrent()
        ]).then((results: any) => {
            this.sprint = JSON.parse(results[1]) as Sprint;
            for (var i = 0; i < this.sprint.stories.length; i++) {
                for (var x = 0; x < this.sprint.stories[i].tasks.length; x++) {
                    let kanbanBoardItem = document.createElement("ce-kanban-board-item") as KanbanBoardItemComponent;
                    this.appendChild(kanbanBoardItem);
                }
            }
        });
    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }

    private _taskStatuses: Array<TaskStatus> = [];    
    public get taskStatuses() { return this._taskStatuses; }
    public set taskStatuses(value:any) { this._taskStatuses = value; }

    private _sprint: Sprint;
    public get sprint():Sprint { return this._sprint; }
    public set sprint(value: Sprint) { this._sprint = value; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define(`ce-kanban-board`, KanbanBoardComponent));
