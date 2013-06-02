function space::setmenuiconvisible()
{
if (isObject($levelmenuicon))
{
$levelmenuicon.safeDelete();
}

%ass=AssetDatabase.acquireAsset("space:image_menuicon");

$levelmenuicon=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="space:image_menuicon";
Visible="true";
SceneLayer="16";
};
DotsandCritsscene.add($levelmenuicon);

AssetDatabase.releaseAsset(%ass.getAssetId());
}
