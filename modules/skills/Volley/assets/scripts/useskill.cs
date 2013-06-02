function Volley::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Volley.setskillbaricon(%barslot);
%schedulehandle_Volley=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Volley);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Volley.skill_Volley(%schedulehandle_Volley,%user,0);
}
}
}
