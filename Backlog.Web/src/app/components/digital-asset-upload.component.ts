import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./digital-asset-upload.component.html"),
    styles: [require("./digital-asset-upload.component.scss")],
    selector: "digital-asset-upload",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetUploadComponent implements OnInit { 
    ngOnInit() {

    }
}
