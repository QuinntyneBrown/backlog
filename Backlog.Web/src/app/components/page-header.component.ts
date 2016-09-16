import { Component, Input } from "@angular/core";

@Component({
    template: require("./page-header.component.html"),
    styles: [require("./page-header.component.scss")],
    selector: "page-header",    
})
export class PageHeaderComponent { 
    @Input() title: string;
    @Input() menuItems: Array<any> = [];
}
