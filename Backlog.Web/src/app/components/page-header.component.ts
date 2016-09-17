import { Component, Input } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    template: require("./page-header.component.html"),
    styles: [require("./page-header.component.scss")],
    selector: "page-header",    
})
export class PageHeaderComponent { 
    constructor(private _router: Router) { }
    @Input() title: string;
    @Input() menuItems: Array<any> = [];
}
