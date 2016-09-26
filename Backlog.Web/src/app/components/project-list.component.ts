import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Project } from "../models";

@Component({
    template: require("./project-list.component.html"),
    styles: [require("./project-list.component.scss")],
    selector: "project-list"
})
export class ProjectListComponent {     
    @Input() public entities: Array<Project> = [];
    @Output() onDelete: EventEmitter<{ value: Project }> = new EventEmitter<{ value: Project }>();
    @Output() onSelect: EventEmitter<{ value: Project }> = new EventEmitter<{ value: Project }>();
    @Output() onEdit: EventEmitter<{ value: Project }> = new EventEmitter<{ value: Project }>();
}
