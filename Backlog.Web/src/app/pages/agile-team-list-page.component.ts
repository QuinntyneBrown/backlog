import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { AgileTeamActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./agile-team-list-page.component.html"),
    styles: [require("./agile-team-list-page.component.scss")],
    selector: "agile-team-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AgileTeamListPageComponent implements OnInit {
    constructor(private _agileTeamActions: AgileTeamActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._agileTeamActions.get(); 
    }
    
}
