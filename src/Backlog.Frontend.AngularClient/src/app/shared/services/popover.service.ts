import { Injectable } from "@angular/core";
import { Position } from "./position";
import { translateXY } from "../utilities/translate-xy";
import { createElement } from "../utilities/create-element";
import { Ruler } from "./ruler";
import { Space } from "./space";

export const POPOVER_OPEN = "[Popover] Open";
export const POPOVER_CLOSE = "[Popover] Close";

export interface IPopoverService { }

export function PopoverServiceFactory(_position: Position) {
    PopoverService.instance = PopoverService.instance || new PopoverService(_position);
    return PopoverService.instance;
}

@Injectable()
export class PopoverService implements IPopoverService {
    constructor(
        private _position: Position
    ) {
        this.show = this.show.bind(this);
        this.hide = this.hide.bind(this);
    }

    public static instance: PopoverService;

    public async show(options: { target: HTMLElement, html: string }): Promise<any> {

        if (this._nativeElement)
            return new Promise(resolve => resolve());

        const containerElement = document.querySelector('body');

        this._nativeElement = createElement({ html: options.html });

        this._nativeElementsDictionary.push({ target: options.target, nativeElement: this._nativeElement });

        this.setInitialCss();

        await this._position.bottomLeft({
            component: this.nativeElement,
            target: options.target,
            space: 0
        });

        containerElement.appendChild(this.nativeElement);
        setTimeout(() => { this.nativeElement.style.opacity = "100"; }, 100);

    }

    public hide(target: HTMLElement = null): Promise<any> {
        if (target) {
            return Promise.resolve(null);
        } else {
            return new Promise((resolve) => {
                if (this._nativeElement) {
                    this._nativeElement.parentNode.removeChild(this.nativeElement);
                    this._nativeElement = null;
                }
                resolve();
            });
        }
    }

    public get isOpen(): boolean {
        return this._nativeElement != null;
    }

    private setInitialCss() {
        this.nativeElement.setAttribute("style", `-webkit-transition: opacity ${this.transitionDurationInMilliseconds}ms ease-in-out;-o-transition: opacity ${this.transitionDurationInMilliseconds}ms ease-in-out;transition: opacity ${this.transitionDurationInMilliseconds}ms ease-in-out;`);
        this.nativeElement.style.opacity = "0";
        this.nativeElement.style.position = "fixed";
        this.nativeElement.style.top = "0";
        this.nativeElement.style.left = "0";
        this.nativeElement.style.display = "block";
    }

    public transitionDurationInMilliseconds: number;

    private _nativeElement: HTMLElement;

    private _nativeElementsDictionary: Array<{ target: HTMLElement, nativeElement: HTMLElement }> = [];

    public get nativeElement(): HTMLElement {
        return this._nativeElement;
    }

    public templateHTML: string;
}