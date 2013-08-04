function ZombieBox::generatenpcs(%this)
{

if (!$view)//need to seperate tiles into topdown & side
{

if (isObject(%this.simset_ass_npctiles))
{
for (%x=0;%x<%this.simset_ass_npctiles.getCount();%x++)
{
%ass=%this.simset_ass_npctiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_npctiles.delete();
}

%this.simset_ass_npctiles=new SimSet();

%assquery=new AssetQuery();
AssetDatabase.findAssetCategory(%assquery,"npc",false);
for (%x=0;%x<%assquery.getCount();%x++)
{
%assid=%assquery.getAsset(%x);
%ass=AssetDatabase.acquireAsset(%assid);
%moduleid=AssetDatabase.getAssetModule(%assid);

if (%moduleid.ModuleId$=%this.getName())
{
%this.simset_ass_npctiles.add(%ass);
}
else
{
AssetDatabase.releaseAsset(%ass.getAssetId());
}

}

%totalmapsize=($camsize.X*%this.mapsizescale)*($camsize.Y*%this.mapsizescale);

%totalmapsize*=4;
%totalmapsize/=100;

%simset_randomtileasses=new SimSet();

%totaltilesize=0;

while (1)
{

%randomtileass=%this.simset_ass_npctiles.getObject(getRandom(0,%this.simset_ass_npctiles.getCount()-1));

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

%npctile=new Sprite()
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
FixedAngle=true;
LinearDamping=1;
parentzombiebox=%this;
};
DotsandCritsscene.add(%npctile);

if (%tileass.CreateCollisionShape$="true")
{

%shapeindex=%npctile.createPolygonBoxCollisionShape(%tilesize);

if (%tileass.IsSensor$="true")
{

%npctile.setCollisionShapeIsSensor(%shapeindex,true);

}

}

if (%tileass.Animation!$="")
{
%npctile.Animation=%tileass.Animation;
}

}

%this.livezombiecount=%simset_randomtileasses.getCount();

if (isObject(gui_text_livezombiecount))
{
gui_text_livezombiecount.setText(%this.livezombiecount);
}

}
else
{

}

}
