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
            .subscribe(story => {
                this._store.dispatch({
                    type: STORY_ADD_SUCCESS,
                    payload: story
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._storyService.get()
            .subscribe(stories => {
                this._store.dispatch({
                    type: STORY_GET_SUCCESS,
                    payload: stories
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

    public incrementPriority(options: { story: Story }) {        
        for (let i = 0; i < this._storiesAscending.length; i++) {
            if (this._storiesAscending[i].priority >= options.story.priority) {
                options.story.priority = this._storiesAscending[i].priority + 1;
                break;
            }
        }

        return this.add(options.story);
    }

    public decrementPriority(options: { story: Story }) {
        for (let i = 0; i < this._storiesDescending.length; i++) {
            if (this._storiesAscending[i].priority >= options.story.priority) {
                options.story.priority = this._storiesAscending[i].priority - 1;
                break;
            }
        }

        return this.add(options.story);
    }

    private get _storiesAscending(): Array<Story> {
        var stories: Array<Story> = [];
        this._store.stories$().take(1).subscribe(x => stories = x);
        stories.sort((a, b) => {
            return a.priority - b.priority;
        });
        return stories;
    }

    private get _storiesDescending(): Array<Story> {
        var stories: Array<Story> = [];
        this._store.stories$().take(1).subscribe(x => stories = x);
        stories.sort((a, b) => {
            return a.priority - b.priority;
        });
        return stories;
    }
}
