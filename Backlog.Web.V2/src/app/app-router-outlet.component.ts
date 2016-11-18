import { Router, RouterOutlet } from "./router";
import { LandingRouteListener } from "./landing";
import { LoginRouteListener } from "./users";
import { ArticleCreateRouteListener, ArticleListRouteListener } from "./articles";
import { EpicListRouteListener, EpicViewRouteListener, EpicEditRouteListener, EpicCreateRouteListener } from "./epics";
import { FeedbackCreateRouteListener, FeedbackReceivedRouteListener } from "./feedback";
import { StoryEditRouteListener, StoryCreateRouteListener } from "./stories";
import { ProductListRouteListener, ProductCreateRouteListener, ProductEditRouteListener } from "./products";

export class AppRouterOutletComponent extends RouterOutlet {
    constructor(nativeHTMLElement: HTMLElement) {
        super(nativeHTMLElement);
    }

    connectedCallback() { 

        this._router.setRoutes([
            { path: "/", name: "epic-list" },
            { path: "/login", name: "login" },

            { path: "/article/list", name: "article-list" },
            { path: "/article/edit/:id", name: "article-edit" },
            { path: "/article/create", name: "article-create" },

            { path: "/epic/list", name: "epic-list" },
            { path: "/product/:productId/epic/list", name: "epic-list" },

            { path: "/epic/view/:id", name: "epic-view" },
            { path: "/epic/edit/:id", name: "epic-edit" },
            { path: "/epic/create", name: "epic-create" },

            { path: "/epic/:epicId/story/edit/:id", name: "story-edit" },
            { path: "/epic/:epicId/story/create", name: "story-create" },

            { path: "/product/list", name: "product-list" },
            { path: "/product/create", name: "product-create" },
            { path: "/product/edit/:id", name: "product-edit" },

            { path: "/feedback/create", name: "feedback-create" },
            { path: "/feedback/received", name: "feedback-received" }            
        ] as any);


        this.use(new ArticleListRouteListener());
        this.use(new ArticleCreateRouteListener());
        this.use(new LoginRouteListener());
        this.use(new EpicListRouteListener());
        this.use(new EpicViewRouteListener());
        this.use(new EpicCreateRouteListener());
        this.use(new EpicEditRouteListener());
        this.use(new StoryCreateRouteListener());
        this.use(new StoryEditRouteListener());
        this.use(new FeedbackCreateRouteListener());
        this.use(new FeedbackReceivedRouteListener());
        this.use(new ProductListRouteListener());
        this.use(new ProductCreateRouteListener());
        this.use(new ProductEditRouteListener());

        super.connectedCallback();
    }

}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-app-router-oulet`,AppRouterOutletComponent));
