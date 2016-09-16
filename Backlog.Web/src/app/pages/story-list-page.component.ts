import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { StoryActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./story-list-page.component.html"),
    styles: [require("./story-list-page.component.scss")],
    selector: "story-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class StoryListPageComponent implements OnInit {
    constructor(private _storyActions: StoryActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._storyActions.get(); 
    }
    
}
