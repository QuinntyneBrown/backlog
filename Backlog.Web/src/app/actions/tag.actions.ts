import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { TagService } from "../services";
import { AppState, AppStore } from "../store";
import { TAG_ADD_SUCCESS, TAG_GET_SUCCESS, TAG_REMOVE_SUCCESS } from "../constants";
import { Tag } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class TagActions {
    constructor(private _tagService: TagService, private _store: AppStore) { }

    public add(tag: Tag) {
        const newGuid = guid();
        this._tagService.add(tag)
            .subscribe(tag => {
                this._store.dispatch({
                    type: TAG_ADD_SUCCESS,
                    payload: tag
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._tagService.get()
            .subscribe(tags => {
                this._store.dispatch({
                    type: TAG_GET_SUCCESS,
                    payload: tags
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._tagService.remove({ id: options.id })
            .subscribe(tag => {
                this._store.dispatch({
                    type: TAG_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._tagService.getById({ id: options.id })
            .subscribe(tag => {
                this._store.dispatch({
                    type: TAG_GET_SUCCESS,
                    payload: [tag]
                });
                return true;
            });
    }
}
