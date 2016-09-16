import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { EpicActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./epic-edit-page.component.html"),
    styles: [require("./epic-edit-page.component.scss")],
    selector: "epic-edit-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicEditPageComponent { 
    constructor(private _epicActions: EpicActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._epicActions.add({
            id: $event.value.id,
            name: $event.value.name,
            description: $event.value.description
        });
        this._router.navigate(["/epics"]);
    }
}
