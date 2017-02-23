import { KanbanBoardTask } from "./kanban-board-task.model";

const template = require("./kanban-board-task-container.component.html");
const styles = require("./kanban-board-task-container.component.scss");

export class KanbanBoardTaskContainerComponent extends HTMLElement {
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

    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }

    private _kanbanBoardTask: KanbanBoardTask;
    public get task(): KanbanBoardTask { return this._kanbanBoardTask; }
    public set task(value: KanbanBoardTask) {
        this._kanbanBoardTask = value;
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-kanban-board-task-container`,KanbanBoardTaskContainerComponent));
