function SummonTonberry::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
SummonTonberry.setskillbaricon(%barslot);
%schedulehandle_SummonTonberry=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_SummonTonberry);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
SummonTonberry.skill_SummonTonberry(%schedulehandle_SummonTonberry,%user,0);
}
}
}
