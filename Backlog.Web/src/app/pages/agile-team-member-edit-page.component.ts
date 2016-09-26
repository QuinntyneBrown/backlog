import { Component, Input, OnInit } from "@angular/core";
import { AgileTeamMemberActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";

@Component({
    template: require("./agile-team-member-edit-page.component.html"),
    styles: [require("./agile-team-member-edit-page.component.scss")],
    selector: "agile-team-member-edit-page"
})
export class AgileTeamMemberEditPageComponent { 
    constructor(private _agileTeamMemberActions: AgileTeamMemberActions, 
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _store: AppStore
    ) { }

    ngOnInit() {
        this._agileTeamMemberActions.getById({ id: this._activatedRoute.snapshot.params["id"] });
    }

    public get entity$() {
        return this._store.agileTeamMemberById$(this._activatedRoute.snapshot.params["id"]);
    }

    public onSubmit($event: any) {
        this._agileTeamMemberActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/agileTeamMembers"]); }, 0);
        
    }

    public onCancel() {
        setTimeout(() => { this._router.navigate(["/agileTeamMembers"]); }, 0);
    }
}
