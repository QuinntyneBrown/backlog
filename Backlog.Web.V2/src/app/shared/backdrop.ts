import { appendToTargetAsync, extendCssAsync, removeElement, setOpacityAsync, createElement } from "../utilities";

export class Backdrop {
    constructor(
        private _createElement: any = createElement,
        private _appendToTargetAsync: any = appendToTargetAsync,
        private _extendCssAsync: any = extendCssAsync,
        private _removeElement: any = removeElement,
        private _setOpacityAsync: any = setOpacityAsync) { }

    private static _instance: Backdrop;

    public static get Instance() { 
        this._instance = this._instance || new Backdrop(createElement, appendToTargetAsync, extendCssAsync, removeElement, setOpacityAsync);
        return this._instance;
    }

    public openAsync = (options: { target: HTMLElement } = { target: document.body }) => {
        return new Promise(resolve => {
            this.initializeAsync()
                .then(() => this._appendToTargetAsync({ target: options.target, nativeHTMLElement: this._element }))
                .then(this.showAsync.bind(this))
                .then(() => {
                    this.isOpen = true;
                    resolve();
                });
        });
    }

    public closeAsync = () => {
        return new Promise(resolve => {
            this.hideAsync().then((results) => {
                this.dispose();
                this.isOpen = false;
                resolve();
            });
        });
    }

    public initializeAsync = () => {
        return new Promise(resolve => {
            this._element = createElement("<div></div>");
            this._extendCssAsync({
                nativeHTMLElement: this._element,
                cssObject: {
                    "-webkit-transition": "opacity 300ms ease-in-out",
                    "-o-transition": "opacity 300ms ease-in-out",
                    "transition": "opacity 300ms ease-in-out",
                    "opacity": "0",
                    "position": "fixed",
                    "top": "0",
                    "left": "0",
                    "height": "100%",
                    "width": "100%",
                    "background-color": "rgba(0, 0, 0, 0.55)",
                    "display": "block",
                    "pointer-events":"none"
                }
            }).then(() => {
                resolve();
            });
        });
    }

    public showAsync = () => {                
        return this._setOpacityAsync({ nativeHTMLElement: this._element, opacity: 1 });
    }

    public hideAsync = () => {
        return this._setOpacityAsync({ nativeHTMLElement: this._element, opacity: 0 });
    }

    public dispose = () => {
        this._removeElement({ nativeHTMLElement: this._element });
        this._element = null;
    }

    private _element: HTMLElement;

    public isOpen: boolean = false;

    public isAnimating: boolean = false;
}