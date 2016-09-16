import { Component, Input } from "@angular/core";
import { SprintActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./sprint-edit-page.component.html"),
    styles: [require("./sprint-edit-page.component.scss")],
    selector: "sprint-edit-page"
})
export class SprintEditPageComponent { 
    constructor(private _sprintActions: SprintActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._sprintActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/sprints"]); }, 0);
        
    }
}
