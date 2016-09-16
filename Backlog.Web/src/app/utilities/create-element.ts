export const createElement = (): HTMLElement => {
    let divElement = document.createElement("div")
    divElement.innerHTML = "<div></div>";
    return divElement.firstChild as HTMLElement;
}
