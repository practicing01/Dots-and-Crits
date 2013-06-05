function Dot::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=1;
Dot.setskillbaricon(%barslot);
%schedulehandle_Dot=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Dot);
%barslot.cdschedule=schedule(10000,0,"readyskillslot",%barslot);
Dot.skill_Dot(%schedulehandle_Dot,%user,0);
}
}
}
