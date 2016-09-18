import { Action } from "@ngrx/store";
import {
    STORY_ADD_SUCCESS,
    STORY_GET_SUCCESS,
    STORY_REMOVE_SUCCESS,
    STORY_INCREMENT_PRIORITY_SUCCESS,
    STORY_DECREMENT_PRIORITY_SUCCESS,
    DIGITAL_ASSET_UPLOAD_SUCCESS
} from "../constants";

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

        case STORY_INCREMENT_PRIORITY_SUCCESS:
            return Object.assign({}, state, { stories: action.payload });

        case STORY_DECREMENT_PRIORITY_SUCCESS:
            return Object.assign({}, state, { stories: action.payload });

        case DIGITAL_ASSET_UPLOAD_SUCCESS:
            var entities = state.stories;

            for (let i = 0; i < entities.length; i++) {
                if (entities[i].id == action.payload.id) {
                    for (let j = 0; j < action.payload.files.length; j++) {
                        entities[i].digitalAssets.push(action.payload.files[j]);
                    }
                }
            }
            return Object.assign({}, state, { stories: entities });
        default:
            return state;
    }
}

