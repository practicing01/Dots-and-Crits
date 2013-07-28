function ZombieBox::generateworldlimits(%this)
{

if (!$view)
{

%toplimit=new SceneObject()
{
size=$camsize.X*%this.mapsizescale SPC 10;
Position=0 SPC (($camsize.Y/2)*%this.mapsizescale)+5;
BodyType="static";
SceneGroup="30";
};

%toplimit.createPolygonBoxCollisionShape(%toplimit.size);
DotsandCritsscene.add(%toplimit);

%bottomlimit=new SceneObject()
{
size=$camsize.X*%this.mapsizescale SPC 10;
Position=0 SPC -((($camsize.Y/2)*%this.mapsizescale)+5);
BodyType="static";
SceneGroup="30";
};

%bottomlimit.createPolygonBoxCollisionShape(%bottomlimit.size);
DotsandCritsscene.add(%bottomlimit);

%leftlimit=new SceneObject()
{
size=10 SPC $camsize.Y*%this.mapsizescale;
Position=-((($camsize.X/2)*%this.mapsizescale)+5) SPC 0;
BodyType="static";
SceneGroup="30";
};

%leftlimit.createPolygonBoxCollisionShape(%leftlimit.size);
DotsandCritsscene.add(%leftlimit);

%rightlimit=new SceneObject()
{
size=10 SPC $camsize.Y*%this.mapsizescale;
Position=((($camsize.X/2)*%this.mapsizescale)+5) SPC 0;
BodyType="static";
SceneGroup="30";
};

%rightlimit.createPolygonBoxCollisionShape(%rightlimit.size);
DotsandCritsscene.add(%rightlimit);

}
else
{

}

}
