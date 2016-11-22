import { RouteListener, RouterEventHub, routerEventHubEvents, RouterNavigate } from "../router";
import { createElement, Storage } from "../utilities";
import { environment } from "../environment";
import { AuthorizedRouteListener } from "../users";
import { storyActions, StoryDeleteSelect, StoryEditSelect} from "./actions";

export class StoryEditRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("story-edit");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "story-edit") {
            return createElement(`<ce-story-edit epic-id='${options.routeParams.epicId}' story-id='${options.routeParams.id}'></ce-story-edit>`);
        }
        return null;
    }
}

export class StoryCreateRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("story-create");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "story-create") {
            return createElement(`<ce-story-edit epic-id='${options.routeParams.epicId}'></ce-story-edit>`);
        }
        return null;
    }
}

export class StoryListRouteListener extends AuthorizedRouteListener {
    constructor(private _routerEventHub: RouterEventHub = RouterEventHub.Instance) {
        super("story-list");
    }

    public beforeViewTransition(options: RouteChangeOptions) {
        if (options.previousRouteName == "story-list") {
            (options.currentView as HTMLElement).removeEventListener(storyActions.SELECT, this.onEditSelect.bind(this));
        }
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "story-list") {
            return createElement("<ce-story-list></ce-story-list>");
        }
        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {
        if (options.nextRouteName == "story-list") {
            (options.currentView as HTMLElement).addEventListener(storyActions.SELECT, this.onEditSelect.bind(this));
        }
    }

    public onEditSelect(e: StoryEditSelect) {
        this._routerEventHub.dispatch(routerEventHubEvents.NAVIGATE, new RouterNavigate(["story", "edit", e.detail.storyId]));
    }
}
