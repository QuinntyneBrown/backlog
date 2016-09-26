import { Action } from "@ngrx/store";
import { REUSABLE_STORY_GROUP_ADD_SUCCESS, REUSABLE_STORY_GROUP_GET_SUCCESS, REUSABLE_STORY_GROUP_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { ReusableStoryGroup } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const reusableStoryGroupsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case REUSABLE_STORY_GROUP_ADD_SUCCESS:
            var entities: Array<ReusableStoryGroup> = state.reusableStoryGroups;
            var entity: ReusableStoryGroup = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { reusableStoryGroups: entities });

        case REUSABLE_STORY_GROUP_GET_SUCCESS:
            var entities: Array<ReusableStoryGroup> = state.reusableStoryGroups;
            var newOrExistingReusableStoryGroups: Array<ReusableStoryGroup> = action.payload;
            for (let i = 0; i < newOrExistingReusableStoryGroups.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingReusableStoryGroups[i] });
            }                                    
            return Object.assign({}, state, { reusableStoryGroups: entities });

        case REUSABLE_STORY_GROUP_REMOVE_SUCCESS:
            var entities: Array<ReusableStoryGroup> = state.reusableStoryGroups;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { reusableStoryGroups: entities });

        default:
            return state;
    }
}

