function deathballvalley::setmenuiconvisible(%this)
{
if (isObject($levelmenuicon))
{
$levelmenuicon.safeDelete();
}

%ass=AssetDatabase.acquireAsset("deathballvalley:image_menuicon");

$levelmenuicon=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="deathballvalley:image_menuicon";
Visible="true";
SceneLayer="16";
};
DotsandCritsscene.add($levelmenuicon);

AssetDatabase.releaseAsset(%ass.getAssetId());
}
