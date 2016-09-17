import { Component, Input, OnInit } from "@angular/core";
import { StoryActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";

@Component({
    template: require("./story-edit-page.component.html"),
    styles: [require("./story-edit-page.component.scss")],
    selector: "story-edit-page"
})
export class StoryEditPageComponent implements OnInit { 
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

    public onSubmit($event: any) {        
        this._storyActions.add({
            id: $event.value.id,
            epicId: this._activatedRoute.snapshot.params["epicId"],
            name: $event.value.name,
            description: $event.value.description
        });

        setTimeout(() => {
            if (this._activatedRoute.snapshot.params["epicId"]) {
                this._router.navigate(["/epic","detail", this._activatedRoute.snapshot.params["epicId"]]);
            } else {
                this._router.navigate(["/stories"]);
            }
        }, 0);
        
    }
}
