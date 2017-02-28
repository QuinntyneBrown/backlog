export const createElement = (html: string): HTMLElement =>
    new DOMParser().parseFromString(html, "text/html").body.firstChild as HTMLElement;