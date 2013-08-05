function Melee::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=2;//melee :)
Melee.setskillbaricon(%barslot);
%schedulehandle_Melee=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Melee);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Melee.skill_Melee(%schedulehandle_Melee,%user,0);
}
}
}
