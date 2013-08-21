function DeusExTelum::unloadass(%this)
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

if (isObject(%this.simset_ass_walltiles))
{
for (%x=0;%x<%this.simset_ass_walltiles.getCount();%x++)
{
%ass=%this.simset_ass_walltiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_walltiles.delete();
}

if (isObject(%this.simset_ass_decaltiles))
{
for (%x=0;%x<%this.simset_ass_decaltiles.getCount();%x++)
{
%ass=%this.simset_ass_decaltiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_decaltiles.delete();
}

if (isObject(%this.simset_ass_dwotiles))
{
for (%x=0;%x<%this.simset_ass_dwotiles.getCount();%x++)
{
%ass=%this.simset_ass_dwotiles.getObject(%x);
AssetDatabase.releaseAsset(%ass.getAssetId());
}
%this.simset_ass_dwotiles.delete();
}

AssetDatabase.releaseAsset(%this.ass_mech.getAssetId());

}