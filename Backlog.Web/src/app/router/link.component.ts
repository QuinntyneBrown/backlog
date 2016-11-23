import { routerActions, RouterNavigate } from "./actions";
import { RouterEventHub, routerEventHubEvents } from "./router-event-hub";

export class LinkComponent extends HTMLElement {
    constructor(private _routerEventHub:RouterEventHub = RouterEventHub.Instance) {
        super();
    }

    static get observedAttributes() {
        return [
            "routesegments",         
            "route-name"   
        ];
    }

    connectedCallback() {
        this.addEventListener("click", this.onClick.bind(this));
        this._routerEventHub.addEventListener(routerEventHubEvents.ROUTE_CHANGED, this.onRouterHubEvent.bind(this));
        this.style.cursor = "pointer";
    }

    onClick(e: Event) {        
        this._routerEventHub.dispatch(routerEventHubEvents.NAVIGATE,new RouterNavigate(this.routeSegments));
    }

    disconnectedCallback() {
        this._routerEventHub.removeEventListener(routerEventHubEvents.NAVIGATE,this.onRouterHubEvent.bind(this));
    }

    attributeChangedCallback(name, oldValue, newValue) {

        switch (name) {
            case "active-path":
                (this as any).classList.remove("active");
                if (this.route == newValue)
                    (this as any).classList.add("active");

                break;
            case "routesegments":
                if (newValue)
                    this.routeSegments = JSON.parse(newValue);
                break;
            case "route-name":
                this._routeName = newValue;
                break;
        }
    }

    public onRouterHubEvent(e: any) {        
        (this as any).classList.remove("active");        
        if (this._routeName == e.detail.options.routeName)
            (this as any).classList.add("active");
    }

    public routeSegments: Array<any>;
    private _routeName: string;
    public get route() {
        if (!this.routeSegments)
            return "";
        return "/" + this.routeSegments.join("/");
    }

}

document.addEventListener("DOMContentLoaded", () => (window as any).customElements.define(`ce-link`, LinkComponent));
