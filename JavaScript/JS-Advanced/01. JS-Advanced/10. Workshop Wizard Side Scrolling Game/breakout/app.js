const canvas = document.getElementById('canvas');
/** @type {CanvasRenderingContext2D} */
const ctx = canvas.getContext('2d');

ctx.font = '24px Arial';
const width = canvas.width;
const height = canvas.height;

// Physics step
const stepSize = 20;
const rate = 1000 / stepSize;
const speed = 300;

const brickWidth = 50;
const brickHeight = 15;
const padWidth = 100;
const padHeight = 20;
const ballSize = 10;

const limits = {
    left: 0 + ballSize,
    right: width - ballSize,
    top: 0 + ballSize,
    bottom: height - 50 - ballSize,
    // bottom: height - ballSize,
};

const mouse = {
    x: 0,
    y: 0,
};

const ball = {
    x: 400,
    y: 300,
    velocity: getVector(speed, Math.PI / 4),
};

const bricks = [];
const colors = ['black', 'green', '#00CCCC'];

canvas.addEventListener('mousemove', onMouse);

function getVector(speed, dir) {
    return {
        x: Math.cos(dir) * speed,
        y: Math.sin(dir) * speed,
    }
}

function onMouse(event) {
    mouse.x = event.offsetX;
    mouse.y = event.offsetY;
}

function drawBrick(x, y, color) {
    ctx.fillStyle = color;
    ctx.fillRect(x, y, brickWidth, brickHeight);
}

function pad(x, y, color) {
    y = 550;
    color = 'blue';
    ctx.fillStyle = color;
    ctx.fillRect(x - padWidth / 2, y, padWidth, padHeight);
}

function drawBall(x, y, color) {
    color = 'red';
    ctx.fillStyle = color;
    ctx.beginPath();
    ctx.moveTo(x, y);
    ctx.arc(x, y, ballSize, 0, Math.PI * 2);
    ctx.closePath();
    ctx.fill();
}

function clear() {
    ctx.clearRect(0, 0, 800, 600);
}

function render() {
    clear();
    for (let brick of bricks) {
        if (brick.live == false) {
            continue;
        }
        drawBrick(brick.x, brick.y, colors[brick.hits]);
    }
    pad(mouse.x);
    drawBall(ball.x, ball.y);
}

function tick() {
    ball.x += ball.velocity.x / rate;
    ball.y += ball.velocity.y / rate;

    if ((ball.x > limits.right && ball.velocity.x > 0)
        || (ball.x < limits.left && ball.velocity.x < 0)) {
        ball.velocity.x *= -1;
    }
    if (ball.y < limits.top && ball.velocity.y < 0) {
        ball.velocity.y *= -1;
    }

    // Paddle hit
    if ((ball.y > limits.bottom && ball.velocity.y > 0)
        && (ball.y <= limits.bottom + ballSize)
        && (ball.x >= mouse.x - padWidth / 2 - ballSize)
        && (ball.x <= mouse.x + padWidth / 2 + ballSize)) {
        ball.velocity.y *= -1;

        // const x = ball.velocity.x + 100 * (ball.x - mouse.x) / padWidth;
        // const y = Math.sqrt(speed ** 2 - x ** 2);
        // ball.velocity.x = x;
        // ball.velocity.y = -y;
    }

    for (let brick of bricks) {
        if (brick.live == false) {
            continue;
        }
        checkBrick(brick);
    }
}

function checkBrick(brick) {
    if ((ball.x + ballSize > brick.x)
        && (ball.x - ballSize < brick.x + brickWidth)
        && (ball.y + ballSize > brick.y)
        && (ball.y - ballSize < brick.y + brickHeight)) {
        brick.hits--;

        if (brick.hits == 0) {
            brick.live = false;
        }

        if (ball.x < brick.x && ball.velocity.x > 0) {
            ball.velocity.x *= -1;
        } else if (ball.x > brick.x + brickWidth && ball.velocity.x < 0) {
            ball.velocity.x *= -1;
        }

        if (ball.y < brick.y && ball.velocity.y > 0) {
            ball.velocity.y *= -1;
        } else if (ball.y > brick.y + brickHeight && ball.velocity.x < 0) {
            ball.velocity.y *= -1;
        }
    }
}

let lastTime = 0;
let delta = 0;

function main(time) {
    delta += time - lastTime;
    lastTime = time;

    if (delta > 1000) {
        delta = 20;
    }
    while (delta >= 20) {
        delta -= 20;
        tick();
    }

    render();

    ctx.fillText(delta, 20, 20);

    requestAnimationFrame(main);
}

function start() {
    for (let row = 0; row < 5; row++) {
        for (let col = 0; col < 13; col++) {
            bricks.push({
                x: col * brickWidth * 1.2 + 15,
                y: row * brickHeight * 2 + 100,
                live: true,
                hits: 2,
            })
        }
    }

    requestAnimationFrame(main);
}

start();