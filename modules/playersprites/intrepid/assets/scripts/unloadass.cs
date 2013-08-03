function intrepid::unloadass(%this)
{

AssetDatabase.releaseAsset(%this.image_topdown.getAssetId());
AssetDatabase.releaseAsset(%this.image_sideview.getAssetId());

}
