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

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private _bind() {
        this._taskService.get().then((results: string) => {
            var resultsJSON: Array<Task> = JSON.parse(results) as Array<Task>;
            for (var i = 0; i < resultsJSON.length; i++) {
				let el = this._document.createElement(`ce-task-item`);
				el.setAttribute("entity", JSON.stringify(resultsJSON[i]));
				this.appendChild(el);
            }
        });	
	}
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-task-list", TaskListComponent));
