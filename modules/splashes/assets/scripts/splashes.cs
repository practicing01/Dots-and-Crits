function splashes::create(%this)
{

%ass=AssetDatabase.acquireAsset("DotsandCrits:image_blackscreen");

%bg=new Sprite(sprite_blackscreen)
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="DotsandCrits:image_blackscreen";
Visible="false";
};
DotsandCritsscene.add(%bg);

AssetDatabase.releaseAsset(%ass.getAssetId());

%ass=AssetDatabase.acquireAsset("splashes:image_mourningdovesoftbg");

%mdsbg=new Sprite(sprite_mdsbg)
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="splashes:image_mourningdovesoftbg";
Visible="false";
};
DotsandCritsscene.add(%mdsbg);

AssetDatabase.releaseAsset(%ass.getAssetId());

%ass=AssetDatabase.acquireAsset("splashes:image_mourningdovesoftfg");

%mdsfg=new Sprite(sprite_mdsfg)
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="splashes:image_mourningdovesoftfg";
Visible="false";
};
DotsandCritsscene.add(%mdsfg);

AssetDatabase.releaseAsset(%ass.getAssetId());

%ass=AssetDatabase.acquireAsset("splashes:image_mourningdovesoftsky");

%mdssky=new Sprite(sprite_mdssky)
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="splashes:image_mourningdovesoftsky";
Visible="false";
};
DotsandCritsscene.add(%mdssky);

AssetDatabase.releaseAsset(%ass.getAssetId());

%ass=AssetDatabase.acquireAsset("splashes:image_mourningdovesoftsun");

//make composite sprite with sun & rays in it
%compsprite_sun=new CompositeSprite(compsprite_sun)
{
class="class_sun";
};
%compsprite_sun.SetBatchLayout("off");
%compsprite_sun.SetBatchSortMode("z");
%compsprite_sun.SetBatchIsolated(true);
%compsprite_sun.addSprite();
%compsprite_sun.setSpriteLocalPosition(0,0);
%compsprite_sun.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%compsprite_sun.setSpriteImage("splashes:image_mourningdovesoftsun",0);
%compsprite_sun.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

%ass=AssetDatabase.acquireAsset("splashes:image_mourningdovesoftsunray");

for (%x=0;%x<12;%x++)
{
%compsprite_sun.addSprite();
%compsprite_sun.setSpriteLocalPosition(0,0);
%compsprite_sun.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%compsprite_sun.setSpriteImage("splashes:image_mourningdovesoftsunray",0);
%compsprite_sun.SetSpriteDepth(0);
%compsprite_sun.setSpriteBlendColor(1.0,1.0,1.0,0.5);
%compsprite_sun.setSpriteAngle(30*%x);
}

%compsprite_sun.Visible="false";
DotsandCritsscene.add(%compsprite_sun);

AssetDatabase.releaseAsset(%ass.getAssetId());

%ass=AssetDatabase.acquireAsset("splashes:image_torquelogo");

%torquelogo=new Sprite(sprite_torquelogo)
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="splashes:image_torquelogo";
Visible="false";
};
DotsandCritsscene.add(%torquelogo);

AssetDatabase.releaseAsset(%ass.getAssetId());

DotsandCritsscene.setGravity(0,0);
}

function splashes::destroy(%this)
{
DotsandCritsscene.clear();
}
