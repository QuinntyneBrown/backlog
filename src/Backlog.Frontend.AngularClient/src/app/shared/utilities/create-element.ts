export const createElement = (options:{ html: string }): HTMLElement =>
    new DOMParser().parseFromString(options.html, "text/html").body.firstChild as HTMLElement;