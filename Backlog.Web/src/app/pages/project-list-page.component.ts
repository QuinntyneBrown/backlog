import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { ProjectActions } from "../actions";
import { AppStore } from "../store";
import { Router } from "@angular/router";   

@Component({
    template: require("./project-list-page.component.html"),
    styles: [require("./project-list-page.component.scss")],
    selector: "project-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProjectListPageComponent implements OnInit {
    constructor(private _projectActions: ProjectActions, private _store: AppStore, private _router:Router) { }

    ngOnInit() {
        this._projectActions.get(); 
    }
    
}
