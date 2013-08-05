function ThrowKnife::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
ThrowKnife.setskillbaricon(%barslot);
%schedulehandle_ThrowKnife=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_ThrowKnife);
%barslot.cdschedule=schedule(250,0,"readyskillslot",%barslot);
ThrowKnife.skill_ThrowKnife(%schedulehandle_ThrowKnife,%user,0);
}
}
}
