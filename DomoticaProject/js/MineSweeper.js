
var closedColor = "#999";
var openColor = "#dddddd";
var flagColor = "#555500";
var mineColor = "#dd0000";
var textColor = "#000000";
var totalMines = 10;

// debugger;
var width, scale, fieldSize, bombs, isFlagged, isNotClicked, clicks, minesLeft = 0, time = 0, minesTimerVar, playing = false;
var canvas = document.getElementById("minesweeper");
var height = canvas.height;
var ctx = canvas.getContext("2d");

var font = 'px Arial';
var FontAwesome = 'px FontAwesome';

fieldX = [0, 0, 0, 0, 0, 0, 0, 0];
fieldY = [0, 0, 0, 0, 0, 0, 0, 0];

isNotClicked = [
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1, 1]
];

isFlagged = [
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0]
];

var minesTimerVar = setInterval(minesTimer, 1000);

setWidth()

window.onresize = function () {
    // debugger;
    setWidth();
    drawEmpty();

    for (var x = 0; x < 8; x++) {
        for (var y = 0; y < 8; y++) {
            //opened
            if (isNotClicked[x][y] == 0) {
                ctx.fillStyle = openColor;
                ctx.fillRect(fieldX[x], fieldY[y], fieldSize, fieldSize);
                checkSurrounding(x, y);
            }
            //flagged
            if (isFlagged[x][y] == 1) {
                ctx.font = fieldSize * .85 + FontAwesome;
                ctx.fillText("\uf024", fieldX[x] + fieldSize * .05, fieldY[y] + fieldSize * .85);
                ctx.font = fieldSize + font;
            }
        }
    }
}

function setWidth() {
    // debugger;
    width = canvas.parentElement.clientWidth;
    canvas.width = width;

    if (canvas.width < canvas.height) {
        scale = canvas.width / 8;
    } else {
        scale = canvas.height / 8;
    }

    fieldSize = .75 * scale;
    ctx.font = fieldSize + font;

    for (var x = 0; x < 8; x++) {
        fieldX[x] = scale * x;
    }
    for (var y = 0; y < 8; y++) {
        fieldY[y] = scale * y;
    }
}

drawEmpty();

function drawEmpty() {
    // debugger;
    ctx.fillStyle = closedColor;
    for (var x = 0; x < 8; x++) {
        for (var y = 0; y < 8; y++) {
            ctx.fillRect(fieldX[x], fieldY[y], fieldSize, fieldSize);
        }
    }
}

// console.log(fieldX + " " + fieldY);

function init() {
    drawEmpty();

    isNotClicked = [
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1],
      [1, 1, 1, 1, 1, 1, 1, 1]
    ];

    isFlagged = [
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0]
    ];

    clicks = 0;

    minesLeft = 0;

    playing = true;

    time = 0;
}

function generateBombs(x, y) {
    bombs = [
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0]
    ];
    for (var i = 0; i < totalMines - minesLeft; i++) {
        newBomb(x, y);
    }
    // console.log("boms placed");
}


function newBomb(xl, yl) {
    bomb = Math.floor(Math.random() * 64);
    xb = bomb % 8;
    yb = Math.floor(bomb / 8);
    if (
      bombs[xb][yb] == 1 ||
      xb >= xl - 1 && xb <= xl + 1 &&
      yb >= yl - 1 && yb <= yl + 1
    ) {
        // console.log(xb + " " + yb + " " + xl + " " + yl  + " " +  (bombs[xb][yb] == 1)  + " " +  (xb >= xl-1)  + " " +  (xb <= xb+1)  + " " +  (yb >= yl-1)  + " " +  (yl <= yb+1));
        newBomb(xl, yl);
    }
    else bombs[xb][yb] = 1;
}


canvas.addEventListener('click', function (event) {
    // debugger;
    var xm = event.offsetX,
        ym = event.offsetY;
    for (var x = 0; x < 8; x++) {
        for (var y = 0; y < 8; y++) {
            if (((xm >= fieldX[x]) && (xm <= fieldX[x] + fieldSize)) && ((ym >= fieldY[y]) && (ym <= fieldY[y] + fieldSize))) {
                if (playing == false) {
                    init();
                    generateBombs(x, y);
                }
                openField(x, y);
                clicks++;
            }
        }
    }
});
canvas.addEventListener('contextmenu', function (event) {
    // debugger;
    event.preventDefault();
    var xm = event.offsetX,
        ym = event.offsetY;
    for (var x = 0; x < 8; x++) {
        for (var y = 0; y < 8; y++) {
            if (((xm >= fieldX[x]) && (xm <= fieldX[x] + fieldSize)) && ((ym >= fieldY[y]) && (ym <= fieldY[y] + fieldSize))) {
                if (isNotClicked[x][y] == 1) {
                    if (isFlagged[x][y] == 0) {
                        isFlagged[x][y] = 1;
                        //ctx.fillStyle = flagColor;
                        ctx.font = fieldSize * .85 + FontAwesome;
                        ctx.fillText("\uf024", fieldX[x] + fieldSize * .05, fieldY[y] + fieldSize * .85);
                        ctx.font = fieldSize + font;
                        minesLeft++;
                    } else {
                        isFlagged[x][y] = 0;
                        ctx.fillStyle = closedColor;
                        minesLeft--;
                        ctx.fillRect(fieldX[x], fieldY[y], fieldSize, fieldSize);
                    }
                    showMinesLeft();
                }
            }
        }
    }
});

function openField(x, y) {
    if (isFlagged[x][y] == 0 && isNotClicked[x][y] == 1) {
        isNotClicked[x][y] = 0;
        ctx.fillStyle = openColor;
        ctx.fillRect(fieldX[x], fieldY[y], fieldSize, fieldSize);
        if (bombs[x][y] == 1) {
            lost();
            ctx.fillStyle = mineColor;
            ctx.font = fieldSize * .75 + FontAwesome;
            ctx.fillText("\uf1e2", fieldX[x] + fieldSize * .15, fieldY[y] + fieldSize * .75);
            ctx.font = fieldSize + font;
        }
        // console.log(fieldX + " " + fieldY);
        checkSurrounding(x, y);
        if (isNotClicked.equals(bombs)) won();
        // console.log(bombs[0] + " " + isNotClicked[0]);
    }
}

function checkSurrounding(x, y) {
    var surrounding = 0;
    for (var i = x - 1; i <= x + 1; i++) {
        if (i >= 8 || i < 0) continue
        for (var j = y - 1; j <= y + 1; j++) {
            if (j >= 8 || j < 0) continue
            if (bombs[i][j] == 1) surrounding++;
            // console.log(i + " " + j + " " + surrounding);
        }
    }
    ctx.fillStyle = textColor;
    if (surrounding == 0) openSurrounding(x, y);
    else if (bombs[x][y] == 0) ctx.fillText(surrounding, fieldX[x] + fieldSize * .2, fieldY[y] + fieldSize * .9);
    // console.log(surrounding);
}

function openSurrounding(x, y) {
    for (var i = x - 1; i <= x + 1; i++) {
        if (i >= 8 || i < 0) continue
        for (var j = y - 1; j <= y + 1; j++) {
            if (j >= 8 || j < 0) continue
            openField(i, j);
            // console.log(i + " " + j + " " + surrounding);
        }
    }
}

function showMinesLeft() {
    ctx.fillStyle = "#ffffff";
    ctx.fillRect(scale * 5, scale * 8, 50, fieldSize * 2)
    ctx.fillStyle = textColor;
    ctx.fillText(minesLeft, scale * 5, scale * 9);
}

function minesTimer() {
    if (playing) {
        ctx.fillStyle = "#ffffff";
        ctx.fillRect(scale, scale * 8, 100, fieldSize * 2)
        // var d = time++;
        ctx.fillStyle = textColor;
        ctx.fillText(++time, scale, scale * 9);
        // document.getElementById("demo").innerHTML = d.toLocaleTimeString();
    }
}

function lost() {
    alert("you lost :(");
    ctx.fillStyle = textColor;
    //ctx.fillRect(fieldX[x], fieldY[y], fieldSize, fieldSize);
    ctx.font = fieldSize * .75 + FontAwesome;
    for (var x = 0; x < 8; x++) {
        for (var y = 0; y < 8; y++) {
            if (bombs[x][y] == 1 && isFlagged[x][y] == 0) {
                ctx.fillText("\uf1e2", fieldX[x] + fieldSize * .15, fieldY[y] + fieldSize * .75);
            }

            if (bombs[x][y] == 0 && isFlagged[x][y] == 1) {
                ctx.fillStyle = mineColor;
                ctx.font = fieldSize * .85 + FontAwesome;
                ctx.fillText("\uf024", fieldX[x] + fieldSize * .05, fieldY[y] + fieldSize * .85);
                ctx.fillStyle = textColor;
                ctx.font = fieldSize * .75 + FontAwesome;
            }
        }
    }
    ctx.font = fieldSize + font;
    playing = false;
}

function won() {
    alert("You win :)");
    playing = false;
}

//http://stackoverflow.com/a/14853974
// Warn if overriding existing method
if (Array.prototype.equals)
    console.warn("Overriding existing Array.prototype.equals. Possible causes: New API defines the method, there's a framework conflict or you've got double inclusions in your code.");
// attach the .equals method to Array's prototype to call it on any array
Array.prototype.equals = function (array) {
    // if the other array is a falsy value, return
    if (!array)
        return false;

    // compare lengths - can save a lot of time
    if (this.length != array.length)
        return false;

    for (var i = 0, l = this.length; i < l; i++) {
        // Check if we have nested arrays
        if (this[i] instanceof Array && array[i] instanceof Array) {
            // recurse into the nested arrays
            if (!this[i].equals(array[i]))
                return false;
        }
        else if (this[i] != array[i]) {
            // Warning - two different object instances will never be equal: {x:20} != {x:20}
            return false;
        }
    }
    return true;
}
// Hide method from for-in loops
Object.defineProperty(Array.prototype, "equals", { enumerable: false });