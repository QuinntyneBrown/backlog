import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./story-edit-page.component.html"),
    styles: [require("./story-edit-page.component.scss")],
    selector: "story-edit-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class StoryEditPageComponent implements OnInit { 
    ngOnInit() {

    }
}
