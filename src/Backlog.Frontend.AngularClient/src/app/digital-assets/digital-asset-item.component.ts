import { Component, EventEmitter, Output, Input } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { DigitalAsset } from "./digital-asset.model";
declare var moment;

@Component({
    templateUrl: "./digital-asset-item.component.html",
    styleUrls: ["./digital-asset-item.component.css"],
    selector: "ce-digital-asset-item"
})
export class DigitalAssetItemComponent { 
    @Output()
    public onEditClick: EventEmitter<any> = new EventEmitter();

    @Output()
    public onDeleteClick: EventEmitter<any> = new EventEmitter();

    @Input()
    public digitalAsset: Partial<DigitalAsset> = {};

    @Output()
    public onViewClick: EventEmitter<any> = new EventEmitter();

    public get uploadedOn() { return moment(this.digitalAsset.uploadedOn, "YYYYMMDD").fromNow(); }
}
