import { Component, Input, OnInit } from "@angular/core";
import { ReusableStoryGroupActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";

@Component({
    template: require("./reusable-story-group-edit-page.component.html"),
    styles: [require("./reusable-story-group-edit-page.component.scss")],
    selector: "reusable-story-group-edit-page"
})
export class ReusableStoryGroupEditPageComponent { 
    constructor(private _reusableStoryGroupActions: ReusableStoryGroupActions, 
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _store: AppStore
    ) { }

    ngOnInit() {
        this._reusableStoryGroupActions.getById({ id: this._activatedRoute.snapshot.params["id"] });
    }

    public get entity$() {
        return this._store.reusableStoryGroupById$(this._activatedRoute.snapshot.params["id"]);
    }

    public onSubmit($event: any) {
        this._reusableStoryGroupActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/reusablestoryGroups"]); }, 0);
        
    }
}
