import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { EpicActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./landing-page.component.html"),
    styles: [require("./landing-page.component.scss")],
    selector: "landing-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LandingPageComponent implements OnInit {
    constructor(private _epicActions: EpicActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._epicActions.get(); 
    }
    
}
