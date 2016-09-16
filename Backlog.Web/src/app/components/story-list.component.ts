import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./story-list.component.html"),
    styles: [require("./story-list.component.scss")],
    selector: "story-list"
})
export class StoryListComponent implements OnInit { 
    ngOnInit() {

    }
}
