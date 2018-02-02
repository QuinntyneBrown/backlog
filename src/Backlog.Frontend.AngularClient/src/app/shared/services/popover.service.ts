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
        this.handleDocumentClick = this.handleDocumentClick.bind(this);

        document.addEventListener("click", this.handleDocumentClick);
    }

    public handleDocumentClick($event) {
        if (this.isOpen)
            this.hide();
    }

    public static instance: PopoverService;
    
    public createInstance(): PopoverService {
        return new PopoverService(this._position);
    }
    
    public async show(options: { target: HTMLElement, html: string }): Promise<any> {                
        const containerElement = document.querySelector('body');
        this.nativeElement = createElement({ html: options.html });        
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
                if (this.nativeElement) {
                    this.nativeElement.parentNode.removeChild(this.nativeElement);
                    this.nativeElement = null;
                }
                resolve();
            });
        }
    }

    public get isOpen(): boolean {
        return this.nativeElement != null;
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

    public nativeElement: HTMLElement;

    public targetElement: HTMLElement;

    public templateHTML: string;
}