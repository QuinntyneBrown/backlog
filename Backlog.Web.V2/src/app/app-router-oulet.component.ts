import { Router, RouterOutlet } from "./router";
import { LandingRouteListener } from "./landing";
import { LoginRouteListener } from "./users";
import { EpicListRouteListener, EpicViewRouteListener, EpicEditRouteListener, EpicCreateRouteListener } from "./epics";
import { StoryEditRouteListener, StoryCreateRouteListener } from "./stories";

export class AppRouterOuletComponent extends RouterOutlet {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() { 
        this._router.setRoutes([
            { path: "/", name: "epic-list" },
            { path: "/login", name: "login" },

            { path: "/epic/list", name: "epic-list" },
            { path: "/epic/view/:id", name: "epic-view" },
            { path: "/epic/edit/:id", name: "epic-edit" },
            { path: "/epic/create", name: "epic-create" },
            { path: "/epic/:epicId/story/edit/:id", name: "story-edit" },
            { path: "/epic/:epicId/story/create", name: "story-create" }
                
        ] as any);
           
        this.use(new LoginRouteListener());
        this.use(new EpicListRouteListener());
        this.use(new EpicViewRouteListener());
        this.use(new EpicCreateRouteListener());
        this.use(new EpicEditRouteListener());
        this.use(new StoryCreateRouteListener());
        this.use(new StoryEditRouteListener());

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
