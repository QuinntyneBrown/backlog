import { Component, Input } from "@angular/core";
import { DigitalAssetActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./digital-asset-edit-page.component.html"),
    styles: [require("./digital-asset-edit-page.component.scss")],
    selector: "digital-asset-edit-page"
})
export class DigitalAssetEditPageComponent { 
    constructor(private _digitalAssetActions: DigitalAssetActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._digitalAssetActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/digitalAssets"]); }, 0);
        
    }
}
