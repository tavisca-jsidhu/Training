ball.container = function () {

    var height = (window.innerHeight - 70);
    var width = (window.innerWidth - 70);
    if (ball.axisY >= height) {
        ball.yPos = -10;
    }
    if (ball.axisX >= width) {
        ball.xPos = -10;
    }
    if (ball.axisY <= 0) {
        ball.yPos = 10;
    }
    if (ball.axisX <= 0) {
        ball.xPos = 10;
    }
}