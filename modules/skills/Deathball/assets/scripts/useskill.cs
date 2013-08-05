function Deathball::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Deathball.setskillbaricon(%barslot);
%schedulehandle_Deathball=new ScriptObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Deathball);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Deathball.skill_Deathball(%schedulehandle_Deathball,%user,0);
}
}
}
