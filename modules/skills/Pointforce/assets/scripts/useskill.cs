function Pointforce::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Pointforce.setskillbaricon(%barslot);
%schedulehandle_Pointforce=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Pointforce);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Pointforce.skill_Pointforce(%schedulehandle_Pointforce,%user,0);
}
}
}
