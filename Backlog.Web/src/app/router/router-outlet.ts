import { RouterMiddleware } from "./router-middleware";
import { Router } from "./router";
import { isArray, camelCaseToSnakeCase, Log } from "../utilities";

export abstract class RouterOutlet {
    constructor(private _nativeHTMLElement: HTMLElement, public _router: Router = Router.Instance) {
        this.connectedCallback();
    }

    public connectedCallback() {
        this._router.addEventListener(this._onRouteChanged.bind(this));       
    }

    public use(middleware: RouterMiddleware) {
        this._middleware.push(middleware as RouterMiddleware);
    }

    private _middleware: Array<RouterMiddleware> = [];

    @Log()
    public _onRouteChanged(options: any) { 
        
        let nextView: HTMLElement = null;
        
        const listenerOptions = {
            currentView: this._currentView,
            nextRouteName: options.routeName,
            previousRouteName: this._routeName,
            routeParams: options.routeParams,
            cancelled: false,
            authRequired: options.authRequired
        };
        
        this._middleware.forEach(m => m.beforeViewTransition(listenerOptions));

        if (listenerOptions.cancelled)
            return;


        for (let i = 0; i < this._middleware.length; i++) {
            nextView = this._middleware[i].onViewTransition(listenerOptions);
            if (nextView) {
                this._currentView = nextView;
                i = this._middleware.length + 1;
            }
        }

        if (!nextView) {
            nextView = document.createElement(`ce-${options.routeName}`);

            if (nextView) {
                for (var prop in options.routeParams) {
                    nextView.setAttribute(camelCaseToSnakeCase(prop), options.routeParams[prop]);
                }
                this._currentView = nextView;
            }
        }

        if (this._nativeHTMLElement.children.length > 0)
            this._nativeHTMLElement.removeChild(this._nativeHTMLElement.firstChild);

        this._nativeHTMLElement.appendChild(this._currentView);

        listenerOptions.currentView = this._currentView;

        this._middleware.forEach(listener => listener.afterViewTransition(listenerOptions));    

        window.scrollTo(0,0);
    }

    private _currentView: HTMLElement;
    private _routeName: string;

}