import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { EpicService } from "../services";
import { AppState, AppStore } from "../store";
import { EPIC_ADD_SUCCESS, EPIC_GET_SUCCESS, EPIC_REMOVE_SUCCESS } from "../constants";
import { Epic } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class EpicActions {
    constructor(private _epicService: EpicService, private _store: AppStore) { }

    public add(epic: Epic) {
        const newGuid = guid();
        this._epicService.add(epic)
            .subscribe(epic => {
                this._store.dispatch({
                    type: EPIC_ADD_SUCCESS,
                    payload: epic
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._epicService.get()
            .subscribe(epics => {
                this._store.dispatch({
                    type: EPIC_GET_SUCCESS,
                    payload: epics
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._epicService.remove({ id: options.id })
            .subscribe(epic => {
                this._store.dispatch({
                    type: EPIC_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._epicService.getById({ id: options.id })
            .subscribe(epic => {
                this._store.dispatch({
                    type: EPIC_GET_SUCCESS,
                    payload: [epic]
                });
                return true;
            });
    }
}
