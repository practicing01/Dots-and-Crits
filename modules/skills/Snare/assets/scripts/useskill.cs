function Snare::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Snare.setskillbaricon(%barslot);
%schedulehandle_Snare=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Snare);
%barslot.cdschedule=schedule(10000,0,"readyskillslot",%barslot);
Snare.skill_Snare(%schedulehandle_Snare,%user,0);
}
}
}
