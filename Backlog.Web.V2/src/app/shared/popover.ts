//import { Position } from "../utilities";

//export class Popover {

//    constructor(        
//        private position: Position = Position.Instance,
//        private template:any = null
//    ) { }

//    public newPopover = (options: any) => {
//        return new Promise((resolve) => {
//            var instance = new Popover();

//            instance.triggerElement = options.triggerElement;

//            Promise.all([this.template.get({ templateUrl: options.templateUrl })]).then((resultsArray: any) => {
//                instance.templateHtml = resultsArray[0];
//                resolve(instance);
//            });
//        });

//    }

//    private setInitialCss = () => {
//        this.augmentedJQuery[0].setAttribute("style", "-webkit-transition: opacity " + this.transitionDurationInMilliseconds + "ms ease-in-out;-o-transition: opacity " + this.transitionDurationInMilliseconds + "ms ease-in-out;transition: opacity " + this.transitionDurationInMilliseconds + "ms ease-in-out;");
//        this.augmentedJQuery[0].style.opacity = "0";
//        this.augmentedJQuery[0].style.position = "fixed";
//        this.augmentedJQuery[0].style.top = "0";
//        this.augmentedJQuery[0].style.left = "0";
//        this.augmentedJQuery[0].style.display = "block";
//    }

//    public show = () => {
//        return new Promise((resolve) => {
//            this.augmentedJQuery = this.$compile(this.templateHtml)(this.scope.$new(true));
//            this.setInitialCss();
//            this.position.below(this.triggerElement[0], this.augmentedJQuery[0], 30).then(() => {
//                document.body.appendChild(this.augmentedJQuery[0]);
//                this.$timeout(() => { this.augmentedJQuery.css("opacity", 100); }, 100, false);
//                resolve();
//            });
//        });
//        return deferred.promise;
//    }

//    public hide = () => {
//        var deferred = this.$q.defer();
//        this.augmentedJQuery.css("opacity", 0);
//        this.augmentedJQuery[0].addEventListener('transitionend', () => {
//            angular.element(this.augmentedJQuery[0]).scope().$destroy();
//            this.augmentedJQuery[0].parentNode.removeChild(this.augmentedJQuery[0]);
//            deferred.resolve();
//        }, false);
//        return deferred.promise;
//    }

//    private templateHtml: string;
//    private scope: any;
//    private augmentedJQuery: any;
//    private triggerElement: HTMLElement;
//    private rectangle: any;
//    private get transitionDurationInMilliseconds() { return 1000; }
//    private attributes: any;
//}
