const template = require("./kanban-board-task.component.html");
const styles = require("./kanban-board-task.component.scss");

export class KanbanBoardTaskComponent extends HTMLElement {
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

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-kanban-board-task`,KanbanBoardTaskComponent));
