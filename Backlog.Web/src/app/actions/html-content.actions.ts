import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { HtmlContentService } from "../services";
import { AppState, AppStore } from "../store";
import { HTML_CONTENT_ADD_SUCCESS, HTML_CONTENT_GET_SUCCESS, HTML_CONTENT_REMOVE_SUCCESS } from "../constants";
import { HtmlContent } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class HtmlContentActions {
    constructor(private _htmlContentService: HtmlContentService, private _store: AppStore) { }

    public add(htmlContent: HtmlContent) {
        const newGuid = guid();
        this._htmlContentService.add(htmlContent)
            .subscribe(htmlContent => {
                this._store.dispatch({
                    type: HTML_CONTENT_ADD_SUCCESS,
                    payload: htmlContent
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._htmlContentService.get()
            .subscribe(htmlContents => {
                this._store.dispatch({
                    type: HTML_CONTENT_GET_SUCCESS,
                    payload: htmlContents
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._htmlContentService.remove({ id: options.id })
            .subscribe(htmlContent => {
                this._store.dispatch({
                    type: HTML_CONTENT_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._htmlContentService.getById({ id: options.id })
            .subscribe(htmlContent => {
                this._store.dispatch({
                    type: HTML_CONTENT_GET_SUCCESS,
                    payload: [htmlContent]
                });
                return true;
            });
    }
}
