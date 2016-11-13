import { RouteListener, RouterEventHub, routerEventHubEvents, RouterNavigate } from "../router";
import { createElement, Storage } from "../utilities";
import { environment } from "../environment";
import { AuthorizedRouteListener } from "../users";
import { projectActions, ProjectDeleteSelect, ProjectEditSelect} from "./actions";

export class ProjectEditRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("project-edit");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "project-edit") {
            return createElement(`<ce-project-edit project-id='${options.routeParams.id}'></ce-project-edit>`);
        }
        return null;
    }
}

export class ProjectCreateRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("project-create");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "project-create") {
            return createElement("<ce-project-edit></ce-project-edit>");
        }
        return null;
    }
}

export class ProjectListRouteListener extends AuthorizedRouteListener {
    constructor(private _routerEventHub: RouterEventHub = RouterEventHub.Instance) {
        super("project-list");
    }

    public beforeViewTransition(options: RouteChangeOptions) {
        if (options.previousRouteName == "project-list") {
            (options.currentView as HTMLElement).removeEventListener(projectActions.SELECT, this.onEditSelect.bind(this));
        }
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "project-list") {
            return createElement("<ce-project-list></ce-project-list>");
        }
        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {
        if (options.nextRouteName == "project-list") {
            (options.currentView as HTMLElement).addEventListener(projectActions.SELECT, this.onEditSelect.bind(this));
        }
    }

    public onEditSelect(e: ProjectEditSelect) {
        this._routerEventHub.dispatch(routerEventHubEvents.NAVIGATE, new RouterNavigate(["project", "edit", e.detail.projectId]));
    }
}
