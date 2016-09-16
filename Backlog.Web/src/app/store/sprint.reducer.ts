import { Action } from "@ngrx/store";
import { SPRINT_ADD_SUCCESS, SPRINT_GET_SUCCESS, SPRINT_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Sprint } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const sprintsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case SPRINT_ADD_SUCCESS:
            var entities: Array<Sprint> = state.sprints;
            var entity: Sprint = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { sprints: entities });

        case SPRINT_GET_SUCCESS:
            var entities: Array<Sprint> = state.sprints;
            var newOrExistingSprints: Array<Sprint> = action.payload;
            for (let i = 0; i < newOrExistingSprints.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingSprints[i] });
            }                                    
            return Object.assign({}, state, { sprints: entities });

        case SPRINT_REMOVE_SUCCESS:
            var entities: Array<Sprint> = state.sprints;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { sprints: entities });

        default:
            return state;
    }
}

