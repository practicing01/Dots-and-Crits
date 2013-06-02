function Cloak::skill_Cloak(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
%player.cancast=true;
keycleanup(%user);
//////////////////
%customfieldobj=Cloak.customplayerfields.getObject(%user);

if (%customfieldobj.cloakstate)
{
%customfieldobj.cloakstate=false;
%player.sprite.setSpriteBlendAlpha(1);
}
else
{
%customfieldobj.cloakstate=true;
%player.sprite.setSpriteBlendAlpha(0);
}
//////////////////
}
