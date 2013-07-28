function ZombieBox::unloadass(%this)
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

}