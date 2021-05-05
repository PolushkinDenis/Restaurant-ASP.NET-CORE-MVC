window.onload = initAll;
var xhr = false;
var xPos, yPos;

function initAll() {
    var allLinks = document.getElementsByClassName("a");

    for (var i = 0; i < allLinks.length; i++) {
        allLinks[i].onmouseover = showPreview;
    }
}

function showPreview(evt) {
    if (evt) {
        var url = evt.target;
    }
    else {
        evt = window.event;
        var url = evt.srcElement;
    }
    xPos = evt.clientX;
    yPos = evt.clientY;

    if (window.XMLHttpRequest) {
        xhr = new XMLHttpRequest();
    }
    else {
        if (window.ActiveXObject) {
            try {
                xhr = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) { }
        }
    }

    if (xhr) {
        xhr.onreadystatechange = showContents;
        xhr.open("GET", url, true);
        xhr.send(null);
    }
    else {
        alert("Ошибка при создании XMLHttp запроса");
    }
    return false;
}