import { Component, Output, EventEmitter, Input } from "@angular/core";
import { Story } from "./story.model";

@Component({
    templateUrl: "./story-item.component.html",
    styleUrls: ["./story-item.component.css"],
    selector: "ce-story-item"
})
export class StoryItemComponent {         
    @Output()
    public onEditClick: EventEmitter<any> = new EventEmitter();

    @Output()
    public onDeleteClick: EventEmitter<any> = new EventEmitter();
    
    @Input()
    public story: Partial<Story> = {};
}
