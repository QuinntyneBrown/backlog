import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { DigitalAssetActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./digital-asset-list-page.component.html"),
    styles: [require("./digital-asset-list-page.component.scss")],
    selector: "digital-asset-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetListPageComponent implements OnInit {
    constructor(private _digitalAssetActions: DigitalAssetActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._digitalAssetActions.get(); 
    }
    
}
