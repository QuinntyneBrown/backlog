import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { AgileTeamMemberService } from "../services";
import { AppState, AppStore } from "../store";
import { AGILE_TEAM_MEMBER_ADD_SUCCESS, AGILE_TEAM_MEMBER_GET_SUCCESS, AGILE_TEAM_MEMBER_REMOVE_SUCCESS } from "../constants";
import { AgileTeamMember } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class AgileTeamMemberActions {
    constructor(private _agileTeamMemberService: AgileTeamMemberService, private _store: AppStore) { }

    public add(agileTeamMember: AgileTeamMember) {
        const newGuid = guid();
        this._agileTeamMemberService.add(agileTeamMember)
            .subscribe(agileTeamMember => {
                this._store.dispatch({
                    type: AGILE_TEAM_MEMBER_ADD_SUCCESS,
                    payload: agileTeamMember
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._agileTeamMemberService.get()
            .subscribe(agileTeamMembers => {
                this._store.dispatch({
                    type: AGILE_TEAM_MEMBER_GET_SUCCESS,
                    payload: agileTeamMembers
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._agileTeamMemberService.remove({ id: options.id })
            .subscribe(agileTeamMember => {
                this._store.dispatch({
                    type: AGILE_TEAM_MEMBER_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._agileTeamMemberService.getById({ id: options.id })
            .subscribe(agileTeamMember => {
                this._store.dispatch({
                    type: AGILE_TEAM_MEMBER_GET_SUCCESS,
                    payload: [agileTeamMember]
                });
                return true;
            });
    }
}
