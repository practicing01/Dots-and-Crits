function ScatterVolley::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
ScatterVolley.setskillbaricon(%barslot);
%schedulehandle_ScatterVolley=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_ScatterVolley);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
ScatterVolley.skill_ScatterVolley(%schedulehandle_ScatterVolley,%user,0);
}
}
}
