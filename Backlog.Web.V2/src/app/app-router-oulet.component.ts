import { Router, RouterOutlet } from "./router";
import { LandingRouteListener } from "./landing";
import { LoginRouteListener } from "./users";

export class AppRouterOuletComponent extends RouterOutlet {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() { 
        this._router.setRoutes([
            { path: "/", name: "landing" },
            { path: "/login", name: "login" }
        ] as any);
    
        this.use(new LoginRouteListener());
        this.use(new LandingRouteListener());

        super.connectedCallback();
    }

    disconnectedCallback() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-app-router-oulet`,AppRouterOuletComponent));
