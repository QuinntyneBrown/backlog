import { Position, Template } from "../utilities";

export class Popover {

    constructor(        
        private position: Position = Position.Instance,
        private template:Template = Template.Instance
    ) { }

    public newPopover = (options: any) => {
        return new Promise((resolve) => {
            var instance = new Popover();
            instance.triggerElement = options.triggerElement;
            Promise.all([this.template.get({ templateUrl: options.templateUrl })]).then((resultsArray: any) => {
                instance.templateHtml = resultsArray[0];
                resolve(instance);
            });
        });

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
            this.position.below(this.triggerElement[0], this.element[0], 30).then(() => {
                document.body.appendChild(this.element[0]);
                setTimeout(() => {
                    this.element.style["opacity"] = "0";                    
                }, 0);                
                resolve();
            });
        });                    
    }

    public hide = () => {
        return new Promise((resolve) => {
            this.element.style["opacity"] = "0";
            this.element.addEventListener('transitionend', () => {
                this.element[0].parentNode.removeChild(this.element[0]);
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
