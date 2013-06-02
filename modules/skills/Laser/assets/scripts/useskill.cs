function Laser::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Laser.setskillbaricon(%barslot);
%schedulehandle_Laser=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Laser);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Laser.skill_Laser(%schedulehandle_Laser,%user,0);
}
}
}
