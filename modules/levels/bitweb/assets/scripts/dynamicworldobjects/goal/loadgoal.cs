function bitweb::loadgoal(%this)
{

%this.goalass=AssetDatabase.acquireAsset("bitweb:image_goal");

%goal=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%this.goalass);
Image="bitweb:image_goal";
SceneLayer=16;
GravityScale=0;
SceneGroup=26;
BodyType="static";
class="class_goal";
parentbitweb=%this;
CollisionCallback=true;
};

%goal.playAnimation("bitweb:anim_goal_idle");
%goal.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

%goal.createPolygonBoxCollisionShape(%goal.Size);
%goal.setCollisionGroups(0,1);//0/1 players
%goal.setCollisionShapeIsSensor(0,true);

DotsandCritsscene.add(%goal);
%this.goal=%goal;

}
