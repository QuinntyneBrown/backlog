import { Router } from "../router";

export class CurrentUser {
    constructor(private _router:Router = Router.Instance) { }
    
    private static _instance: CurrentUser;

    public static get Instance() {
        this._instance = this._instance || new CurrentUser();
        return this._instance;
    }

    public username:string 
}