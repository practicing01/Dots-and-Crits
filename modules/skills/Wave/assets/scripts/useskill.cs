function Wave::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Wave.setskillbaricon(%barslot);
%schedulehandle_Wave=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Wave);
%barslot.cdschedule=schedule(250,0,"readyskillslot",%barslot);
Wave.skill_Wave(%schedulehandle_Wave,%user,0);
}
}
}
