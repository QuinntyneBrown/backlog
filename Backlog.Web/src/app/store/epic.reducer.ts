import { Action } from "@ngrx/store";
import { EPIC_ADD_SUCCESS, EPIC_GET_SUCCESS, EPIC_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Epic } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const epicsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case EPIC_ADD_SUCCESS:
            var entities: Array<Epic> = state.epics;
            var entity: Epic = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { epics: entities });

        case EPIC_GET_SUCCESS:
            var entities: Array<Epic> = state.epics;
            var newOrExistingEpics: Array<Epic> = action.payload;
            for (let i = 0; i < newOrExistingEpics.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingEpics[i] });
            }                                    
            return Object.assign({}, state, { epics: entities });

        case EPIC_REMOVE_SUCCESS:
            var entities: Array<Epic> = state.epics;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { epics: entities });

        default:
            return state;
    }
}

