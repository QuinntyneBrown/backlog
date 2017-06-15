import { Component, NgModule } from '@angular/core';
var LoginComponent = (function () {
    function LoginComponent() {
    }
    return LoginComponent;
}());
export { LoginComponent };
LoginComponent.decorators = [
    { type: Component, args: [{
                selector: 'ce-login',
                templateUrl: ".\login.component.html"
            },] },
];
/** @nocollapse */
LoginComponent.ctorParameters = function () { return []; };
var LoginModule = (function () {
    function LoginModule() {
    }
    return LoginModule;
}());
export { LoginModule };
LoginModule.decorators = [
    { type: NgModule, args: [{
                declarations: [LoginComponent],
                exports: [LoginComponent]
            },] },
];
/** @nocollapse */
LoginModule.ctorParameters = function () { return []; };
//# sourceMappingURL=login.component.js.map