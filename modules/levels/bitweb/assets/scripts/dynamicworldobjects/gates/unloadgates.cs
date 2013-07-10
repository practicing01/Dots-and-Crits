function bitweb::unloadgates(%this)
{

AssetDatabase.releaseAsset(%this.gateass.getAssetId());

for (%x=0;%x<%this.simset_gates.getCount();%x++)
{
%tile=%this.simset_gates.getObject(%x);
%tile.upgate.safeDelete();
%tile.downgate.safeDelete();
%tile.leftgate.safeDelete();
%tile.rightgate.safeDelete();
}

%this.simset_gates.deleteObjects();
%this.simset_gates.delete();

}
