import { KanbanBoard } from "./kanban-board.model";
import { KanbanBoardService } from "./kanban-board.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./kanban-board-item.component.html");
const styles = require("./kanban-board-item.component.scss");

export class KanbanBoardItemComponent extends HTMLElement {
    constructor(
        private _kanbanBoardService: KanbanBoardService = KanbanBoardService.Instance,
        private _router: Router = Router.Instance) {
        super();
    }

    static get observedAttributes() {
        return [];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    disconnectedCallback() {
    }

    private _bind() {
    }

    private _addEventListeners() {
    }

    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
        }        
    }
    
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-kanban-board-item`,KanbanBoardItemComponent));
