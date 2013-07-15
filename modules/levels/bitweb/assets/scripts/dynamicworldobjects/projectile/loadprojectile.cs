function bitweb::loadprojectile(%this)
{
ThrowKnife.onlevelload();

%this.projectileass=AssetDatabase.acquireAsset("bitweb:image_projectile");

%projectile=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%this.projectileass);
Image="bitweb:image_projectile";
SceneLayer=16;
GravityScale=0;
SceneGroup=3;
BodyType="static";
class="class_bitwebprojectile";
parentbitweb=%this;
CollisionCallback=true;
used=false;
};

%projectile.playAnimation("bitweb:anim_projectile_idle");
%projectile.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

%colshapeindex=%projectile.createPolygonBoxCollisionShape(%projectile.Size);
%projectile.setCollisionGroups(0,1);//0/1 players
%projectile.setCollisionShapeIsSensor(%colshapeindex,true);

DotsandCritsscene.add(%projectile);
%this.projectile=%projectile;

}
