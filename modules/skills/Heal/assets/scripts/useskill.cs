function Heal::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Heal.setskillbaricon(%barslot);
%schedulehandle_Heal=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Heal);
%barslot.cdschedule=schedule(10000,0,"readyskillslot",%barslot);
Heal.skill_Heal(%schedulehandle_Heal,%user,0);
}
}
}
