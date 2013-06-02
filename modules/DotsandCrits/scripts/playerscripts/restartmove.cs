function restartmove(%handle_player)
{

if (%handle_player.keysdown[0])
{
%handle_player.sprite.setLinearVelocityY(%handle_player.speed);
}
else if (%handle_player.keysdown[1])
{
%handle_player.sprite.setLinearVelocityY(-%handle_player.speed);
}

if (%handle_player.keysdown[2])
{
%handle_player.sprite.setLinearVelocityX(-%handle_player.speed);
}
else if (%handle_player.keysdown[3])
{
%handle_player.sprite.setLinearVelocityX(%handle_player.speed);
}

}
