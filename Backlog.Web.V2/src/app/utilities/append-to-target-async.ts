export const appendToTargetAsync = (options: { wait?: number, element: HTMLElement, target: HTMLElement }) => {    
    return new Promise(resolve => {
        options.target.appendChild(options.element);
        setTimeout(() => { resolve(); }, options.wait || 100);        
    });
}