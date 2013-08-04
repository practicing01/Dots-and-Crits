function /*processplayercollision(%playerindex)*/class_player::onUpdate(%this)
{
%player=$players.getObject(%this.playerindex);

if (!%player.canmove)
{

%objlist=DotsandCritsscene.pickArea(
%player.sprite.Position.X-(%player.sprite.getWidth()/2),
%player.sprite.Position.Y+(%player.sprite.getHeight()/2),
%player.sprite.Position.X+(%player.sprite.getWidth()/2),
%player.sprite.Position.Y-(%player.sprite.getHeight()/2),
bit(!%this.playerindex)|bit(25)|bit(26)|bit(30),"","collision");//30 being walls, 25=npc, 26=dynamic world object
%colliding=false;
for (%x=0;%x<getWordCount(%objlist);%x++)
{
%obj=getWord(%objlist,%x);
if (%obj==%player.collidingobject){%colliding=true;break;}
}//end for

/*if (getWordCount(%objlist))
{
%colliding=true;
}*/

if (!%colliding)
{

%player.canmove=true;
restartmove(%player);

}//end not colliding
}
else
{

if (%player.sprite.LinearVelocity.X<%player.speed||%player.sprite.LinearVelocity.Y<%player.speed)
{
restartmove(%player);
}

}

//$processplayerschedule=schedule(250,0,"processplayercollision");

}//end re-establish linear velocity

//$processplayerschedule=schedule(250,0,"processplayercollision");
