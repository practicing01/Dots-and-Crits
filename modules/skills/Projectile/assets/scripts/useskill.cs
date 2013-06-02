function Projectile::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Projectile.setskillbaricon(%barslot);
%schedulehandle_Projectile=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_Projectile);
%barslot.cdschedule=schedule(250,0,"readyskillslot",%barslot);
Projectile.skill_Projectile(%schedulehandle_Projectile,%user,0);
}
}
}
