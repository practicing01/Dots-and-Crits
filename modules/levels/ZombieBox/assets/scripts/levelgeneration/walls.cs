//calc total available space for both axis
//randomly get tiles untill accumulate total size
//randomly place tiles

function ZombieBox::pinwalltiles(%this)
{

for (%x=0;%x<DotsandCritsscene.getCount();%x++)
{
%obj=DotsandCritsscene.getObject(%x);
if (%obj.SceneGroup==30)//wall
{
%obj.setBodyType("static");
}
}

}

function ZombieBox::generatewalltiles(%this)
{

if (!$view)//need to seperate tiles into topdown & side
{

if (isObject(%this.simset_ass_walltiles))
{
for (%x=0;%x<%this.simset_ass_walltiles.getCount();%x++)
{
%ass=%this.simset_ass_walltiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_walltiles.delete();
}

%this.simset_ass_walltiles=new SimSet();

%assquery=new AssetQuery();
AssetDatabase.findAssetCategory(%assquery,"wall",false);
for (%x=0;%x<%assquery.getCount();%x++)
{
%assid=%assquery.getAsset(%x);
%ass=AssetDatabase.acquireAsset(%assid);
%moduleid=AssetDatabase.getAssetModule(%assid);

if (%moduleid.ModuleId$=%this.getName())
{
%this.simset_ass_walltiles.add(%ass);
}
else
{
AssetDatabase.releaseAsset(%ass.getAssetId());
}

}

%totalmapsize=($camsize.X*%this.mapsizescale)*($camsize.Y*%this.mapsizescale);

%totalmapsize*=10;
%totalmapsize/=100;

%simset_randomtileasses=new SimSet();

%totaltilesize=0;

while (1)
{

%randomtileass=%this.simset_ass_walltiles.getObject(getRandom(0,%this.simset_ass_walltiles.getCount()-1));

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

%walltile=new Sprite()
{
Position=%tilepos;
Size=%tilesize;
Image=%this.getName()@":"@%tileass.AssetName;
SceneLayer=%tileass.SceneLayer;
SceneGroup=%tileass.SceneGroup;
FixedAngle=true;
//BodyType="static";
};
DotsandCritsscene.add(%walltile);

%walltile.createPolygonBoxCollisionShape(%tilesize);

if (%tileass.Animation!$="")
{
%walltile.Animation=%tileass.Animation;
}

}

}
else
{

}

schedule(1000,0,"ZombieBox::pinwalltiles",%this);

}
