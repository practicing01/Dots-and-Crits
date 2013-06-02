function Teleport::ai(%this,%barslot)
{
   
%player=$players.getObject(1);

%objlist=DotsandCritsscene.pickArea(
%player.sprite.Position.X-(%player.sprite.getWidth()),
%player.sprite.Position.Y+(%player.sprite.getHeight()),
%player.sprite.Position.X+(%player.sprite.getWidth()),
%player.sprite.Position.Y-(%player.sprite.getHeight()),
BIT(28),BIT(0),"oobb");//28 & 29 being projectiles

//if there're projectiles near, teleport out of the way
if (getWordCount(%objlist))//there is a projectile nearby
{

%dir=getRandom(0,3);//randomly choose the direction to teleport to

if (%dir==0)
{
moveplayerup(1);
moveplayerupstop(1);
}
else if (%dir==1)
{
moveplayerdown(1);
moveplayerdownstop(1);
}
else if (%dir==2)
{
moveplayerleft(1);
moveplayerleftstop(1);
}
else if (%dir==3)
{
moveplayerright(1);
moveplayerrightstop(1);
}

%this.useskill(1,%barslot);

}

}
