import { Action } from "@ngrx/store";
import { STORY_ADD_SUCCESS, STORY_GET_SUCCESS, STORY_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Story } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const storiesReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case STORY_ADD_SUCCESS:
            var entities: Array<Story> = state.stories;
            var entity: Story = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { storys: entities });

        case STORY_GET_SUCCESS:
            var entities: Array<Story> = state.stories;
            var newOrExistingStories: Array<Story> = action.payload;
            for (let i = 0; i < newOrExistingStories.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingStories[i] });
            }                                    
            return Object.assign({}, state, { storys: entities });

        case STORY_REMOVE_SUCCESS:
            var entities: Array<Story> = state.stories;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { storys: entities });

        default:
            return state;
    }
}

