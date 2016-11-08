import { Store, isNumeric } from "../utilities";
import { Route } from "./route";
import { RouterNavigate, RouteChanged } from "./actions";
import { RouterEventHub, routerEventHubEvents } from "./router-event-hub";

export class Router {
    constructor(
        private _routes: Array<Route>=[],
        private _store: Store = Store.Instance,
        private initialRoute: string = window.location.pathname,
        private _routerEventHub: RouterEventHub = RouterEventHub.Instance
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

    public onChanged(state: { route?: string, routeSegments?: Array<any> }) { 
        var routeParams = {};
        
        var match = false;
        if (state.routeSegments)
            state.route = "/" + state.routeSegments.join("/");

        for (var i = 0; i < this._routes.length; i++) {
            if (state.route == this._routes[i].path) {
                this._routeName = this._routes[i].name;
                this.routePath = this._routes[i].path;
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
                        } else if (segments[x].charAt(0) == ":" && isNumeric(_currentSegments[x])) {
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
                        this._routeName = this._routes[i].name;
                        this.routePath = this._routes[i].path;
                    }

                }
            }
        }
        
        history.pushState({}, this._routeName, state.route);
        this._routerEventHub.dispatch(routerEventHubEvents.ROUTE_CHANGED, new RouteChanged({ routeName: this._routeName, routeParams: this.routeParams }));
        
        this._callbacks.forEach(callback => callback({ routeName: this._routeName, routeParams: this.routeParams }));

        
    }

    public navigate(routeSegments:Array<any>) {
        this.onChanged({ routeSegments: routeSegments });
    }

    public navigateUrl(path: string) {
        this.onChanged({ routeSegments: path.split("/") });
    }


    public _addEventListeners() {
        window.onpopstate = () => this.onChanged({ route: window.location.pathname }); 
        this._routerEventHub.addEventListener(routerEventHubEvents.NAVIGATE, (e: RouterNavigate) => {            
                this.onChanged({ routeSegments: e.detail.routeSegments })
        });   
    }

    public addEventListener(callback: any) {        
        this._callbacks.push(callback);
        if (this._routeName) {
            callback({ routeName: this._routeName, routeParams: this.routeParams });
        }
    }

    private _routeName: string;
    public routePath: string;
    public routeParams;
    private _callbacks: Array<any> = [];
    private _loginRedirect;
    private _rootAsHTML;
    private _location: string;
}

