//schedule an animation.  cancel the schedule on loadlevel()

function ZombieBox::setmenuiconvisible(%this)//change ZombieBox to your module name
{
if (isObject($levelmenuicon))
{
$levelmenuicon.safeDelete();
}

%ass=AssetDatabase.acquireAsset("ZombieBox:image_menuicon");

$levelmenuicon=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="ZombieBox:image_menuicon";
Visible="true";
SceneLayer="16";
};
DotsandCritsscene.add($levelmenuicon);

AssetDatabase.releaseAsset(%ass.getAssetId());
}
