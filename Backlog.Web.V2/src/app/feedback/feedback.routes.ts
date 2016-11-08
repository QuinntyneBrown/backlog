import { createElement, Store } from "../utilities";
import { AuthorizedRouteListener } from "../users";


export class FeedbackCreateRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("feedback-create");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "feedback-create") {
            return createElement("<ce-feedback-edit></ce-feedback-edit>");
        }
        return null;
    }
}

export class FeedbackReceivedRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("feedback-received");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "feedback-received") {
            return createElement("<ce-feedback-received></ce-feedback-received>");
        }
        return null;
    }
}
