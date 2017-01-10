<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="swaggybird.aspx.cs" Inherits="DomoticaProject.swaggybird" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    window.onload = function () { startGame(); };

var gamePlayer;
var gameObstacles = [];
var scores;
var background;


function startGame() {
    gameArea.start();
    gamePlayer = new component(35, 35, "images/swaggy_bird.png", 10, 120, "image");
    scores = new component("30px", "Consolas", "black", 280, 40, "text");
    background = new component(480, 270, "images/background.png", 0, 0, "image");

}

var gameArea =
{
    canvas : document.createElement("canvas"),
    start : function()
    {
        this.canvas.width = 480;
        this.canvas.height = 270;
        this.context = this.canvas.getContext("2d");
        document.body.insertBefore(this.canvas, document.body.childNodes[0]);
        this.frameNo = 0;
        this.interval = setInterval(updateGameArea, 20);

        window.addEventListener('keydown', function(e)
        {
          gameArea.key = e.keyCode;
        })
        window.addEventListener('keyup', function(e)
        {
            gameArea.key = false;
            gamePlayer.speedX = 0;
            gamePlayer.speedY = 0;
        })

    },
    clear : function()
    {
        this.context.clearRect(0, 0, this.canvas.width, this.canvas.height);
    },
    stop : function()
    {
      clearInterval(this.interval);
    }
}

function everyinterval(n)
{
  if((gameArea.frameNo / n) % 1 == 0)
  {
    return true;
  } else
  {
    return false;
  }
}

function component(width, height, color, x, y, type)
{
    this.type = type;

    if(type == "image")
    {
      this.image = new Image();
      this.image.src = color;
    }

    this.gamearea = gameArea;
    this.width = width;
    this.height = height;

    this.speedX = 0;
    this.speedY = 0;

    this.x = x;
    this.y = y;


    this.update = function()
    {
        ctx = gameArea.context;

        if(this.type == "text")
        {
          ctx.font = this.width + " " + this.height;
          ctx.fillStyle = color;
          ctx.fillText(this.text, this.x, this.y);
        } else if(this.type == "image")
        {
          ctx.drawImage(this.image, this.x, this.y, this.width, this.height);

        } else
        {
          ctx.fillStyle = color;
          ctx.fillRect(this.x, this.y, this.width, this.height);
        }

    }

    this.newPosition = function()
    {

      this.x += this.speedX;
      this.y += this.speedY;
    }

    this.crashWith = function(other_object)
    {
      var player_left = this.x;
      var player_right = this.x + (this.width);

      var player_top = this.y;
      var player_bottom = this.y + (this.height);

      var object_left = other_object.x;
      var object_right = other_object.x + (other_object.width);

      var object_top = other_object.y;
      var object_bottom = other_object.y + (other_object.height);

      var crash = true;
      if((player_top < object_top) || (player_top > object_bottom) || (player_right < object_left) || (player_left > object_right))
      {
        return false;
      } else
      {
        return true;
      }
    }
}

function updateGameArea()
{

  var x, y;
  for (i = 0; i < gameObstacles.length; i += 1)
  {
    if (gamePlayer.crashWith(gameObstacles[i]))
    {
      gameArea.stop();
      return;
    }
  }
  gameArea.clear();
  gameArea.frameNo += 1;


  if (gameArea.frameNo == 1 || everyinterval(150)) {
    x = gameArea.canvas.width;
    minHeight = 20;
    maxHeight = 200;
    height = Math.floor(Math.random()*(maxHeight-minHeight+1)+minHeight);
    minGap = 50;
    maxGap = 200;
    gap = Math.floor(Math.random()*(maxGap-minGap+1)+minGap);
    gameObstacles.push(new component(10, height, "green", x, 0));
    gameObstacles.push(new component(10, x - height - gap, "green", x, height + gap));
}

background.newPosition();
background.update();

  for (i = 0; i < gameObstacles.length; i += 1)
  {
    gameObstacles[i].x += -1;
    gameObstacles[i].update();
  }

    //gamePlayer.speedX = 0;
    //gamePlayer.speedY = 0;

    if(gameArea.key && gameArea.key == 37)
    {
      moveleft();
    }
    if(gameArea.key && gameArea.key == 38)
    {
      moveup();
    }
    if(gameArea.key && gameArea.key == 39)
    {
      moveright();
    }
    if(gameArea.key &&gameArea.key == 40)
    {
      movedown();
    }

    scores.text = "Score -> " + gameArea.frameNo;



    scores.update();
    gamePlayer.newPosition();
    gamePlayer.update();


}


function movedown()
{
  gamePlayer.speedY = 1;
}

function moveup()
{
  gamePlayer.speedY = -1;
}

function moveleft()
{
  gamePlayer.speedX = -1;
}

function moveright()
{
  gamePlayer.speedX = 1;
}

function clearmove()
{
  gamePlayer.speedX = 0;
  gamePlayer.speedY = 0;
}

</script>

  <button type="button" onmousedown="moveup()" onmouseup="clearmove()"> UP</button>
  <button type="button" onmousedown="moveleft()" onmouseup="clearmove()"> LEFT</button>
  <button type="button" onmousedown="moveright()" onmouseup="clearmove()"> RIGHT </button>
  <button type="button" onmousedown="movedown()" onmouseup="clearmove()"> DOWN </button>

</asp:Content>
