import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./story-detail.component.html"),
    styles: [require("./story-detail.component.scss")],
    selector: "story-detail",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class StoryDetailComponent implements OnInit { 
    ngOnInit() {

    }
}
