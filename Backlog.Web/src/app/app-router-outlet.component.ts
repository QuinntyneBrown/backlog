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

            { path: "/brand/list", name: "brand-list", authRequired: true },
            { path: "/brand/create", name: "brand-edit", authRequired: true },
            { path: "/brand/edit/:brandId", name: "brand-edit", authRequired: true },

            { path: "/feature/list", name: "feature-list", authRequired: true },
            { path: "/feature/create", name: "feature-edit", authRequired: true },
            { path: "/feature/edit/:featureId", name: "feature-edit", authRequired: true },

            { path: "/task/list", name: "task-list", authRequired: true },
            { path: "/task/create", name: "task-edit", authRequired: true },
            { path: "/task/edit/:taskId", name: "task-edit", authRequired: true },

            { path: "/template/list", name: "template-list", authRequired: true },
            { path: "/template/create", name: "template-edit", authRequired: true },
            { path: "/template/edit/:templateId", name: "template-edit", authRequired: true },

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

            { path: "/sprint/list", name: "sprint-list", authRequired: true },
            { path: "/sprint/create", name: "sprint-edit", authRequired: true },
            { path: "/sprint/edit/:sprintId", name: "sprint-edit", authRequired: true },

            { path: "/kanban-board", name: "kanban-board", authRequired: true },

            { path: "/task/list", name: "task-list", authRequired: true },
            { path: "/task/create", name: "task-edit", authRequired: true },
            { path: "/task/edit/:taskId", name: "task-edit", authRequired: true },

            { path: "/feedback/create", name: "feedback-edit", authRequired: true },
            { path: "/feedback/received", name: "feedback-received", authRequired: true },

            { path: "/register", name: "register" },

            { path: "/user-settings", name: "user-settings", authRequired: true },

            { path: "/error", name: "error" },
            { path: "*", name: "not-found" }
                        
        ] as any);

        this.use(new AuthorizedRouteMiddleware());

        super.connectedCallback();
    }

}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-app-router-oulet`,AppRouterOutletComponent));
