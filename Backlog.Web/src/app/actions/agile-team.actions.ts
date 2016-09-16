import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { AgileTeamService } from "../services";
import { AppState, AppStore } from "../store";
import { AGILE_TEAM_ADD_SUCCESS, AGILE_TEAM_GET_SUCCESS, AGILE_TEAM_REMOVE_SUCCESS } from "../constants";
import { AgileTeam } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class AgileTeamActions {
    constructor(private _agileTeamService: AgileTeamService, private _store: AppStore) { }

    public add(agileTeam: AgileTeam) {
        const newGuid = guid();
        this._agileTeamService.add(agileTeam)
            .subscribe(agileTeam => {
                this._store.dispatch({
                    type: AGILE_TEAM_ADD_SUCCESS,
                    payload: agileTeam
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._agileTeamService.get()
            .subscribe(agileTeams => {
                this._store.dispatch({
                    type: AGILE_TEAM_GET_SUCCESS,
                    payload: agileTeams
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._agileTeamService.remove({ id: options.id })
            .subscribe(agileTeam => {
                this._store.dispatch({
                    type: AGILE_TEAM_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._agileTeamService.getById({ id: options.id })
            .subscribe(agileTeam => {
                this._store.dispatch({
                    type: AGILE_TEAM_GET_SUCCESS,
                    payload: [agileTeam]
                });
                return true;
            });
    }
}
