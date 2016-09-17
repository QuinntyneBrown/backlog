import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { EpicActions, StoryActions } from "../actions";
import { ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";
import { Router } from "@angular/router";

@Component({
    template: require("./epic-detail-page.component.html"),
    styles: [require("./epic-detail-page.component.scss")],
    selector: "epic-detail-page"    
})
export class EpicDetailPageComponent implements OnInit { 
    constructor(
        private _store: AppStore,
        private _epicActions: EpicActions,
        private _activatedRoute: ActivatedRoute,
        private _storyActions: StoryActions,
        private _router: Router
    ) { }

    ngOnInit() {
        this._epicActions.getById({
            id: this._activatedRoute.snapshot.params["id"]
        });
    }

    public get epic$() {
        return this._store.epicById$(this._activatedRoute.snapshot.params["id"]);
    }

    public get epicId() {
        var id = 0;
        this.epic$.take(1).subscribe(x => id = x.id);
        return id;
    }
}
