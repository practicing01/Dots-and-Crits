function Lightsaber::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Lightsaber.setskillbaricon(%barslot);
%schedulehandle_Lightsaber=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Lightsaber);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Lightsaber.skill_Lightsaber(%schedulehandle_Lightsaber,%user,0);
}
}
}
