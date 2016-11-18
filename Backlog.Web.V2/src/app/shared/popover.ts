import { Position, Template, createElement } from "../utilities";

export class Popover {

    constructor(        
        private _createElement: any = createElement,
        private _position: Position = Position.Instance,
        private _template:Template = Template.Instance
    ) { }

    private static _instance: Popover;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }


    public newPopover = (options: { triggerElement: HTMLElement, html: string }): Popover => {
        var instance = new Popover();
        instance.triggerElement = options.triggerElement;
        instance.element = this._createElement(options.html);
        return instance;        
    }

    private setInitialCss = () => {
        this.element.setAttribute("style", "-webkit-transition: opacity " + this.transitionDurationInMilliseconds + "ms ease-in-out;-o-transition: opacity " + this.transitionDurationInMilliseconds + "ms ease-in-out;transition: opacity " + this.transitionDurationInMilliseconds + "ms ease-in-out;");
        this.element.style.opacity = "0";
        this.element.style.position = "fixed";
        this.element.style.top = "0";
        this.element.style.left = "0";
        this.element.style.display = "block";
    }

    public show = () => {
        return new Promise((resolve) => {
            this.setInitialCss();
            this._position.below(this.triggerElement, this.element, 30).then(() => {
                document.body.appendChild(this.element);
                setTimeout(() => {
                    this.element.style["opacity"] = "100";                    
                }, 0);                
                resolve();
            });
        });                    
    }

    public hide = () => {
        return new Promise((resolve) => {
            this.element.style["opacity"] = "0";
            this.element.addEventListener('transitionend', () => {
                if (this.element.parentNode)
                    this.element.parentNode.removeChild(this.element);
                resolve();
            }, false);
        });        
    }

    private templateHtml: string;
    private element: HTMLElement;
    private scope: any;
    private triggerElement: HTMLElement;
    private rectangle: any;
    private get transitionDurationInMilliseconds() { return 1000; }
    private attributes: any;
}
