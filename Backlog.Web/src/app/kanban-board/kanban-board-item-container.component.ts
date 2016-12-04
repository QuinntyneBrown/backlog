import { KanbanBoardItemComponent } from "./kanban-board-item.component";
import { KanbanBoardTask } from "./kanban-board-item.model";

const template = require("./kanban-board-item-container.component.html");
const styles = require("./kanban-board-item-container.component.scss");

export class KanbanBoardItemContainerComponent extends HTMLElement {
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

    private _kanbanBoardItem: KanbanBoardTask;
    public get kanbanBoardItem(): KanbanBoardTask { return this._kanbanBoardItem; }
    public set kanbanBoardItem(value: KanbanBoardTask) {
        this._kanbanBoardItem = value;
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-kanban-board-item-container`,KanbanBoardItemContainerComponent));
