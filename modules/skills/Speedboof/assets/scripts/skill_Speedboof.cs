function Speedboof::skill_Speedboof(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

if (%iteration==0)
{
setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////
//should add nice fancy spell effect anim
}
else if (%iteration==1)//give it at least 1 second of casting animation
{
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
}

if (%iteration<10)
{

if (%player.speed<$normalplayerspeed*2){%player.speed+=$normalplayerspeed;}

restartmove(%player);

}
else if (%iteration>=10)
{
%player.speed-=$normalplayerspeed;
if (%player.speed<0){%player.speed=0;}

restartmove(%player);

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}
%iteration++;
%scheduleobject.schedulehandle=schedule(1000,0,"Speedboof::skill_Speedboof",%this,%scheduleobject,%user,%iteration);
}
