function Teleport::skill_teleport(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////
if (%player.curdir==0)//up
{
%player.sprite.Position.Y+=25;
}
else if (%player.curdir==1)//down
{
%player.sprite.Position.Y-=25;
}
else if (%player.curdir==2)//left
{
%player.sprite.Position.X-=25;
}
else if (%player.curdir==3)//right
{
%player.sprite.Position.X+=25;
}
//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
