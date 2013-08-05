function Speedboof::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Speedboof.setskillbaricon(%barslot);
%schedulehandle_Speedboof=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Speedboof);
%barslot.cdschedule=schedule(10000,0,"readyskillslot",%barslot);
Speedboof.skill_Speedboof(%schedulehandle_Speedboof,%user,0);
}
}
}
