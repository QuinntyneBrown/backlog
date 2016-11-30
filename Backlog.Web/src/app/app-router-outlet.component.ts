import { RouterOutlet } from "./router";
import { AuthorizedRouteMiddleware } from "./users";

export class AppRouterOutletComponent extends RouterOutlet {
    constructor(el: HTMLElement) {
        super(el);
    }

    connectedCallback() { 
        this.setRoutes([
            { path: "/", name: "epic-list", authRequired: true },
            { path: "/login", name: "login" },

            { path: "/article/list", name: "article-list", authRequired: true },
            { path: "/article/edit/:articleId", name: "article-edit", authRequired: true },
            { path: "/article/create", name: "article-edit", authRequired: true },
            { path: "/article/:slug", name: "article-view", authRequired: true },

            { path: "/epic/list", name: "epic-list", authRequired: true },
            { path: "/product/:productId/epic/list", name: "epic-list", authRequired: true },

            { path: "/epic/view/:epicId", name: "epic-view", authRequired: true },
            { path: "/epic/edit/:epicId", name: "epic-edit", authRequired: true },
            { path: "/epic/create", name: "epic-edit", authRequired: true },

            { path: "/epic/:epicId/story/edit/:storyId", name: "story-edit", authRequired: true },
            { path: "/epic/:epicId/story/create", name: "story-edit", authRequired: true },

            { path: "/product/list", name: "product-list", authRequired: true },
            { path: "/product/create", name: "product-edit", authRequired: true },
            { path: "/product/edit/:productId", name: "product-edit", authRequired: true },

            { path: "/task/list", name: "task-list", authRequired: true },
            { path: "/task/create", name: "task-edit", authRequired: true },
            { path: "/task/edit/:taskId", name: "task-edit", authRequired: true },

            { path: "/feedback/create", name: "feedback-edit", authRequired: true },
            { path: "/feedback/received", name: "feedback-received", authRequired: true },

            { path: "/register", name: "register" },

            { path: "/settings", name: "settings", authRequired: true }            
        ] as any);

        this.use(new AuthorizedRouteMiddleware());

        super.connectedCallback();
    }

}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-app-router-oulet`,AppRouterOutletComponent));
