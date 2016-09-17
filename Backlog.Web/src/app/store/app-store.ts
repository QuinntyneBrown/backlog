import { Injectable } from "@angular/core";
import { Store, Action } from "@ngrx/store";
import { AppState } from "./app-state";
import { guid, pluck } from "../utilities";
import { select, SelectSignature } from '@ngrx/core/operator/select';
import { Observable, BehaviorSubject } from "rxjs";
import { Epic, Story, Content } from "../models";


@Injectable()
export class AppStore {
    constructor(private _store: Store<AppState>) { }

    public dispatch(action: Action, newGuid?: string): string {
        newGuid = this._registerLastAction(action.type, newGuid);
        this._store.dispatch(action);
        return newGuid;
    }

    private _registerLastAction(actionType: string, newGuid?: string): string {
        newGuid = newGuid || guid();
        this.lastTriggeredAction = actionType;
        this.lastTriggeredActionId = newGuid;
        this.lastTriggeredAction$.next(this.lastTriggeredAction);        
        this.lastTriggeredActionId$.next(this.lastTriggeredActionId);
        return newGuid;
    }

    select: SelectSignature<AppState> = select.bind(this._store);

    public lastTriggeredAction$: BehaviorSubject<string> = new BehaviorSubject<string>(this.lastTriggeredAction);

    public lastTriggeredActionId$: BehaviorSubject<string> = new BehaviorSubject<string>(this.lastTriggeredActionId);

    public lastTriggeredAction: string = null;

    public lastTriggeredActionId: string = null;    

    public getState(): AppState {
        let state: AppState;
        this._store.take(1).subscribe(s => state = s);
        return state;
    }

    public get token$(): Observable<string> {
        return this._store.select("token")
            .map((data: { token: string }) => {
                return data.token;
            });
    }

    public get currentUser$(): Observable<string> {
        return this._store.select("currentUser")
            .map((data: { currentUser: any }) => {
                return data.currentUser;
            });
    }

    public contentByType$(type: string): Observable<Content> {        
        return this._store.select("contents")
            .map((data: { contents: Array<Content> }) => {                
                return pluck({ value: type, items: data.contents, key: "contentModelType" }) as Content;
            })
    }

    public epicById$(id: string): Observable<Epic> {
        return this._store.select("epics")
            .map((data: { epics: Array<Epic> }) => {
                return pluck({ value: id, items: data.epics }) as Epic;
            })
    }

    public epics$(): Observable<Array<Epic>> {
        return this._store.select("epics")
            .map((data: { epics: Array<Epic> }) => {             
                return data.epics;
            });
    }

    public storyById$(id: string): Observable<Story> {
        return this._store.select("stories")
            .map((data: { stories: Array<Story> }) => {
                return pluck({ value: id, items: data.stories }) as Story;
            })
    }

    public stories$(): Observable<Array<Story>> {
        return this._store.select("stories")
            .map((data: { stories: Array<Story> }) => {
                data.stories.sort((a: any, b: any) => {
                    if (a.priority < b.priority) { return 1; }
                    return 0;
                }); 
                return data.stories;
            });
    }
}

