function Cloak::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Cloak.setskillbaricon(%barslot);
/*%schedulehandle_Cloak=new ScriptObject()//since cloak toggles itself and isn't timed, don't need a schedule
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Cloak);*/
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Cloak.skill_Cloak(0,%user,0);
}
}
}
