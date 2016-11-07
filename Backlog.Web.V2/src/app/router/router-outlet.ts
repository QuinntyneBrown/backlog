import { RouteListener } from "./route-listener";
import { Router } from "./router";
import { isArray } from "../utilities";

export abstract class RouterOutlet extends HTMLElement {
    constructor(public _router: Router = Router.Instance) {
        super();
    }

    public connectedCallback() {
        this._router.addEventListener(this._onRouteChanged.bind(this));       
        this.style.display = "inline-block";
        this.style.position = "relative";
    }

    public use(listener: RouteListener) {
        this._listeners.push(listener as RouteListener);
    }

    private _listeners: Array<RouteListener> = [];

    public _onRouteChanged(options: any) {      
        let nextView: HTMLElement = null;

        const listenerOptions = { currentView: this._currentView, nextRouteName: options.routeName, previousRouteName: this._routeName, routeParams: options.routeParams, cancelled: false };
        this._listeners.forEach(listener => listener.beforeViewTransition(listenerOptions));

        if (listenerOptions.cancelled)
            return;

        this._listeners.forEach(listener => {
            nextView = listener.onViewTransition(listenerOptions);
            if (nextView)
                this._currentView = nextView;

        });

        // View Transition
        if (this.children.length > 0)
            this.removeChild(this.firstChild);

        this.appendChild(this._currentView);

        listenerOptions.currentView = this._currentView;

        this._listeners.forEach(listener => listener.afterViewTransition(listenerOptions));    
    }

    private _currentView: HTMLElement;
    private _routeName: string;

}