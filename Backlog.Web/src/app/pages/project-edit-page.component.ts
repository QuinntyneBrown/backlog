import { Component, Input, OnInit } from "@angular/core";
import { ProjectActions } from "../actions";
import { Router, ActivatedRoute } from "@angular/router";
import { AppStore } from "../store";

@Component({
    template: require("./project-edit-page.component.html"),
    styles: [require("./project-edit-page.component.scss")],
    selector: "project-edit-page"
})
export class ProjectEditPageComponent { 
    constructor(private _projectActions: ProjectActions, 
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _store: AppStore
    ) { }

    ngOnInit() {
        this._projectActions.getById({ id: this._activatedRoute.snapshot.params["id"] });
    }

    public get entity$() {
        return this._store.projectById$(this._activatedRoute.snapshot.params["id"]);
    }

    public onSubmit($event: any) {
        this._projectActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/projects"]); }, 0);
        
    }

    public onCancel() {
        setTimeout(() => { this._router.navigate(["/projects"]); }, 0);
    }
}
