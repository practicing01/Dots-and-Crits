function class_deusextelum_goal::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
echo("reached goal!");
schedule(0,0,"gui_pausemenu::returntomainmenu");
}

}
