import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { ReusableStoryGroupService } from "../services";
import { AppState, AppStore } from "../store";
import { REUSABLE_STORY_GROUP_ADD_SUCCESS, REUSABLE_STORY_GROUP_GET_SUCCESS, REUSABLE_STORY_GROUP_REMOVE_SUCCESS } from "../constants";
import { ReusableStoryGroup } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class ReusableStoryGroupActions {
    constructor(private _reusableStoryGroupService: ReusableStoryGroupService, private _store: AppStore) { }

    public add(reusableStoryGroup: ReusableStoryGroup) {
        const newGuid = guid();
        this._reusableStoryGroupService.add(reusableStoryGroup)
            .subscribe(reusableStoryGroup => {
                this._store.dispatch({
                    type: REUSABLE_STORY_GROUP_ADD_SUCCESS,
                    payload: reusableStoryGroup
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._reusableStoryGroupService.get()
            .subscribe(reusableStoryGroups => {
                this._store.dispatch({
                    type: REUSABLE_STORY_GROUP_GET_SUCCESS,
                    payload: reusableStoryGroups
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._reusableStoryGroupService.remove({ id: options.id })
            .subscribe(reusableStoryGroup => {
                this._store.dispatch({
                    type: REUSABLE_STORY_GROUP_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._reusableStoryGroupService.getById({ id: options.id })
            .subscribe(reusableStoryGroup => {
                this._store.dispatch({
                    type: REUSABLE_STORY_GROUP_GET_SUCCESS,
                    payload: [reusableStoryGroup]
                });
                return true;
            });
    }
}
