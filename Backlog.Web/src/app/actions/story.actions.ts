import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { StoryService } from "../services";
import { AppState, AppStore } from "../store";
import { STORY_ADD_SUCCESS, STORY_GET_SUCCESS, STORY_REMOVE_SUCCESS } from "../constants";
import { Story } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class StoryActions {
    constructor(private _storyService: StoryService, private _store: AppStore) { }

    public add(story: Story) {
        const newGuid = guid();
        this._storyService.add(story)
            .subscribe(book => {
                this._store.dispatch({
                    type: STORY_ADD_SUCCESS,
                    payload: story
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._storyService.get()
            .subscribe(storys => {
                this._store.dispatch({
                    type: STORY_GET_SUCCESS,
                    payload: storys
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._storyService.remove({ id: options.id })
            .subscribe(story => {
                this._store.dispatch({
                    type: STORY_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._storyService.getById({ id: options.id })
            .subscribe(story => {
                this._store.dispatch({
                    type: STORY_GET_SUCCESS,
                    payload: [story]
                });
                return true;
            });
    }
}
