import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./epic-add-existing-stories-page.component.html"),
    styles: [require("./epic-add-existing-stories-page.component.scss")],
    selector: "epic-add-existing-stories-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicAddExistingStoriesPageComponent implements OnInit { 
    ngOnInit() {

    }
}
