function DeusExTelum::spawngoal(%this)
{

if (!$view)
{

%goal=new Sprite()
{
class="class_goal";
Size=ScaleAssSizeVectorToCam(%this.ass_goal);
Position=getRandom(-(($camsize.X/2)*%this.mapsizescale),(($camsize.X/2)*%this.mapsizescale))
SPC getRandom(-(($camsize.Y/2)*%this.mapsizescale),(($camsize.Y/2)*%this.mapsizescale));
BodyType="Static";
Image="DeusExTelum:image_goal";
Animation="DeusExTelum:anim_goal_idle";
SceneLayer=16;
SceneGroup=30;
};
DotsandCritsscene.add(%goal);

%goal.createPolygonBoxCollisionShape(%goal.Size);

}
else
{

}

}
