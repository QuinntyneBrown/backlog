import { Action } from "@ngrx/store";
import { PROJECT_ADD_SUCCESS, PROJECT_GET_SUCCESS, PROJECT_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Project } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const projectsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case PROJECT_ADD_SUCCESS:
            var entities: Array<Project> = state.projects;
            var entity: Project = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { projects: entities });

        case PROJECT_GET_SUCCESS:
            var entities: Array<Project> = state.projects;
            var newOrExistingProjects: Array<Project> = action.payload;
            for (let i = 0; i < newOrExistingProjects.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingProjects[i] });
            }                                    
            return Object.assign({}, state, { projects: entities });

        case PROJECT_REMOVE_SUCCESS:
            var entities: Array<Project> = state.projects;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { projects: entities });

        default:
            return state;
    }
}

