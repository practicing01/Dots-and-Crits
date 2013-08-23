function class_visibleparticle::onCollision(%this,%object,%collisionDetails)
{

if (%object.SceneGroup==30)//walls
{
%this.safeDelete();
}
else if (%object.SceneGroup==25)//npc's
{
if (%object.health>0&&%object.class$="class_mech")
{
echo("spotted by mech!");
schedule(0,0,"gui_pausemenu::returntomainmenu");
}
}

}
