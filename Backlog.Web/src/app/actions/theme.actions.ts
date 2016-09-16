import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { ThemeService } from "../services";
import { AppState, AppStore } from "../store";
import { THEME_ADD_SUCCESS, THEME_GET_SUCCESS, THEME_REMOVE_SUCCESS } from "../constants";
import { Theme } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class ThemeActions {
    constructor(private _themeService: ThemeService, private _store: AppStore) { }

    public add(theme: Theme) {
        const newGuid = guid();
        this._themeService.add(theme)
            .subscribe(theme => {
                this._store.dispatch({
                    type: THEME_ADD_SUCCESS,
                    payload: theme
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._themeService.get()
            .subscribe(themes => {
                this._store.dispatch({
                    type: THEME_GET_SUCCESS,
                    payload: themes
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._themeService.remove({ id: options.id })
            .subscribe(theme => {
                this._store.dispatch({
                    type: THEME_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._themeService.getById({ id: options.id })
            .subscribe(theme => {
                this._store.dispatch({
                    type: THEME_GET_SUCCESS,
                    payload: [theme]
                });
                return true;
            });
    }
}
