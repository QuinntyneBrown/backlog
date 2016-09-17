import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { EpicActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";

@Component({
    template: require("./epic-edit-page.component.html"),
    styles: [require("./epic-edit-page.component.scss")],
    selector: "epic-edit-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicEditPageComponent implements OnInit { 
    constructor(
        private _epicActions: EpicActions,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _store: AppStore
    ) { }

    ngOnInit() {
        if (this._activatedRoute.snapshot.params["id"]) {
            this._epicActions.getById({
                id: this._activatedRoute.snapshot.params["id"]
            });
        }
    }
    public onSubmit($event: any) {
        this._epicActions.add({
            id: $event.value.id,
            name: $event.value.name,
            priority: $event.value.priority,
            stories:[],
            description: $event.value.description
        });

        setTimeout(() => { this._router.navigate(["/epics"]); }, 0);        
    }

    public tryToCancel() {
        setTimeout(() => { this._router.navigate(["/epics"]); }, 0);
    }

    public get entity$() {
        return this._store.epicById$(this._activatedRoute.snapshot.params["id"]);
    }
}
