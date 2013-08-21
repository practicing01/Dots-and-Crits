function class_m4carbineammo::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.ammo+=10;
%this.safeDelete();
}

}

function class_m4carbineammo::updatehealth(%this)
{
return;
}
