import { Component, Input, Output, EventEmitter } from "@angular/core";
import { DigitalAsset } from "../models";

@Component({
    template: require("./digital-asset-list.component.html"),
    styles: [require("./digital-asset-list.component.scss")],
    selector: "digital-asset-list"
})
export class DigitalAssetListComponent {     
    @Input() public entities: Array<DigitalAsset> = [];
    @Output() onDelete: EventEmitter<{ value: DigitalAsset }> = new EventEmitter<{ value: DigitalAsset }>();
    @Output() onSelect: EventEmitter<{ value: DigitalAsset }> = new EventEmitter<{ value: DigitalAsset }>();
    @Output() onEdit: EventEmitter<{ value: DigitalAsset }> = new EventEmitter<{ value: DigitalAsset }>();
}
