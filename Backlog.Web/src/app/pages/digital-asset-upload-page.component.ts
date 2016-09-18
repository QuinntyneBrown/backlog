import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { DigitalAssetActions } from "../actions";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    template: require("./digital-asset-upload-page.component.html"),
    styles: [require("./digital-asset-upload-page.component.scss")],
    selector: "digital-asset-upload-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetUploadPageComponent { 

    constructor(private _digitalAssetActions: DigitalAssetActions,
        private _activatedRoute: ActivatedRoute,
        private _router: Router
    ) { }
    
    onUpload($event) {        
        var id = this._activatedRoute.snapshot.params["id"];
        this._digitalAssetActions.upload({ formData: $event.files, id: id });

        setTimeout(() => {
            this._router.navigate(['story',id]);
        }, 0);
    }
}
