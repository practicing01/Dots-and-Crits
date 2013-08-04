function Lelur::setmenuiconvisible(%this)//change Lelur to your module's name
{
if (!$player_to_load)//player 1
{
if (isObject($player1menuiconsprite))
{
$player1menuiconsprite.safeDelete();
}
}
else//player 2
{
if (isObject($player2menuiconsprite))
{
$player2menuiconsprite.safeDelete();
}
}

%ass=AssetDatabase.acquireAsset("Lelur:image_menuicon");//change Lelur to your module's name

if (!$player_to_load)//player 1
{

%pos="0 0";
%pos.X=$resolution.X/8;
%pos.Y=$resolution.Y/4;

$player1menuiconsprite=new Sprite()
{
Position=ScalePositionVectorToCam(%pos);
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="Lelur:image_menuicon";//change Lelur to your module's name
Visible="true";
};
DotsandCritsscene.add($player1menuiconsprite);

AssetDatabase.releaseAsset(%ass.getAssetId());

$player1menuiconsprite.playAnimation("Lelur:anim_menuicon");//change Lelur to your module's name
}
else//player 2
{

%pos="0 0";
%pos.X=($resolution.X/8)*7;
%pos.Y=$resolution.Y/4;

$player2menuiconsprite=new Sprite()
{
Position=ScalePositionVectorToCam(%pos);
Size=ScaleAssSizeVectorToCam(%ass);
BodyType="static";
Image="Lelur:image_menuicon";//change Lelur to your module's name
Visible="true";
};
DotsandCritsscene.add($player2menuiconsprite);

$player2menuiconsprite.playAnimation("Lelur:anim_menuicon");//change Lelur to your module's name
}

}
