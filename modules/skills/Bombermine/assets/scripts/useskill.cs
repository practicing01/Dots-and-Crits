function Bombermine::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Bombermine.setskillbaricon(%barslot);
%schedulehandle_Bombermine=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Bombermine);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Bombermine.skill_Bombermine(%schedulehandle_Bombermine,%user,0);
}
}
}
