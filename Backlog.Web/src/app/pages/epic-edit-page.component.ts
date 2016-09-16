import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./epic-edit-page.component.html"),
    styles: [require("./epic-edit-page.component.scss")],
    selector: "epic-edit-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicEditPageComponent implements OnInit { 
    ngOnInit() {

    }
}
