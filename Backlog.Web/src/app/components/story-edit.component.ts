import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./story-edit.component.html"),
    styles: [require("./story-edit.component.scss")],
    selector: "story-edit"
})
export class StoryEditComponent implements OnInit { 
    ngOnInit() {

    }
}
