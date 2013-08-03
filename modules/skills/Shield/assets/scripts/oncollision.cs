function class_shield::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=10;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
if (%object.health>0)
{
%object.health-=10;
%object.updatehealth();
}
}
/*//use own shield explosion gfx so the module can store the asset onload
%ass=0;
%img=0;
%anim=0;
if ($view==0)
{
%ass=AssetDatabase.acquireAsset("Projectile:image_topdown_explosion");
%img="Projectile:image_topdown_explosion";
%anim="Projectile:anim_topdown_explosion";
}
else
{
%ass=AssetDatabase.acquireAsset("Projectile:image_sideview_explosion");
%img="Projectile:image_sideview_explosion";
%anim="Projectile:anim_sideview_explosion";
}

%explosion=new Sprite()
{
Position=%this.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
GravityScale="0";
BodyType="static";
};
DotsandCritsscene.add(%explosion);
%explosion.playAnimation(%anim);
%explosion.setBlendAlpha(0.25);

AssetDatabase.releaseAsset(%ass.getAssetId());

schedule(1000,0,"ontimerdelete",%explosion);
*/
%this.health-=10;//shield health
if (%this.health<=0)
{
%this.safeDelete();
}

}
