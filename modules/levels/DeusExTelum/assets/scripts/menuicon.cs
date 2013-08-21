//schedule an animation.  cancel the schedule on loadlevel()

function DeusExTelum::setmenuiconvisible(%this)//change DeusExTelum to your module name
{
if (isObject($levelmenuicon))
{
$levelmenuicon.safeDelete();
}

%ass=AssetDatabase.acquireAsset("DeusExTelum:image_menuicon");

$levelmenuicon=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="DeusExTelum:image_menuicon";
Visible="true";
SceneLayer="16";
};
DotsandCritsscene.add($levelmenuicon);

AssetDatabase.releaseAsset(%ass.getAssetId());
}
