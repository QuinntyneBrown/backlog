import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { ContentService } from "../services";
import { AppState, AppStore } from "../store";
import { CONTENT_ADD_SUCCESS, CONTENT_GET_SUCCESS, CONTENT_REMOVE_SUCCESS } from "../constants";
import { Content } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class ContentActions {
    constructor(private _contentService: ContentService, private _store: AppStore) { }

    public add(content: Content) {
        const newGuid = guid();
        this._contentService.add(content)
            .subscribe(book => {
                this._store.dispatch({
                    type: CONTENT_ADD_SUCCESS,
                    payload: content
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._contentService.get()
            .subscribe(contents => {
                this._store.dispatch({
                    type: CONTENT_GET_SUCCESS,
                    payload: contents
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._contentService.remove({ id: options.id })
            .subscribe(content => {
                this._store.dispatch({
                    type: CONTENT_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._contentService.getById({ id: options.id })
            .subscribe(content => {
                this._store.dispatch({
                    type: CONTENT_GET_SUCCESS,
                    payload: [content]
                });
                return true;
            });
    }

    public getByType(options: { type: string }) {
        return this._contentService.getByType({ type: options.type })
            .subscribe(content => {                
                this._store.dispatch({
                    type: CONTENT_GET_SUCCESS,
                    payload: [content]
                });
                return true;
            });
    }
}
