function class_bitspider::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player"&&!%object.isimmune)//check for immunity
{

schedule(0,0,"gui_pausemenu::returntomainmenu");

}
else if (%object.class$="class_survivor")
{



}

}
