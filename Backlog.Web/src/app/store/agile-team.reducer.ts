import { Action } from "@ngrx/store";
import { AGILE_TEAM_ADD_SUCCESS, AGILE_TEAM_GET_SUCCESS, AGILE_TEAM_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { AgileTeam } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const agileTeamsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case AGILE_TEAM_ADD_SUCCESS:
            var entities: Array<AgileTeam> = state.agileTeams;
            var entity: AgileTeam = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { agileTeams: entities });

        case AGILE_TEAM_GET_SUCCESS:
            var entities: Array<AgileTeam> = state.agileTeams;
            var newOrExistingAgileTeams: Array<AgileTeam> = action.payload;
            for (let i = 0; i < newOrExistingAgileTeams.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingAgileTeams[i] });
            }                                    
            return Object.assign({}, state, { agileTeams: entities });

        case AGILE_TEAM_REMOVE_SUCCESS:
            var entities: Array<AgileTeam> = state.agileTeams;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { agileTeams: entities });

        default:
            return state;
    }
}

