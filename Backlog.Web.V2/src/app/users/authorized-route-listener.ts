import { RouteListener, Router } from "../router";
import { createElement, Store, TOKEN_KEY } from "../utilities";
import { UserLoginSuccess, userActions } from "./actions";
import { environment } from "../environment";
import { LoginRedirect } from "./login-redirect";

export abstract class AuthorizedRouteListener extends RouteListener {
    constructor(private _routeName,
        private _router: Router = Router.Instance,
        private _loginRedirect: LoginRedirect = new LoginRedirect(),
        private _store: Store = Store.Instance) {
        super();

    }

    public beforeViewTransition(options: RouteChangeOptions) {       
        if (options.nextRouteName == this._routeName && !this._store.get({ name: TOKEN_KEY })) {
            this._loginRedirect.setLastPath(options.nextRouteName);
            options.cancelled = true;
            this._router.navigate(["login"]);                        
        }
    }

    public afterViewTransition(options: RouteChangeOptions) {

    }

}