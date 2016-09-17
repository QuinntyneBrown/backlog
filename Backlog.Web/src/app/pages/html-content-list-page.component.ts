import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { HtmlContentActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./html-content-list-page.component.html"),
    styles: [require("./html-content-list-page.component.scss")],
    selector: "html-content-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HtmlContentListPageComponent implements OnInit {
    constructor(private _htmlContentActions: HtmlContentActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._htmlContentActions.get(); 
    }
    
}
