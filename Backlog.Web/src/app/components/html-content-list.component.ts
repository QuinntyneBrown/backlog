import { Component, Input, Output, EventEmitter } from "@angular/core";
import { HtmlContent } from "../models";

@Component({
    template: require("./html-content-list.component.html"),
    styles: [require("./html-content-list.component.scss")],
    selector: "html-content-list"
})
export class HtmlContentListComponent {     
    @Input() public entities: Array<HtmlContent> = [];
    @Output() onDelete: EventEmitter<{ value: HtmlContent }> = new EventEmitter<{ value: HtmlContent }>();
    @Output() onSelect: EventEmitter<{ value: HtmlContent }> = new EventEmitter<{ value: HtmlContent }>();
    @Output() onEdit: EventEmitter<{ value: HtmlContent }> = new EventEmitter<{ value: HtmlContent }>();
}
