function M4Carbine::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
M4Carbine.setskillbaricon(%barslot);
/*%schedulehandle_M4Carbine=new SimObject()//since M4Carbine toggles itself and isn't timed, don't need a schedule
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_M4Carbine);*/
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
M4Carbine.skill_M4Carbine(0,%user,0);
}
}
}
