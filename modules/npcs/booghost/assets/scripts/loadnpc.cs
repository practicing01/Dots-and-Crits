function booghost::loadnpc(%this)
{

%player=$players.getObject(0);
%playerspritesize=%player.sprite.getSpriteSize();

%booghostass=AssetDatabase.acquireAsset("booghost:image_booghost");

%booghost=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%booghostass);
Image="booghost:image_booghost";
class="class_booghost";
CollisionCallback=true;
SceneGroup=25;//npc
FixedAngle=true;
SceneLayer=15;
};
DotsandCritsscene.add(%booghost);
%collisionshapeindex=%booghost.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%booghostass));

%booghost.setCollisionShapeIsSensor(%collisionshapeindex,true);
%booghost.setCollisionGroups(0,1,25);

%booghostsize=%booghost.getSize();

//set position
if (%player.curdir==0)//up
{
%booghost.Position.Y-=(%playerspritesize.Y)+(%booghostsize.Y/2);
}
else if (%player.curdir==1)//down
{
%booghost.Position.Y+=(%playerspritesize.Y)+(%booghostsize.Y/2);
}
else if (%player.curdir==2)//left
{
%booghost.Position.X+=(%playerspritesize.X)+(%booghostsize.X/2);
}
else if (%player.curdir==3)//right
{
%booghost.Position.X-=(%playerspritesize.X)+(%booghostsize.X/2);
}

AssetDatabase.releaseAsset(%booghostass.getAssetId());

///////////////////////////////////////////////////////

%booghost.initialize();

}//end loadnpc
