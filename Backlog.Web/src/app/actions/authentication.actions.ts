import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { AuthenticationService } from "../services";
import { AppState, AppStore } from "../store";
import { USER_LOGGED_IN, USER_LOGGED_OUT, GET_CURRENT_USER_SUCCESS } from "../constants";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class AuthenticationActions {
    constructor(private _authenticationService: AuthenticationService, private _store: AppStore) { }

    public tryToLogin(options: { username:string, password: string}) {
        const newGuid = guid();
        this._authenticationService.tryToLogin(options)
            .subscribe(token => {
                this._store.dispatch({
                    type: USER_LOGGED_IN,
                    payload: token
                }, newGuid);

                this._authenticationService.getCurrentUser()
                    .subscribe(currentUser => {
                        this._store.dispatch({
                            type: GET_CURRENT_USER_SUCCESS,
                            payload: currentUser
                        }, newGuid);
                    });
            });
        return newGuid;
    }

    public logOut() {        
        this._store.dispatch({
            type: USER_LOGGED_OUT,
            payload: null
        });
    }

    public getCurrentUser() {
        const newGuid = guid();
        this._authenticationService.getCurrentUser()
            .subscribe(currentUser => {
                this._store.dispatch({
                    type: GET_CURRENT_USER_SUCCESS,
                    payload: currentUser
                }, newGuid);
            });
        return newGuid;
    }    
}
