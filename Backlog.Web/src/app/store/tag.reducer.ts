import { Action } from "@ngrx/store";
import { TAG_ADD_SUCCESS, TAG_GET_SUCCESS, TAG_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Tag } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const tagsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case TAG_ADD_SUCCESS:
            var entities: Array<Tag> = state.tags;
            var entity: Tag = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { tags: entities });

        case TAG_GET_SUCCESS:
            var entities: Array<Tag> = state.tags;
            var newOrExistingTags: Array<Tag> = action.payload;
            for (let i = 0; i < newOrExistingTags.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingTags[i] });
            }                                    
            return Object.assign({}, state, { tags: entities });

        case TAG_REMOVE_SUCCESS:
            var entities: Array<Tag> = state.tags;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { tags: entities });

        default:
            return state;
    }
}

