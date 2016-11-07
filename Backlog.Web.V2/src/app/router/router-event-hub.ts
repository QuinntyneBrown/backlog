import { RouterNavigate } from "./actions";

export const routerEventHubEvents = {
    NAVIGATE: "[Router Event Hub] Link Click",
    ROUTE_CHANGED : "[Router Event Hub] Route Changed"
}

export class RouterEventHub {  

    constructor() {
        this._callbacksDictionary[routerEventHubEvents.NAVIGATE] = [];
        this._callbacksDictionary[routerEventHubEvents.ROUTE_CHANGED] = [];        
    }
    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new RouterEventHub();
        return this._instance;
    }

    public addEventListener(eventName:string, callback: any) {
        this._callbacksDictionary[eventName].push(callback);        
    }

    public removeEventListener(eventName:string,callback: any) {
        for (var i = 0; i < this._callbacksDictionary[eventName].length; i++) {
            if (callback == this._callbacksDictionary[eventName][i]) {
                this._callbacksDictionary[eventName].splice(i, 1);                
            }
        }
    }

    public dispatch(eventName: string, action: RouterNavigate) {                
        for (var i = 0; i < this._callbacksDictionary[eventName].length; i++) {            
            this._callbacksDictionary[eventName][i](action);
        }
    }

    private _callbacksDictionary: any = {};
    private _lastActionsDictionary: any = {};

}

