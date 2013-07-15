function class_bitwebprojectile::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player"&&!%this.used)
{

%object.ammo++;
%this.Visible=false;
%this.used=true;
//%this.clearCollisionShapes();
//%this.setCollisionSuppress(true);

Audiere_Reset(%this.parentbitweb.sound_acquireammo);
Audiere_Play(%this.parentbitweb.sound_acquireammo,0,1.0);

//schedule(0,0,"class_projectile::clearcolshapes",%this);
}

}
