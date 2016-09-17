import { Action } from "@ngrx/store";
import { HTML_CONTENT_ADD_SUCCESS, HTML_CONTENT_GET_SUCCESS, HTML_CONTENT_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { HtmlContent } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const htmlContentsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case HTML_CONTENT_ADD_SUCCESS:
            var entities: Array<HtmlContent> = state.htmlContents;
            var entity: HtmlContent = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { htmlContents: entities });

        case HTML_CONTENT_GET_SUCCESS:
            var entities: Array<HtmlContent> = state.htmlContents;
            var newOrExistingHtmlContents: Array<HtmlContent> = action.payload;
            for (let i = 0; i < newOrExistingHtmlContents.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingHtmlContents[i] });
            }                                    
            return Object.assign({}, state, { htmlContents: entities });

        case HTML_CONTENT_REMOVE_SUCCESS:
            var entities: Array<HtmlContent> = state.htmlContents;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { htmlContents: entities });

        default:
            return state;
    }
}

