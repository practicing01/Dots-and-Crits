function bitweb::loadsurvivor(%this)
{

%this.survivorass=AssetDatabase.acquireAsset("bitweb:image_survivor");

%survivor=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%this.survivorass);
Image="bitweb:image_survivor";
SceneLayer=16;
GravityScale=0;
SceneGroup=26;
BodyType="static";
class="class_survivor";
parentbitweb=%this;
CollisionCallback=true;
used=false;
};

%survivor.playAnimation("bitweb:anim_survivor_idle");
%survivor.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

%survivor.createPolygonBoxCollisionShape(%survivor.Size);
%survivor.setCollisionGroups(0,1,25);//0/1 players, 25 npc
%survivor.setCollisionShapeIsSensor(0,true);

DotsandCritsscene.add(%survivor);
%this.survivor=%survivor;

}
