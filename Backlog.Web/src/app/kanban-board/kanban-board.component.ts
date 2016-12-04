import { KanbanBoardService } from "./kanban-board.service";
import { KanbanBoardItemContainerComponent } from "./kanban-board-item-container.component";
import { KanbanBoard } from "./kanban-board.model";

const template = require("./kanban-board.component.html");
const styles = require("./kanban-board.component.scss");

export class KanbanBoardComponent extends HTMLElement {
    constructor(
        private _kanbanBoardService: KanbanBoardService = KanbanBoardService.Instance,        
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
        this._kanbanBoardService.get().then((results: string) => {
            this.kanbanBoard = JSON.parse(results) as KanbanBoard;
            for (var i = 0; i < this.kanbanBoard.items.length; i++) {
                let kanbanBoardItemContainer = document.createElement("ce-kanban-board-item-container") as KanbanBoardItemContainerComponent;
                kanbanBoardItemContainer.kanbanBoardItem = this.kanbanBoard.items[i];
                this.appendChild(kanbanBoardItemContainer);
            }
        });
    }

    private _addEventListeners() {

    }

    disconnectedCallback() {

    }

    
    private _kanbanBoard: KanbanBoard;
    public get kanbanBoard():KanbanBoard { return this._kanbanBoard; }
    public set kanbanBoard(value: KanbanBoard) { this._kanbanBoard = value; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define(`ce-kanban-board`, KanbanBoardComponent));
