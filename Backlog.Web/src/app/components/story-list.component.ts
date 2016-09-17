import { Component, Input, Output, EventEmitter, ElementRef } from "@angular/core";
import { Story } from "../models";
import { StoryActions } from "../actions";

@Component({
    template: require("./story-list.component.html"),
    styles: [require("./story-list.component.scss")],
    selector: "story-list"
})
export class StoryListComponent {     
    constructor(private _elementRef: ElementRef, private _storyActions: StoryActions) { }

    @Input() public entities: Array<Story> = [];
    @Output() onDelete: EventEmitter<{ value: Story }> = new EventEmitter<{ value: Story }>();
    @Output() onSelect: EventEmitter<{ value: Story }> = new EventEmitter<{ value: Story }>();
    @Output() onEdit: EventEmitter<{ value: Story }> = new EventEmitter<{ value: Story }>();
    
}
