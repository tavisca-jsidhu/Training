var horizontal = 0;
var vertical = 0;
var xPos = 10;
var yPos = 10;

function start() {
    setInterval(bounce, 20);
}
function bounce() {
    var height = (window.innerHeight - 35);
    var width = (window.innerWidth - 35);

    horizontal += xPos;
    vertical += yPos;
    var element = document.getElementById('bounce');
    element.style.background = "black";
    element.style.left = previousLeft + "px";
    element.style.top = previousTop + "px";

    if (vertical >= height) {
        yPos = -10;
        return;
    }
    if (horizontal >= width) {
        xPos = -10;
        return;
    }
    if (vertical <= 0) {
        yPos = 10;
        return;
    }
    if (horizontal <= 0) {
        xPos = 10;
        return;
    }
}