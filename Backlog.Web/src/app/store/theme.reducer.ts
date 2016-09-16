import { Action } from "@ngrx/store";
import { THEME_ADD_SUCCESS, THEME_GET_SUCCESS, THEME_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Theme } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const themesReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case THEME_ADD_SUCCESS:
            var entities: Array<Theme> = state.themes;
            var entity: Theme = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { themes: entities });

        case THEME_GET_SUCCESS:
            var entities: Array<Theme> = state.themes;
            var newOrExistingThemes: Array<Theme> = action.payload;
            for (let i = 0; i < newOrExistingThemes.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingThemes[i] });
            }                                    
            return Object.assign({}, state, { themes: entities });

        case THEME_REMOVE_SUCCESS:
            var entities: Array<Theme> = state.themes;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { themes: entities });

        default:
            return state;
    }
}

