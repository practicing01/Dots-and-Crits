function Shield::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Shield.setskillbaricon(%barslot);
%schedulehandle_Shield=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Shield);
%barslot.cdschedule=schedule(30000,0,"readyskillslot",%barslot);
Shield.skill_Shield(%schedulehandle_Shield,%user,0);
}
}
}
