import { Component, Input, Output, EventEmitter } from "@angular/core";
import { ReusableStoryGroup } from "../models";

@Component({
    template: require("./reusable-story-group-list.component.html"),
    styles: [require("./reusable-story-group-list.component.scss")],
    selector: "reusable-story-group-list"
})
export class ReusableStoryGroupListComponent {     
    @Input() public entities: Array<ReusableStoryGroup> = [];
    @Output() onDelete: EventEmitter<{ value: ReusableStoryGroup }> = new EventEmitter<{ value: ReusableStoryGroup }>();
    @Output() onSelect: EventEmitter<{ value: ReusableStoryGroup }> = new EventEmitter<{ value: ReusableStoryGroup }>();
    @Output() onEdit: EventEmitter<{ value: ReusableStoryGroup }> = new EventEmitter<{ value: ReusableStoryGroup }>();
}
