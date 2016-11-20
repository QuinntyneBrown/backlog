import {Observable} from "rxjs";

export function load(url: string) {
    return Observable.create(observer => {
        let xhr = new XMLHttpRequest();
        let loadHandler = () => {
            if (xhr.status === 200) {
                let data = JSON.parse(xhr.responseText);
                observer.next(data);
                observer.complete();
            } else {
                observer.error(xhr.statusText);
            }
        };

        xhr.addEventListener("load", loadHandler);

        xhr.open("GET", url);
        xhr.send()

        return () => {
            console.log("cleanup");
            xhr.removeEventListener("load", loadHandler);
            xhr.abort();
        }
    });
}
