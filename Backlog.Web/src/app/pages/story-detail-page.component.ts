import { Component, Input, OnInit } from "@angular/core";
import { StoryActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";

@Component({
    template: require("./story-detail-page.component.html"),
    styles: [require("./story-detail-page.component.scss")],
    selector: "story-detail-page"
})
export class StoryDetailPageComponent { 
    constructor(private _storyActions: StoryActions,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _store: AppStore
    ) { }

    ngOnInit() {
        this._storyActions.getById({ id: this._activatedRoute.snapshot.params["id"] });
    }

    public get entity$() {
        return this._store.storyById$(this._activatedRoute.snapshot.params["id"]);
    }
}
