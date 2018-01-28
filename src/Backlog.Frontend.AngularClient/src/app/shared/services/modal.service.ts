import { Injectable } from "@angular/core";
import { createElement } from "../utilities/create-element";


export const MODAL_CLOSE = "[Modal] Close";
export const MODAL_OPEN = "[Modal] Open";

export function ModalServiceFactory() {
    ModalService.instance = ModalService.instance || new ModalService();
    return ModalService.instance;
}

@Injectable()
export class ModalService {

    constructor() {
        this.close = this.close.bind(this);
        this.open = this.open.bind(this);

        document.addEventListener(MODAL_CLOSE, this.close);
        document.addEventListener(MODAL_OPEN, (e:any) => this.open({ html: e.detail.html }));
    }

    public static instance: ModalService;
    
    private static _instance: ModalService;

    private _backdropNativeElement: HTMLElement;

    private _modalNativeElement: HTMLElement;

    public open(options: { html: any }) {
        var containerElement = document.querySelector('body');

        this._backdropNativeElement = createElement({ html: "<cs-backdrop></cs-backdrop>" });

        containerElement.appendChild(this._backdropNativeElement);

        this._modalNativeElement = createElement({ html: options.html });

        containerElement.appendChild(this._modalNativeElement);
    }

    public close() {
        this._backdropNativeElement.parentNode.removeChild(this._backdropNativeElement);
        this._modalNativeElement.parentNode.removeChild(this._modalNativeElement);
    }
}