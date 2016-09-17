
import {
    Component,
    forwardRef,
    OnChanges,
    SimpleChanges,
    OnInit,
    AfterViewInit,
    ElementRef,
    NgZone
} from '@angular/core';

import {
    NG_VALUE_ACCESSOR,
    ControlValueAccessor
} from '@angular/forms';

const noop = () => { };

import { guid } from "../utilities";

export const TINYMCE_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => HtmlTextareaComponent),
    multi: true
};

declare var tinymce;

@Component({
    template: require("./html-textarea.component.html"),
    styles: [require("./html-textarea.component.scss")],
    selector: "html-textarea",
    providers: [TINYMCE_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class HtmlTextareaComponent implements ControlValueAccessor, AfterViewInit, OnInit {

    constructor(private _ngZone: NgZone, private _elementRef: ElementRef) { }

    ngOnInit() {
        var el: HTMLElement = (<HTMLElement>this._elementRef.nativeElement).querySelector("textarea") as HTMLElement;
        el.setAttribute("id", this._guid);
    }

    private _value: string = '';

    private onTouchedCallback: () => void = noop;

    private onChangeCallback: (_: any) => void = noop;

    private _guid: string = guid();

    private _editor: any;

    private _hasInitialized: boolean = false;

    public ngAfterViewInit() {
        tinymce.init({
            selector: `textarea#${this._guid}`,
            setup: editor => {
                this._editor = editor;
                editor.on('keyup change', (ed, l) => {
                    this._ngZone.run(() => {
                        this.value = tinymce.activeEditor.getContent();
                    });
                });
                setTimeout(() => {
                    editor.setContent(this.value);
                    this._hasInitialized = true;
                }, 0);
            },
            height: 300,
            plugins: [
                'advlist autolink lists link image charmap print preview anchor',
                'searchreplace visualblocks code fullscreen',
                'insertdatetime media table contextmenu paste code'
            ],
            toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image'
        });
    }

    get value(): string { return this._value; };

    set value(value: string) {
        if (value !== this._value) {
            this._value = value;
            this.onChangeCallback(this._value);
        }
    }

    writeValue(value: string) {
        if (value !== this._value) {
            this._value = value;
        }
    }

    registerOnChange(callback: { (): void }) {
        this.onChangeCallback = callback;
    }

    registerOnTouched(callback: { (): void }) {
        this.onTouchedCallback = callback;
    }
}
