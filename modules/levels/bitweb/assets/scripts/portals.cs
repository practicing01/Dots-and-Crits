//need to mod this in the future to allow projectiles to go through (need to give them new destinations)
//as well as other objects (remember to mod the taml file's collision groups)

function class_portal::onCollision(%this,%object,%collisionDetails)
{
%object.Position=%this.ToPos;
}
