import { Action } from "@ngrx/store";
import { CONTENT_ADD_SUCCESS, CONTENT_GET_SUCCESS, CONTENT_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Content } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const contentsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case CONTENT_ADD_SUCCESS:
            var entities: Array<Content> = state.contents;
            var entity: Content = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { contents: entities });

        case CONTENT_GET_SUCCESS:            
            var entities: Array<Content> = state.contents;
            var newOrExistingContents: Array<Content> = action.payload;
            for (let i = 0; i < newOrExistingContents.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingContents[i], key:"type" });
            }      
            return Object.assign({}, state, { contents: entities });

        case CONTENT_REMOVE_SUCCESS:
            var entities: Array<Content> = state.contents;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { contents: entities });

        default:
            return state;
    }
}

