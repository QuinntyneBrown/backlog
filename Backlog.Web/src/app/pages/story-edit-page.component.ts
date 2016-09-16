import { Component, Input } from "@angular/core";
import { StoryActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { ActivatedRouteSnapshot } from "@angular/router";

@Component({
    template: require("./story-edit-page.component.html"),
    styles: [require("./story-edit-page.component.scss")],
    selector: "story-edit-page"
})
export class StoryEditPageComponent { 
    constructor(private _storyActions: StoryActions, private _router: Router, private _activatedRoute: ActivatedRoute) { }

    public onSubmit($event: any) {
        this._storyActions.add({
            id: $event.value.id,
            epicId: this._activatedRoute.snapshot.params["epicId"],
            name: $event.value.name
        });

        setTimeout(() => {
            if (this._activatedRoute.snapshot.params["epicId"]) {
                this._router.navigate(["/epics"]);
            } else {
                this._router.navigate(["/stories"]);
            }
        }, 0);
        
    }
}
