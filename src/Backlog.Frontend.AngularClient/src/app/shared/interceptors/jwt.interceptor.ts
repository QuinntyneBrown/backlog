import { Injectable } from "@angular/core";
import { HttpClient, HttpRequest, HttpHandler, HttpEvent, HttpEventType, HttpInterceptor, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Storage } from "../services/storage.service";
import { RedirectService } from "../services/redirect.service";
import { constants } from "../constants";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private _storage: Storage, private _redirectService: RedirectService) { }
    intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(httpRequest).do((httpEvent: HttpEvent<any>) => {
            return httpEvent;
        }, (error) => {
            if (error instanceof HttpErrorResponse && error.status === 401) {
                this._storage.put({ name: constants.ACCESS_TOKEN_KEY, value: null });
                this._redirectService.redirectToLogin();
            }
        });
    }
}
