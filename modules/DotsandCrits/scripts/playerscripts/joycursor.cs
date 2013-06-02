%ass=AssetDatabase.acquireAsset("DotsandCrits:image_joycursor");

$joycursor=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="DotsandCrits:image_joycursor";
Visible="true";
};
DotsandCritsscene.add($joycursor);

AssetDatabase.releaseAsset(%ass.getAssetId());

//$joycursor.playAnimation("DotsandCrits:anim_joycursor");
