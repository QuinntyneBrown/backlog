import {
    Component,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
} from "@angular/core";

import { FormGroup, FormControl, Validators } from "@angular/forms";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./sign-up.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "./sign-up.component.css"],
    selector: "ce-sign-up"
})
export class SignUpComponent { 
    constructor(
        private _elementRef: ElementRef,
        private _renderer: Renderer) {

    }
    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
    
    public get emailNativeElement(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#email");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.emailNativeElement, 'focus', []);
    }

    @Output()
    public tryToSignUp: EventEmitter<any> = new EventEmitter();

    public form = new FormGroup({
        email: new FormControl('', [Validators.required, Validators.email]),
        fullName: new FormControl('',[Validators.required]),
        password: new FormControl('', [Validators.required]),
        passwordConfirmation: new FormControl('', [Validators.required])        
    });
}
