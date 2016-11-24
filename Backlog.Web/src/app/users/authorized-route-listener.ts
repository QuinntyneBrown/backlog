import { RouterMiddleware, Router } from "../router";
import { createElement, Storage, TOKEN_KEY, Log } from "../utilities";
import { environment } from "../environment";
import { LoginRedirect } from "./login-redirect";
import { UserService } from "./user.service";

export class AuthorizedRouteMiddleware extends RouterMiddleware {
    constructor(private _routeName = null,
        private _router: Router = Router.Instance,
        private _loginRedirect: LoginRedirect = LoginRedirect.Instance,
        private _storage: Storage = Storage.Instance,
        private _userService: UserService = UserService.Instance
    ) {
        super();

    }

    public beforeViewTransition(options: RouteChangeOptions) {     
        
        if (options.authRequired && !this._storage.get({ name: TOKEN_KEY })) {                      
            this._loginRedirect.setLastPath(window.location.pathname);
            options.cancelled = true;
            this._router.navigate(["login"]);                        
        }

        if (options.authRequired)
            this._userService.getCurrentUser().then((results) => {
                if (results == "") {
                    this._storage.put({ name: TOKEN_KEY, value: null });
                    this._router.navigate(["login"]);
                }
            });
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {

    }

}