import { Router, RouterOutlet } from "./router";
import { LandingRouteListener } from "./landing";
import { LoginRouteListener } from "./users";
import { EpicListRouteListener, EpicViewRouteListener, EpicEditRouteListener, EpicCreateRouteListener } from "./epics";
import { FeedbackCreateRouteListener } from "./feedback";
import { StoryEditRouteListener, StoryCreateRouteListener } from "./stories";
import { ProductListRouteListener } from "./products";

export class AppRouterOuletComponent extends RouterOutlet {
    constructor() {
        super();
    }

    connectedCallback() { 
        this._router.setRoutes([
            { path: "/", name: "epic-list" },
            { path: "/login", name: "login" },

            { path: "/epic/list", name: "epic-list" },
            { path: "/product/:productId/epic/list", name: "epic-list" },
            { path: "/epic/view/:id", name: "epic-view" },
            { path: "/epic/edit/:id", name: "epic-edit" },
            { path: "/epic/create", name: "epic-create" },

            { path: "/epic/:epicId/story/edit/:id", name: "story-edit" },
            { path: "/epic/:epicId/story/create", name: "story-create" },

            { path: "/product/list", name: "product-list" },

            { path: "/feedback/create", name: "feedback-create" }            
        ] as any);
           
        this.use(new LoginRouteListener());
        this.use(new EpicListRouteListener());
        this.use(new EpicViewRouteListener());
        this.use(new EpicCreateRouteListener());
        this.use(new EpicEditRouteListener());
        this.use(new StoryCreateRouteListener());
        this.use(new StoryEditRouteListener());
        this.use(new FeedbackCreateRouteListener());
        this.use(new ProductListRouteListener());

        super.connectedCallback();
    }

}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-app-router-oulet`,AppRouterOuletComponent));
