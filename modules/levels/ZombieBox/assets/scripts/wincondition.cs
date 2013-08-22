//change ZombieBox to your module name
//you can code different win conditions here

if (isObject($schedule_wincondition))
{
$schedule_wincondition.delete();
}

$schedule_wincondition=new ScriptObject()
{
player1score="0";
player2score="0";
schedulehandle="0";
};

function ZombieBox::checkforwincondition(%this)
{
if (isObject(gui_text_player1score))
{

%player1=$players.getObject(0);
%player2=$players.getObject(1);

if (!isObject(%player1.sprite)){return;}

if (%player1.health<=0)
{
echo("player 2 scored!");
%player1.health=100;
$schedule_wincondition.player2score++;
gui_text_player2score.setText($schedule_wincondition.player2score);
%this.healthdisplay(0,%player1.health);
}

if ($schedule_wincondition.player1score>=10)
{
echo("player 1 won!");
schedule(0,0,"gui_pausemenu::returntomainmenu");
return;
}

if (!$singleplayer)
{
if (%player2.health<=0)
{
echo("player 1 scored!");
%player2.health=100;
$schedule_wincondition.player1score++;
gui_text_player1score.setText($schedule_wincondition.player1score);
%this.healthdisplay(1,%player2.health);
}
}

if ($schedule_wincondition.player2score>=10)
{
echo("player 2 won!");
schedule(0,0,"gui_pausemenu::returntomainmenu");
return;
}

}

if (%this.livezombiecount<=0)
{

schedule(0,0,"gui_pausemenu::returntomainmenu");
return;

}

$schedule_wincondition.schedulehandle=schedule(1000,0,"ZombieBox::checkforwincondition",%this);
}
