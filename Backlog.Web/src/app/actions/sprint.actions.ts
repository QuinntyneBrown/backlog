import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { SprintService } from "../services";
import { AppState, AppStore } from "../store";
import { SPRINT_ADD_SUCCESS, SPRINT_GET_SUCCESS, SPRINT_REMOVE_SUCCESS } from "../constants";
import { Sprint } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class SprintActions {
    constructor(private _sprintService: SprintService, private _store: AppStore) { }

    public add(sprint: Sprint) {
        const newGuid = guid();
        this._sprintService.add(sprint)
            .subscribe(sprint => {
                this._store.dispatch({
                    type: SPRINT_ADD_SUCCESS,
                    payload: sprint
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._sprintService.get()
            .subscribe(sprints => {
                this._store.dispatch({
                    type: SPRINT_GET_SUCCESS,
                    payload: sprints
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._sprintService.remove({ id: options.id })
            .subscribe(sprint => {
                this._store.dispatch({
                    type: SPRINT_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._sprintService.getById({ id: options.id })
            .subscribe(sprint => {
                this._store.dispatch({
                    type: SPRINT_GET_SUCCESS,
                    payload: [sprint]
                });
                return true;
            });
    }
}
