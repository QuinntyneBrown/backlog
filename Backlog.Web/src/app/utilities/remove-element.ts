export const removeElement = (options: { nativeElement: HTMLElement }) => {
    if (options.nativeElement) {
        options.nativeElement.parentNode.removeChild(options.nativeElement);        
        delete options.nativeElement;
    }
}
