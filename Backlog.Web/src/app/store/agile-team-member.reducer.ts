import { Action } from "@ngrx/store";
import { AGILE_TEAM_MEMBER_ADD_SUCCESS, AGILE_TEAM_MEMBER_GET_SUCCESS, AGILE_TEAM_MEMBER_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { AgileTeamMember } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const agileTeamMembersReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case AGILE_TEAM_MEMBER_ADD_SUCCESS:
            var entities: Array<AgileTeamMember> = state.agileTeamMembers;
            var entity: AgileTeamMember = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { agileTeamMembers: entities });

        case AGILE_TEAM_MEMBER_GET_SUCCESS:
            var entities: Array<AgileTeamMember> = state.agileTeamMembers;
            var newOrExistingAgileTeamMembers: Array<AgileTeamMember> = action.payload;
            for (let i = 0; i < newOrExistingAgileTeamMembers.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingAgileTeamMembers[i] });
            }                                    
            return Object.assign({}, state, { agileTeamMembers: entities });

        case AGILE_TEAM_MEMBER_REMOVE_SUCCESS:
            var entities: Array<AgileTeamMember> = state.agileTeamMembers;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { agileTeamMembers: entities });

        default:
            return state;
    }
}

