function Lightsaber2::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Lightsaber2.setskillbaricon(%barslot);
%schedulehandle_Lightsaber2=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Lightsaber2);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Lightsaber2.skill_Lightsaber2(%schedulehandle_Lightsaber2,%user,0);
}
}
}
