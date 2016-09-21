import {NgModule, Component, ElementRef, AfterViewInit, Input, Output, EventEmitter, ContentChild, OnChanges, forwardRef} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NG_VALUE_ACCESSOR, ControlValueAccessor} from '@angular/forms';

@Component({
    selector: 'header',
    template: '<ng-content></ng-content>'
})
export class Header { }

declare var Quill: any;

export const EDITOR_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => EditorComponent),
    multi: true
};

@Component({
    selector: 'editor',
    template: require("./editor.component.html"),
    providers: [EDITOR_VALUE_ACCESSOR]
})
export class EditorComponent implements AfterViewInit, ControlValueAccessor {

    @Output() onTextChange: EventEmitter<any> = new EventEmitter();

    @Output() onSelectionChange: EventEmitter<any> = new EventEmitter();

    @ContentChild(Header) toolbar;

    @Input() style: any;

    @Input() styleClass: string;

    @Input() placeholder: string;

    @Input() readOnly: boolean;

    @Input() formats: string[];

    value: string;

    onModelChange: Function = () => { };

    onModelTouched: Function = () => { };

    quill: any;

    constructor(protected _elementRef: ElementRef) { }

    ngAfterViewInit() {
        let editorElement = this._elementRef.nativeElement.querySelector('div.ui-editor-content');
        let toolbarElement = this._elementRef.nativeElement.querySelector('div.ui-editor-toolbar');
        
        this.quill = new Quill(editorElement, {
            modules: {
                toolbar: toolbarElement
            },
            placeholder: this.placeholder,
            readOnly: this.readOnly,
            theme: 'snow',
            formats: this.formats
        });

        if (this.value) {
            this.quill.pasteHTML(this.value);
        }

        this.quill.on('text-change', (delta, source) => {
            let html = editorElement.children[0].innerHTML;
            let text = this.quill.getText();
            if (html == '<p><br></p>') {
                html = null;
            }

            this.onTextChange.emit({
                htmlValue: html,
                textValue: text,
                delta: delta,
                source: source
            });

            this.onModelChange(html);
        });

        this.quill.on('selection-change', (range, oldRange, source) => {
            this.onSelectionChange.emit({
                range: range,
                oldRange: oldRange,
                source: source
            });
        });
    }

    writeValue(value: any): void {
        this.value = value;

        if (this.quill) {
            if (value)
                this.quill.pasteHTML(value);
            else
                this.quill.setText('');
        }
    }

    registerOnChange(fn: Function): void {
        this.onModelChange = fn;
    }

    registerOnTouched(fn: Function): void {
        this.onModelTouched = fn;
    }
}
