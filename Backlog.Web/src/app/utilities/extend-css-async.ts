export const extendCssAsync = (options: { nativeElement: HTMLElement, cssObject: Object }) => {
    return new Promise(resolve => {
        Object.assign(options.nativeElement.style, options.cssObject);
        resolve();
    })    
}
