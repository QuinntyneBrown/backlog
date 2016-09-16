import { Response } from "@angular/http";

export const extractData = <T>(res: Response) => {
    if (res.status < 200 || res.status >= 300) {
        throw new Error('Bad response status: ' + res.status);
    }
    let body = res.json();
    return <T>(body.data || {});
}
