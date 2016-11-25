import { Storage, isNumeric, Log } from "../utilities";
import { Route } from "./route";
import { environment } from "../environment";

export const routerKeys = {
    currentRoute: "[Router] current route"
}

export class Router {
    constructor(
        private _routes: Array<Route>=[],
        private _storage: Storage = Storage.Instance,        
        private _environment: { useUrlRouting: boolean } = environment
    ) { }

    private static _instance;

    public static get Instance(): Router {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public setRoutes(routes: Array<Route>) {
        this._routes = routes;
        this._addEventListeners();
        this.onChanged({ route: this._initialRoute });
    }

    @Log()
    public onChanged(state: { route?: string, routeSegments?: Array<any> }) { 
        let routeParams = {};        
        let match = false;
        if (state.routeSegments)
            state.route = "/" + state.routeSegments.join("/");

        for (var i = 0; i < this._routes.length; i++) {
            if (state.route == this._routes[i].path) {
                this.onRouteMatch(this._routes[i].name);
                match = true;
            }
        }                

        if (!match) {            
            const _currentSegments = state.route.substring(1).split("/");
            for (let i = 0; i < this._routes.length; i++) {
                
                const segments = this._routes[i].path.substring(1).split("/");

                if (_currentSegments.length === segments.length) {
     
                    for (var x = 0; x < segments.length; x++) {
                        if (_currentSegments[x] == segments[x]) {
                            match = true;
                        } else if (segments[x].charAt(0) == ":") {
                            match = true;
                            routeParams[segments[x].substring(1)] = _currentSegments[x];
                        } else {
                            match = false;
                            x = segments.length;
                        }
                    }

                    if (match)
                        this.onRouteMatch(this._routes[i].name, routeParams);                                            
                }
            }
        }

        if(this._environment.useUrlRouting)
            history.pushState({}, this.routeName, state.route);

        this._storage.put({ name: routerKeys.currentRoute, value: state.route });
        
        this._callbacks.forEach(callback => callback({ routeName: this.routeName, routeParams: this.routeParams, nextRoute: this.activatedRoute }));
        
    }

    public onRouteMatch(name:string,routeParams:any = null) {
        this.routeName = name;
        this.routeParams = routeParams;
    }

    public navigate(routeSegments:Array<any>) {
        this.onChanged({ routeSegments: routeSegments });
    }

    public navigateUrl(path: string) {        
        this.onChanged({ routeSegments: path.slice(1,path.length).split("/") });
    }

    public navigateRoute(route: Route) {

    }

    public _addEventListeners() {
        window.onpopstate = () => this.onChanged({ route: window.location.pathname });   
    }

    public addEventListener(callback: any) {        
        this._callbacks.push(callback);
        if (this.routeName) 
            callback({ routeName: this.routeName, routeParams: this.routeParams, nextRoute: this.activatedRoute });        
    }

    public removeEventListener(callback: any) {
        this._callbacks.splice(this._callbacks.indexOf(callback), 1);
    }

    public get activatedRoute(): ActivatedRoute {
        return Object.assign({}, this._routes.find(r => r.name === this.routeName, { routeParams: this.routeParams })) as ActivatedRoute;
    }
    
    private get _initialRoute(): string { return this._environment.useUrlRouting ? window.location.pathname : this._storage.get({ name: routerKeys.currentRoute }) || "/"; }

    public routeName: string;
    public routePath: string;
    public routeParams;
    private _callbacks: Array<any> = [];
}

