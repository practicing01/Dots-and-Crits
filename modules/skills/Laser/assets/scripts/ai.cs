function Laser::ai(%this,%barslot)
{

if (!$playerssplit)
{
%player1=$players.getObject(0);
%player2=$players.getObject(1);

if//x distance > y distance
(
mAbs(%player1.sprite.Position.X-%player2.sprite.Position.X)
>
mAbs(%player1.sprite.Position.Y-%player2.sprite.Position.Y)
)
{
if (%player1.sprite.Position.X<%player2.sprite.Position.X)
{
moveplayerleft(1);
moveplayerleftstop(1);
}
else if (%player1.sprite.Position.X>%player2.sprite.Position.X)
{
moveplayerright(1);
moveplayerrightstop(1);
}
}
else
{
if (%player1.sprite.Position.Y<%player2.sprite.Position.Y)
{
moveplayerdown(1);
moveplayerdownstop(1);
}
else if (%player1.sprite.Position.Y>%player2.sprite.Position.Y)
{
moveplayerup(1);
moveplayerupstop(1);
}
}

%this.useskill(1,%barslot);
}

}
