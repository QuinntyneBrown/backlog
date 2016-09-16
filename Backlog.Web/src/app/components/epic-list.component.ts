import { Component, Input, OnInit } from "@angular/core";

@Component({
    template: require("./epic-list.component.html"),
    styles: [require("./epic-list.component.scss")],
    selector: "epic-list"
})
export class EpicListComponent implements OnInit { 
    ngOnInit() {

    }

    @Input() public entities: Array<any> = [];
}
