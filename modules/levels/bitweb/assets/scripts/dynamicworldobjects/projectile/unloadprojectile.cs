function bitweb::unloadprojectile(%this)
{

ThrowKnife.unloadskill();

AssetDatabase.releaseAsset(%this.projectileass.getAssetId());

}
