function bitweb::loadimmunity(%this)
{

%this.immunityass=AssetDatabase.acquireAsset("bitweb:image_immunity");

%immunity=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%this.immunityass);
Image="bitweb:image_immunity";
SceneLayer=16;
GravityScale=0;
SceneGroup=3;
BodyType="static";
class="class_immunity";
parentbitweb=%this;
CollisionCallback=true;
used=false;
};

%immunity.playAnimation("bitweb:anim_immunity_idle");
%immunity.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

%colshapeindex=%immunity.createPolygonBoxCollisionShape(%immunity.Size);
%immunity.setCollisionGroups(0,1);//0/1 players
%immunity.setCollisionShapeIsSensor(%colshapeindex,true);

DotsandCritsscene.add(%immunity);
%this.immunity=%immunity;

}
