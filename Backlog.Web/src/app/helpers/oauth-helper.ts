import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";
import { AppStore } from "../store";

@Injectable()
export class OAuthHelper {
    constructor(private _store: AppStore) { }

    public get token() {
        let _token = null;
        this._store.token$.take(1).subscribe(token => _token = token);
        return _token;
    }
    public getOAuthHeaders() {        
        let headers = new Headers();        
        headers.append('Authorization', `Bearer ${this.token}`);
        return headers;
    }
}