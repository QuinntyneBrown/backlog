import { Task } from "./task.model";
import { TaskService } from "./task.service";

const template = require("./task-list.component.html");
const styles = require("./task-list.component.scss");

export class TaskListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _taskService: TaskService = TaskService.Instance) {
        super();
    }

    static get observedAttributes() {
        return [
            "story-id",
            "tasks"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;        
		this._bind();
    }

    private _tasks: Array<Task> = [];

    public set tasks(value: any) { this._tasks = value; }

    public get tasks() { return this._tasks; }

    private _bind(tasks:Array<Task> = null) {
        if (this._storyId && !tasks) {
            this._taskService.getByStoryId(this._storyId).then((results: string) => {
                this.innerHTML = `<style>${styles}</style> ${template}`;
                var resultsJSON: Array<Task> = JSON.parse(results) as Array<Task>;
                for (var i = 0; i < resultsJSON.length; i++) {
                    let el = this._document.createElement(`ce-task-item`);
                    el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
                    this.appendChild(el);
                }
            });
        }

        if (tasks) {
            this.innerHTML = `<style>${styles}</style> ${template}`;          
            for (var i = 0; i < tasks.length; i++) {
                let el = this._document.createElement(`ce-task-item`);
                el.setAttribute("entity", JSON.stringify(tasks[i]));
                this.appendChild(el);
            }
        }
    }

    private _storyId;
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "story-id":
                this._storyId = JSON.parse(newValue);
                if (this.parentNode)
                    this._bind();                
                break;

            case "tasks":                
                if (this.parentNode && newValue != "") 
                    this._bind(JSON.parse(newValue));
                
                if (this.parentNode && newValue == "")
                    this._bind();
                
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-task-list", TaskListComponent));
