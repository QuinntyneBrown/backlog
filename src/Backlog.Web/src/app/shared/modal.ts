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
        private _createElement = createElement,
        private _extendCssAsync = extendCssAsync,
        private _removeElement = removeElement,
        private _setOpacityAsync = setOpacityAsync
    ) { }


    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    _html: string;

    get html() { return this._html; }

    set html(value: string) { this._html = value; }

    openAsync = options => {
        return new Promise((resolve) => {
            this._html = options.html;
            var openAsyncFn = () => {
                return this.initializeAsync()
                    .then(this._backdrop.openAsync)
                    .then(this.appendModalToBodyAsync)
                    .then(this.showAsync)
                    .then(() => {
                        resolve();
                    });
            }
            setTimeout(openAsyncFn, 0);
        });
    }

    initializeAsync = () => {
        return new Promise((resolve) => {
            this.compileAsync().then(() => {
                this._extendCssAsync({
                    nativeHTMLElement: this.nativeHTMLElement,
                    cssObject: {
                        "opacity": "0",
                        "position": "fixed",
                        "top": "0",
                        "left": "0",
                        "display": "block",
                        "z-index": "999",
                        "width": "100%",
                        "height": "100%",
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
            this.nativeHTMLElement = this._createElement(this.html);
            setTimeout(() => {
                resolve();
            }, 0);
        });
    }

    appendModalToBodyAsync = () => this._appendToTargetAsync({ nativeHTMLElement: this.nativeHTMLElement, target: document.body });

    showAsync = () => this._extendCssAsync({
        nativeHTMLElement: this.nativeHTMLElement,
        cssObject: {
            "opacity": "100"
        }
    });

    closeAsync = () => {
        return new Promise((resolve) => {
            try {
                this._extendCssAsync({
                    nativeHTMLElement: this.nativeHTMLElement,
                    cssObject: { "opacity": "0" }
                })
                    .then(this._backdrop.closeAsync)
                    .then(() => {
                        this.nativeHTMLElement.parentNode.removeChild(this.nativeHTMLElement);
                        resolve();
                    });
            } catch (error) {
                resolve();
            }
        });
    }

    nativeHTMLElement: HTMLElement;

}