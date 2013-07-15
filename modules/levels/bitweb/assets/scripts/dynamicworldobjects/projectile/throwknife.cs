function bitweb::throwknife(%this,%user)
{

%player=$players.getObject(%user);

if (isObject(%player.sprite)&&%player.sprite.ammo>0)
{

Audiere_Reset(%this.sound_gunshot);
Audiere_Play(%this.sound_gunshot,0,1.0);

%player.sprite.ammo--;

%schedulehandle_ThrowKnife=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_ThrowKnife);

ThrowKnife.skill_ThrowKnife(%schedulehandle_ThrowKnife,%user,0);

}

}

GlobalActionMap.bindCmd(keyboard,"f","bitweb::throwknife($bitwebhandle,0);","");
