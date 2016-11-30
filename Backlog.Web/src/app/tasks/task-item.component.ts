import { Task } from "./task.model";
import { TaskService } from "./task.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./task-item.component.html");
const styles = require("./task-item.component.scss");

export class TaskItemComponent extends HTMLElement {
    constructor(
        private _taskService: TaskService = TaskService.Instance,
        private _router: Router = Router.Instance) {
        super();
    }

    static get observedAttributes() {
        return ["entity"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._addEventListeners();
    }

    disconnectedCallback() {
        this._deleteLinkElement.removeEventListener("click", this._onDeleteClick.bind(this));
        this._editLinkElement.removeEventListener("click", this._onEditClick.bind(this));
        this._viewLinkElement.removeEventListener("click", this._onViewClick.bind(this));
    }

    private _bind() {
        this._nameElement.textContent = this.entity.name;
    }

    private _addEventListeners() {
        this._deleteLinkElement.addEventListener("click", this._onDeleteClick.bind(this));
        this._editLinkElement.addEventListener("click", this._onEditClick.bind(this));
        this._viewLinkElement.addEventListener("click", this._onViewClick.bind(this));
    }

    private _onDeleteClick(e:Event) {
        this._taskService.remove({ id: this.entity.id }).then(() => {
            this.parentNode.removeChild(this);
        });
    }

    private _onEditClick() {
        this._router.navigate(["task", "edit", this.entity.id]);
    }

    private _onViewClick() {
        this._router.navigate(["task","view",this.entity.id]);
    }
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "entity":
                this.entity = JSON.parse(newValue);
				break;
        }        
    }

    private get _nameElement() { return this.querySelector("p") as HTMLElement; }
    private get _deleteLinkElement() { return this.querySelector(".entity-item-delete") as HTMLElement; }
    private get _editLinkElement() { return this.querySelector(".entity-item-edit") as HTMLElement; }
    private get _viewLinkElement() { return this.querySelector(".entity-item-view") as HTMLElement; }
    public entity: Task;
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-task-item`,TaskItemComponent));
