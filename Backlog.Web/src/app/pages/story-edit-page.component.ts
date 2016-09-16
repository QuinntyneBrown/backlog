import { Component, Input } from "@angular/core";
import { StoryActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./story-edit-page.component.html"),
    styles: [require("./story-edit-page.component.scss")],
    selector: "story-edit-page"
})
export class StoryEditPageComponent { 
    constructor(private _storyActions: StoryActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._storyActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/stories"]); }, 0);
        
    }
}
