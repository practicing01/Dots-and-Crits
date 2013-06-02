function Grab::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Grab.setskillbaricon(%barslot);
%schedulehandle_Grab=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Grab);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Grab.skill_Grab(%schedulehandle_Grab,%user,0);
}
}
}
