function class_Bombermine::onCollision(%this,%object,%collisionDetails)
{

if (%object.SceneGroup!=27)//portals :D
{
%this.playAnimation("Bombermine:anim_explode");
}

}
