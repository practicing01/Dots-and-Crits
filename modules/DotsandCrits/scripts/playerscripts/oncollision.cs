function class_player::onCollision(%this,%object,%collisionDetails)
{
%player=$players.getObject(%this.playerindex);
%player.canmove=false;
%player.canjump=true;
%player.collidingobject=%object;
}//end class_player::onCollision()
