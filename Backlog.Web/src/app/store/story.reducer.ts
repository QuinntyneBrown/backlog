import { Action } from "@ngrx/store";
import { STORY_ADD_SUCCESS, STORY_GET_SUCCESS, STORY_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Story, Epic } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const storiesReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case STORY_ADD_SUCCESS:
            var entities: Array<Story> = state.stories;
            var entity: Story = action.payload;
            var epics: Array<Epic> = state.epics;
            var newEpics: Array<Epic> = [];
            addOrUpdate({ items: entities, item: entity });               
            return Object.assign({}, state, { stories: entities, epics: [] });

        case STORY_GET_SUCCESS:
            var entities: Array<Story> = state.stories;
            var epics: Array<Epic> = state.epics;

            var newOrExistingStories: Array<Story> = action.payload;
            for (let i = 0; i < newOrExistingStories.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingStories[i] });
            }                                    
            return Object.assign({}, state, { stories: entities, epics: epics });

        case STORY_REMOVE_SUCCESS:
            var entities: Array<Story> = state.stories;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { stories: entities });

        default:
            return state;
    }
}

