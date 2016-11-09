import { RouteListener, Route } from "../router";
import { createElement, Store, TOKEN_KEY } from "../utilities";
import { UserLoginSuccess, userActions } from "./actions";
import { environment } from "../environment";
import { LoginRedirect } from "./login-redirect";

export class LoginRouteListener extends RouteListener {
    constructor(private _loginRedirect: LoginRedirect = null, private _store: Store = Store.Instance) {
        super();
        this.onLoginSucess = this.onLoginSucess.bind(this);
        _loginRedirect = _loginRedirect || new LoginRedirect();
    }

    public beforeViewTransition(options: RouteChangeOptions) {
        if (options.previousRouteName == "login") {
            (options.currentView as HTMLElement).removeEventListener(userActions.LOGIN_SUCCESS, (e: UserLoginSuccess) => this.onLoginSucess(e));
        }
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        
        if (options.nextRouteName == "login") {
            this._store.put({ name: TOKEN_KEY, value: null });
            return createElement("<ce-login></ce-login>");
        }

        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {
        if (options.nextRouteName == "login") {
            (options.currentView as HTMLElement).addEventListener(userActions.LOGIN_SUCCESS, (e: UserLoginSuccess) => this.onLoginSucess(e));
        }
    }

    public onLoginSucess = (e: UserLoginSuccess) => { 
        this._store = this._store || new Store.Instance;
        this._loginRedirect = this._loginRedirect || new LoginRedirect();               
        this._store.put({ name: TOKEN_KEY, value: e.detail.accessToken });
        this._loginRedirect.redirectPreLogin();
    }
}