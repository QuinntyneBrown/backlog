import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Epic } from "../models";

@Component({
    template: require("./epic-list.component.html"),
    styles: [require("./epic-list.component.scss")],
    selector: "epic-list"
})
export class EpicListComponent {     
    @Input() public entities: Array<any> = [];
    @Output() onDelete: EventEmitter<{ value: Epic }> = new EventEmitter<{ value: Epic }>();
    @Output() onSelect: EventEmitter<{ value: Epic }> = new EventEmitter<{ value: Epic }>();
    @Output() onEdit: EventEmitter<{ value: Epic }> = new EventEmitter<{ value: Epic }>();
    @Output() onCreateStory: EventEmitter<any> = new EventEmitter<any>();
    @Output() onIncrementPriority: EventEmitter<any> = new EventEmitter<any>();
    @Output() onDecrementPriority: EventEmitter<any> = new EventEmitter<any>();
}
