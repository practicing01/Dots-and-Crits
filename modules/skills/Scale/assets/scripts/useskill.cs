function Scale::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Scale.setskillbaricon(%barslot);
%schedulehandle_Scale=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Scale);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Scale.skill_Scale(%schedulehandle_Scale,%user,0);
}
}
}
