import { SprintService, Sprint } from "../sprints";
import { TaskService, TaskStatus } from "../tasks";

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

        });
    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }

    private _taskStatuses: Array<TaskStatus> = [];    
    public get taskStatuses() { return this._taskStatuses; }
    public set taskStatuses(value:any) { this._taskStatuses = value; }

    private _sprints: Array<Sprint> = [];
    public get sprints() { return this._sprints; }
    public set sprints(value: any) { this._sprints = value; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define(`ce-kanban-board`, KanbanBoardComponent));
