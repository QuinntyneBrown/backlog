import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { ProjectService } from "../services";
import { AppState, AppStore } from "../store";
import { PROJECT_ADD_SUCCESS, PROJECT_GET_SUCCESS, PROJECT_REMOVE_SUCCESS } from "../constants";
import { Project } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class ProjectActions {
    constructor(private _projectService: ProjectService, private _store: AppStore) { }

    public add(project: Project) {
        const newGuid = guid();
        this._projectService.add(project)
            .subscribe(project => {
                this._store.dispatch({
                    type: PROJECT_ADD_SUCCESS,
                    payload: project
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._projectService.get()
            .subscribe(projects => {
                this._store.dispatch({
                    type: PROJECT_GET_SUCCESS,
                    payload: projects
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._projectService.remove({ id: options.id })
            .subscribe(project => {
                this._store.dispatch({
                    type: PROJECT_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._projectService.getById({ id: options.id })
            .subscribe(project => {
                this._store.dispatch({
                    type: PROJECT_GET_SUCCESS,
                    payload: [project]
                });
                return true;
            });
    }
}
