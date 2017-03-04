﻿export const loadStyle = (css, selector) => {
    function addStyleTagToHead() {
        var style = document.createElement("style");
        style.setAttribute("data-selector", selector)
        style.appendChild(document.createTextNode(css));
        document.head.appendChild(style);
    }

    if (document.readyState === "complete" || document.readyState === 'interactive') {
        addStyleTagToHead();
    }
    else {

        window.addEventListener("DOMContentLoaded", onDocumentLoad);
    }

    function onDocumentLoad() {
        addStyleTagToHead();
        window.removeEventListener("DOMContentLoaded", onDocumentLoad);
    }
}