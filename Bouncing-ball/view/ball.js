window.ball = window.ball || { axisX: 0, axisY: 0, xPos: 10, yPos: 10 };

ball.bounce = function () {
    var element = document.getElementById('cir');
    element.style.background = "blue";
    element.style.left = ball.axisX + "px";
    element.style.top = ball.axisY + "px";
    ball.container();
    ball.axisX += ball.xPos;
    ball.axisY += ball.yPos;
}
window.ball.start = function () {
    setInterval(ball.bounce, 15);
}