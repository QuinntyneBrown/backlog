import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./side-nav-menu.component.html"),
    styles: [require("./side-nav-menu.component.scss")],
    selector: "side-nav-menu",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit { 
    ngOnInit() {

    }
}
