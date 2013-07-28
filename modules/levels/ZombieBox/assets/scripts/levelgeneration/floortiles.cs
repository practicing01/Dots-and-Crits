function ZombieBox::generatefloortiles(%this)
{

if (!$view)//need to seperate tiles into topdown & side
{

if (isObject(%this.simset_ass_floortiles))
{
for (%x=0;%x<%this.simset_ass_floortiles.getCount();%x++)
{
%ass=%this.simset_ass_floortiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_floortiles.delete();
}

%this.simset_ass_floortiles=new SimSet();

%assquery=new AssetQuery();
AssetDatabase.findAssetCategory(%assquery,"floortile",false);
for (%x=0;%x<%assquery.getCount();%x++)
{
%assid=%assquery.getAsset(%x);
%ass=AssetDatabase.acquireAsset(%assid);
%moduleid=AssetDatabase.getAssetModule(%assid);

if (%moduleid.ModuleId$=%this.getName())
{
%this.simset_ass_floortiles.add(%ass);
}
else
{
AssetDatabase.releaseAsset(%ass.getAssetId());
}

}

%tileass=%this.simset_ass_floortiles.getObject(0);//they should all have the same size so just get the first

%tilesize=ScaleAssSizeVectorToCam(%tileass);

%xmin=-(($camsize.X*%this.mapsizescale)/2);
%xmax=($camsize.X*%this.mapsizescale)/2;

%ymin=-(($camsize.Y*%this.mapsizescale)/2);
%ymax=($camsize.Y*%this.mapsizescale)/2;

%xstep=%tilesize.X;
%ystep=%tilesize.Y;

for (%y=%ymin+(%ystep/2);%y<%ymax;%y+=%ystep)
{

for (%x=%xmin+(%xstep/2);%x<%xmax;%x+=%xstep)
{

%randomtileass=%this.simset_ass_floortiles.getObject(getRandom(0,%this.simset_ass_floortiles.getCount()-1));

%floortile=new Sprite()
{
Position=%x SPC %y;
Size=%tilesize;
Image=%randomtileass.Image;
SceneLayer=%randomtileass.SceneLayer;
SceneGroup=%randomtileass.SceneGroup;
Animation=%randomtileass.Animation;
BodyType="static";
};
DotsandCritsscene.add(%floortile);

}

}

}
else
{

}

}
