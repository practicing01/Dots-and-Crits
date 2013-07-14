function class_infected::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player"&&!%object.isimmune)//check for immunity
{

schedule(0,0,"gui_pausemenu::returntomainmenu");

}

}
