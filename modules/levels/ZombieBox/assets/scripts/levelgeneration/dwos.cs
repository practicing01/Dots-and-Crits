function ZombieBox::generatedwotiles(%this)
{

if (!$view)//need to seperate tiles into topdown & side
{

if (isObject(%this.simset_ass_dwotiles))
{
for (%x=0;%x<%this.simset_ass_dwotiles.getCount();%x++)
{
%ass=%this.simset_ass_dwotiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_dwotiles.delete();
}

%this.simset_ass_dwotiles=new SimSet();

%assquery=new AssetQuery();
AssetDatabase.findAssetCategory(%assquery,"dwo",false);
for (%x=0;%x<%assquery.getCount();%x++)
{
%assid=%assquery.getAsset(%x);
%ass=AssetDatabase.acquireAsset(%assid);
%moduleid=AssetDatabase.getAssetModule(%assid);

if (%moduleid.ModuleId$=%this.getName())
{
%this.simset_ass_dwotiles.add(%ass);
}
else
{
AssetDatabase.releaseAsset(%ass.getAssetId());
}

}

%totalmapsize=($camsize.X*%this.mapsizescale)*($camsize.Y*%this.mapsizescale);

%totalmapsize*=10;//get 25% of the mapsize
%totalmapsize/=100;

%simset_randomtileasses=new SimSet();

%totaltilesize=0;

while (1)
{

%randomtileass=%this.simset_ass_dwotiles.getObject(getRandom(0,%this.simset_ass_dwotiles.getCount()-1));

%script_object=new ScriptObject()
{
randomtileass=%randomtileass;
};

%simset_randomtileasses.add(%script_object);

%tilesize=ScaleAssSizeVectorToCam(%randomtileass);

%totaltilesize+=%tilesize.X*%tilesize.Y;

if (%totaltilesize>=%totalmapsize){break;}

}

for (%x=0;%x<%simset_randomtileasses.getCount();%x++)
{
%script_object=%simset_randomtileasses.getObject(%x);
%tileass=%script_object.randomtileass;
%tilesize=ScaleAssSizeVectorToCam(%tileass);

%tilepos=getRandom(-((($camsize.X/2)*%this.mapsizescale)+(%tilesize.X/2)),(($camsize.X/2)*%this.mapsizescale)-(%tilesize.X/2))
SPC getRandom(-((($camsize.Y/2)*%this.mapsizescale)+(%tilesize.Y/2)),(($camsize.Y/2)*%this.mapsizescale)-(%tilesize.Y/2));

%dwotile=new Sprite()
{
Position=%tilepos;
Size=%tilesize;
Image=%this.getName()@":"@%tileass.AssetName;
SceneLayer=%tileass.SceneLayer;
SceneGroup=%tileass.SceneGroup;
class=%tileass.ObjectClass;
CollisionGroups=%tileass.CollisionGroups;
CollisionCallback=%tileass.CollisionCallback;
BlendColor=%tileass.BlendColor;
LinearDamping=%tileass.LinearDamping;
health=100;
};
DotsandCritsscene.add(%dwotile);

if (%tileass.CreateCollisionShape$="true")
{

%shapeindex=%dwotile.createPolygonBoxCollisionShape(%tilesize);

if (%tileass.IsSensor$="true")
{

%dwotile.setCollisionShapeIsSensor(%shapeindex,true);

}

}

if (%tileass.Animation!$="")
{
%dwotile.Animation=%tileass.Animation;
}

}

}
else
{

}

}
