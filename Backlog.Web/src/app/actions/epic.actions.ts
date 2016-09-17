import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { EpicService } from "../services";
import { AppState, AppStore } from "../store";
import { EPIC_ADD_SUCCESS, EPIC_GET_SUCCESS, EPIC_REMOVE_SUCCESS } from "../constants";
import { Epic } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class EpicActions {
    constructor(private _epicService: EpicService, private _store: AppStore) { }

    public add(epic: Epic) {
        const newGuid = guid();
        this._epicService.add(epic)
            .subscribe((epic:any) => {
                this._store.dispatch({
                    type: EPIC_ADD_SUCCESS,
                    payload: epic
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._epicService.get()
            .subscribe(epics => {
                this._store.dispatch({
                    type: EPIC_GET_SUCCESS,
                    payload: epics
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._epicService.remove({ id: options.id })
            .subscribe(epic => {
                this._store.dispatch({
                    type: EPIC_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._epicService.getById({ id: options.id })
            .subscribe(epic => {
                this._store.dispatch({
                    type: EPIC_GET_SUCCESS,
                    payload: [epic]
                });
                return true;
            });
    }

    public incrementPriority(options: { epic: Epic }) {
        for (let i = 0; i < this._epicsAscending.length; i++) {
            if (this._epicsAscending[i].priority >= options.epic.priority) {
                options.epic.priority = this._epicsAscending[i].priority + 1;                
                break;
            }
        }
        
        return this.add(options.epic);
    }

    public decrementPriority(options: { epic: Epic }) {
        for (let i = 0; i < this._epicsDescending.length; i++) {
            if (this._epicsAscending[i].priority >= options.epic.priority) {
                options.epic.priority = this._epicsAscending[i].priority - 1;
                break;
            }
        }

        return this.add(options.epic);
    }

    private get _epicsAscending(): Array<Epic> {
        var epics: Array<Epic> = [];
        this._store.epics$().take(1).subscribe(x => epics = x);
        epics.sort((a, b) => {
            return a.priority - b.priority;
        });
        return epics;
    }

    private get _epicsDescending(): Array<Epic> {
        var epics: Array<Epic> = [];
        this._store.epics$().take(1).subscribe(x => epics = x);
        epics.sort((a, b) => {
            return a.priority - b.priority;
        });
        return epics;
    }
}
