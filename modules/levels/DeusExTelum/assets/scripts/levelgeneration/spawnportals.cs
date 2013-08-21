function DeusExTelum::generatespawnportals(%this)
{

if (!$view)
{

%portal_spawn_p1=new SceneObject()
{
class="class_portal_spawn_p1";
Size="10 10";
Position=getRandom(-(($camsize.X/2)*%this.mapsizescale),(($camsize.X/2)*%this.mapsizescale))
SPC getRandom(-(($camsize.Y/2)*%this.mapsizescale),(($camsize.Y/2)*%this.mapsizescale));
BodyType="Static";
};
DotsandCritsscene.add(%portal_spawn_p1);

%portal_spawn_p2=new SceneObject()
{
class="class_portal_spawn_p2";
Size="10 10";
Position=getRandom(-(($camsize.X/2)*%this.mapsizescale),(($camsize.X/2)*%this.mapsizescale))
SPC getRandom(-(($camsize.Y/2)*%this.mapsizescale),(($camsize.Y/2)*%this.mapsizescale));
BodyType="Static";
};
DotsandCritsscene.add(%portal_spawn_p2);

}
else
{

}

}
