export class EditorComponent {
    constructor(private nativeElement: HTMLElement) {
        this._quill = new Quill(nativeElement, {
            modules: {
                toolbar: [
                    [{ header: [1, 2, false] }],
                    ['bold', 'italic', 'underline'],
                    ['link']
                ]
            },
            theme: 'snow'
        });
        this._addEventListeners();
    }

    private _addEventListeners() {
        this._quill.on("text-change", this._onTextChange.bind(this));
    }

    private _onTextChange(delta, oldDelta, source) {
        this.text = this.nativeElement.children[0].innerHTML;
    }

    public setHTML(html: string) {
        this.nativeElement.children[0].innerHTML = html;
    }

    public text;
    private _quill;
}
