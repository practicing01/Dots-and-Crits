function FtA_P1::unloadass(%this)
{

AssetDatabase.releaseAsset(%this.image_sideview.getAssetId());
AssetDatabase.releaseAsset(%this.image_topdown.getAssetId());

}
