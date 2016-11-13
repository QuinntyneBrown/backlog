export class Http extends XMLHttpRequest {

    constructor() {
        super();
    }

    public open(method: string, url: string, async: boolean = true, user: string = null, password: string = null) {
        super.open(method, url, async, user, password);
    }

    public setRequestHeader(header: string, value: string) {
        super.setRequestHeader(header, value);
    }

    public onload = (ev:Event) => {
        super.onload(ev);
    }

    public send(data:any) {
        super.send(data);
    }
}

