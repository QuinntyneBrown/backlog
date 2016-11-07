export const appendToTargetAsync = (options: { wait?: number, nativeElement: HTMLElement, target: HTMLElement }) => {    
    return new Promise(resolve => {
        options.target.appendChild(options.nativeElement);
        setTimeout(() => { resolve(); }, options.wait || 100);        
    });
}