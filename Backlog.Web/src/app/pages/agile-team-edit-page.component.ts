import { Component, Input } from "@angular/core";
import { AgileTeamActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./agile-team-edit-page.component.html"),
    styles: [require("./agile-team-edit-page.component.scss")],
    selector: "agile-team-edit-page"
})
export class AgileTeamEditPageComponent { 
    constructor(private _agileTeamActions: AgileTeamActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._agileTeamActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/agileTeams"]); }, 0);
        
    }
}
