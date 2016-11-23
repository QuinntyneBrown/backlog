import { Storage, isNumeric, Log } from "../utilities";
import { Route } from "./route";

export class Router {
    constructor(
        private _routes: Array<Route>=[],
        private _storage: Storage = Storage.Instance,
        private initialRoute: string = window.location.pathname
    ) { }

    private static _instance;

    public static get Instance(): Router {
        this._instance = this._instance || new Router();
        return this._instance;
    }

    public setRoutes(routes: Array<Route>) {
        this._routes = routes;
        this._addEventListeners();
        this.onChanged({ route: this.initialRoute });
    }

    @Log()
    public onChanged(state: { route?: string, routeSegments?: Array<any> }) { 
        var routeParams = {};        
        var match = false;
        if (state.routeSegments)
            state.route = "/" + state.routeSegments.join("/");

        for (var i = 0; i < this._routes.length; i++) {
            if (state.route == this._routes[i].path) {
                this.routeName = this._routes[i].name;
                this.routePath = this._routes[i].path;
                this.authRequired = this._routes[i].authRequired;
                match = true;
            }
        }                

        if (!match) {            
            const _currentSegments = state.route.substring(1).split("/");
            for (var i = 0; i < this._routes.length; i++) {
                
                var segments = this._routes[i].path.substring(1).split("/");

                if (_currentSegments.length === segments.length) {
     
                    for (var x = 0; x < segments.length; x++) {
                        if (_currentSegments[x] == segments[x]) {
                            match = true;
                        } else if (segments[x].charAt(0) == ":") {
                            match = true;
                            routeParams[segments[x].substring(1)] = _currentSegments[x];
                        } else {
                            match = false;
                            //exit for
                            x = segments.length;
                        }
                    }

                    if (match) {
                        this.routeParams = routeParams;
                        this.routeName = this._routes[i].name;
                        this.routePath = this._routes[i].path;
                        this.authRequired = this._routes[i].authRequired;
                    }

                }
            }
        }
        
        history.pushState({}, this.routeName, state.route);
        
        this._callbacks.forEach(callback => callback({ routeName: this.routeName, routeParams: this.routeParams, authRequired: this.authRequired }));

        
    }

    authRequired: boolean = false;

    public navigate(routeSegments:Array<any>) {
        this.onChanged({ routeSegments: routeSegments });
    }

    public navigateUrl(path: string) {
        this.onChanged({ routeSegments: path.split("/") });
    }


    public _addEventListeners() {
        window.onpopstate = () => this.onChanged({ route: window.location.pathname });   
    }

    public addEventListener(callback: any) {        
        this._callbacks.push(callback);
        if (this.routeName) {
            callback({ routeName: this.routeName, routeParams: this.routeParams, authRequired: this.authRequired });
        }
    }

    public removeEventListener(callback: any) {
        this._callbacks.splice(this._callbacks.indexOf(callback), 1);
    }

    public routeName: string;
    public routePath: string;
    public routeParams;
    private _callbacks: Array<any> = [];
    private _loginRedirect;
    private _rootAsHTML;
    private _location: string;
}

