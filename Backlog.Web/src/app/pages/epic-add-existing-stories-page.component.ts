import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { StoryActions } from "../actions";
import { AppStore } from "../store";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    template: require("./epic-add-existing-stories-page.component.html"),
    styles: [require("./epic-add-existing-stories-page.component.scss")],
    selector: "epic-add-existing-stories-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicAddExistingStoriesPageComponent implements OnInit { 
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _storyActions: StoryActions,
        private _store: AppStore,
        private _router: Router
    ) { }

    ngOnInit() {
        this._storyActions.getReusableStories();
    }

    public get epicId() {
        return this._activatedRoute.snapshot.params["id"];
    }
}
