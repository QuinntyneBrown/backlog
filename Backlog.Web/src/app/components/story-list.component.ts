import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Story } from "../models";

@Component({
    template: require("./story-list.component.html"),
    styles: [require("./story-list.component.scss")],
    selector: "story-list"
})
export class StoryListComponent {     
    @Input() public entities: Array<Story> = [];
    @Output() onDelete: EventEmitter<{ value: Story }> = new EventEmitter<{ value: Story }>();
    @Output() onSelect: EventEmitter<{ value: Story }> = new EventEmitter<{ value: Story }>();
    @Output() onEdit: EventEmitter<{ value: Story }> = new EventEmitter<{ value: Story }>();
}
