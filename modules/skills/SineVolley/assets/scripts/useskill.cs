function SineVolley::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
SineVolley.setskillbaricon(%barslot);
%schedulehandle_SineVolley=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_SineVolley);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
SineVolley.skill_SineVolley(%schedulehandle_SineVolley,%user,0);
}
}
}
