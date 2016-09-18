import { Action } from "@ngrx/store";
import {
    EPIC_ADD_SUCCESS,
    EPIC_GET_SUCCESS,
    EPIC_REMOVE_SUCCESS,
    STORY_ADD_SUCCESS,
    STORY_REMOVE_SUCCESS,
    EPIC_INCREMENT_PRIORITY_SUCCESS,
    EPIC_DECREMENT_PRIORITY_SUCCESS,
    STORY_INCREMENT_PRIORITY_SUCCESS,
    STORY_DECREMENT_PRIORITY_SUCCESS
} from "../constants";

import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Epic } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const epicsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case EPIC_ADD_SUCCESS:
            var entities: Array<Epic> = state.epics;
            var entity: Epic = action.payload;
            addOrUpdate({ items: entities, item: entity });            
            return Object.assign({}, state, { epics: entities });

        case EPIC_GET_SUCCESS:            
            var entities: Array<Epic> = state.epics;
            var newOrExistingEpics: Array<Epic> = action.payload;
            for (let i = 0; i < newOrExistingEpics.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingEpics[i] });
            }
            return Object.assign({}, state, { epics: entities });

        case EPIC_INCREMENT_PRIORITY_SUCCESS:
            return Object.assign({}, state, { epics: action.payload });

        case EPIC_DECREMENT_PRIORITY_SUCCESS:
            return Object.assign({}, state, { epics: action.payload });

        case STORY_INCREMENT_PRIORITY_SUCCESS:
        case STORY_DECREMENT_PRIORITY_SUCCESS:
            var entities: Array<Epic> = state.epics;

            for (let i = 0; i < entities.length; i++) {
                var stories = [];
                for (let j = 0; j < action.payload.length; j++) {
                    if (entities[i].id === action.payload[j].epicId) {
                        stories.push(action.payload[j]);
                    }
                }
                entities[i].stories = stories;
            }            
            return Object.assign({}, state, { epics: entities });
            
        case EPIC_REMOVE_SUCCESS:
            var entities: Array<Epic> = state.epics;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { epics: entities });

        case STORY_REMOVE_SUCCESS:
            var entities: Array<Epic> = state.epics;            
            for (let i = 0; i < entities.length; i++) {

                for (let j = 0; j < entities[i].stories.length; j++) {
                    if (entities[i].stories[j].id == action.payload) {
                        pluckOut({ items: entities[i].stories, value: action.payload });
                    }
                }
            }
            return Object.assign({}, state, { epics: entities });

        default:
            return state;
    }
}

