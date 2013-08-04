function catacombs::setmenuiconvisible(%this)//change catacombs to your module name
{
if (isObject($levelmenuicon))
{
$levelmenuicon.safeDelete();
}

%ass=AssetDatabase.acquireAsset("catacombs:image_menuicon");

$levelmenuicon=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="catacombs:image_menuicon";
Visible="true";
SceneLayer="16";
};
DotsandCritsscene.add($levelmenuicon);

AssetDatabase.releaseAsset(%ass.getAssetId());
}
