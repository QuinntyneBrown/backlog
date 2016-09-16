import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./page-footer.component.html"),
    styles: [require("./page-footer.component.scss")],
    selector: "page-footer",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class PageFooterComponent implements OnInit { 
    ngOnInit() {

    }
}
