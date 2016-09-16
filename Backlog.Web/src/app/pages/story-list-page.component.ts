import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./story-list-page.component.html"),
    styles: [require("./story-list-page.component.scss")],
    selector: "story-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class StoryListPageComponent implements OnInit { 
    ngOnInit() {

    }
}
