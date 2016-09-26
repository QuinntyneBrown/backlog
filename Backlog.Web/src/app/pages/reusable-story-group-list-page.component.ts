import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { ReusableStoryGroupActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./reusable-story-group-list-page.component.html"),
    styles: [require("./reusable-story-group-list-page.component.scss")],
    selector: "reusable-story-group-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReusableStoryGroupListPageComponent implements OnInit {
    constructor(private _reusableStoryGroupActions: ReusableStoryGroupActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._reusableStoryGroupActions.get(); 
    }
    
}
