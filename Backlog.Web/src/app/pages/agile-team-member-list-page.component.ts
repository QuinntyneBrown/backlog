import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { AgileTeamMemberActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./agile-team-member-list-page.component.html"),
    styles: [require("./agile-team-member-list-page.component.scss")],
    selector: "agile-team-member-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AgileTeamMemberListPageComponent implements OnInit {
    constructor(private _agileTeamMemberActions: AgileTeamMemberActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._agileTeamMemberActions.get(); 
    }
    
}
