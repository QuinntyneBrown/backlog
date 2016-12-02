import { Task } from "./task.model";
import { TaskService } from "./task.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";
import { TaskAdd } from "./task.actions";

const template = require("./task-edit.component.html");
const styles = require("./task-edit.component.scss");

export class TaskEditComponent extends HTMLElement {
    constructor(
		private _taskService: TaskService = TaskService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return [
            "task",
            "task-id",
            "story-id"
        ];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._addEventListeners();
    }
    
	private _bind() {
        this._titleElement.textContent = "Create task";
        this._descriptionEditor = new EditorComponent(this._descriptionElement);
        this.startDatePicker = rome(this._startElement);
        this.completedDatePicker = rome(this._completedElement);

        if (this.taskId) {
            this._taskService.getById(this.taskId).then((results: string) => { 
                var resultsJSON: Task = JSON.parse(results) as Task;                
                this._nameInputElement.value = resultsJSON.name;  
                this._descriptionEditor.setHTML(resultsJSON.description); 
                this._startElement.value = resultsJSON.startDate;
                this._completedElement.value = resultsJSON.completedDate;           
            });
            this._titleElement.textContent = "Edit Task";
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _addEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);	
	}

    public onSave() {
        var task = {
            id: this.taskId,
            storyId: this.storyId,
            name: this._nameInputElement.value,
            description: this._descriptionEditor.text,
            completedDate: this._completedElement.value,
            startDate: this._startElement.value
        } as Task;
        
        this.dispatchEvent(new TaskAdd(task));
    }

    public onDelete() {        
        this._taskService.remove({ id: this.taskId }).then((results) => {
            this._router.navigate(["task","list"]);
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "task-id":
                this.taskId = newValue;
                break;

            case "story-id":
                this.storyId = newValue;
                break;

            case "task":                
                var task: Task = newValue == "" ? new Task() : JSON.parse(newValue) as Task;
                this.taskId = task.id;
                this._nameInputElement.value = task.name;
                this._descriptionEditor.setHTML(task.description);  
                this._startElement.value = task.startDate;
                this._completedElement.value = task.completedDate;  
                break;
        }        
    }

    private startDatePicker;
    private completedDatePicker;

    private _taskId: number;
    public get taskId(): number { return this._taskId; }
    public set taskId(value: number) {
        this._taskId = value;
        this._titleElement.textContent = this._taskId ? "Edit Task" : "Create Task";
    }
    
    public storyId: number;

    private _descriptionEditor: EditorComponent;
    private get _descriptionElement(): HTMLElement { return this.querySelector(".task-edit-description") as HTMLElement; }
    private get _titleElement(): HTMLElement { return this.querySelector(".task-edit-title") as HTMLElement; }

    private get _startElement(): HTMLInputElement { return this.querySelector(".task-start-date") as HTMLInputElement; }
    private get _completedElement(): HTMLInputElement { return this.querySelector(".task-completed-date") as HTMLInputElement; }
    
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-task-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-task-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".task-name") as HTMLInputElement;}
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-task-edit`,TaskEditComponent));
