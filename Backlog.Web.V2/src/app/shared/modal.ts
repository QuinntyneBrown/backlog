import { Backdrop } from "./backdrop";
import {
    appendToTargetAsync,
    extendCssAsync,
    removeElement,
    setOpacityAsync,
    createElement
} from "../utilities";

export class Modal {
    constructor(
        private _backdrop: Backdrop = Backdrop.Instance,
        private _appendToTargetAsync = appendToTargetAsync,
        private _extendCssAsync = extendCssAsync,
        private _removeElement = removeElement,
        private _setOpacityAsync = setOpacityAsync
    ) { }

    _html: string;

    get html() { return this._html; }

    set html(value: string) { this._html = value; }

    _isOpen: boolean = false;

    get isOpen() { return this._isOpen; }

    set isOpen(value: boolean) {
        if (value && !this._isOpen)
            this.openAsync();

        if (!value && this._isOpen)
            this.closeAsync();

        this._isOpen = value;
    }

    openAsync = () => {
        var openAsyncFn = () => {
            return this.initializeAsync()
                .then(this._backdrop.openAsync)
                .then(this.appendModalToBodyAsync)
                .then(this.showAsync);
        }
        setTimeout(openAsyncFn, 100);
    }

    initializeAsync = () => {
        return new Promise((resolve) => {
            this.compileAsync().then(() => {                
                this._extendCssAsync({
                    nativeHTMLElement: this.nativeElement,
                    cssObject: {
                        "opacity": "0",
                        "position": "fixed",
                        "margin-top": "-300px",
                        "top": "0",
                        "left": "0",
                        "background-color": "#FFF",
                        "display": "block",
                        "z-index": "999",
                        "width": "100%",
                        "padding": "30px",
                        "transition": "all 0.5s",
                        "-webkit-transition": "all 0.5s",
                        "-o-transition": "all 0.5s"
                    }


                }).then(function () {
                    resolve();
                });

            });
        });
    }

    compileAsync = () => {
        return new Promise((resolve) => {
            //this.$scope = this.$rootScope.$new();
            //this.augmentedJQuery = this.$compile(angular.element(this.html))(this.$scope);
            setTimeout(() => {

                resolve();
            }, 100);
        });
    }

    appendModalToBodyAsync = () => this._appendToTargetAsync({ element: this.nativeElement, target: document.body });

    showAsync = () => this._extendCssAsync({
        nativeHTMLElement: this.nativeElement,
        cssObject: {
            "opacity": "100",
            "margin-top": "0px",
        }
    });

    closeAsync = () => {
        if (!this.pinned) {
            return new Promise((resolve) => {
                try {
                    this._extendCssAsync({
                        nativeHTMLElement: this.nativeElement,
                        cssObject: {
                            "opacity": "0",
                        }
                    })
                        .then(this._backdrop.closeAsync)
                        .then(() => {
                            this.nativeElement.parentNode.removeChild(this.nativeElement);
                            resolve();
                        });
                } catch (error) {
                    resolve();
                }
            });
        }
    }

    dispose = () => { }

    togglePin = () => {
        if (this.pinned) {
            this.pinned = false;
            this.closeAsync();
        } else {
            this.pinned = true;
        }
    }
    options;
    nativeElement: HTMLElement;

    pinned = false;
}