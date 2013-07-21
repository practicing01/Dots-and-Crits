function class_Wave::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=10;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
%object.health-=10;
%object.updatehealth();
}

%ass=0;
%img=0;
%anim=0;
%waveanim=0;
if ($view==0)
{
%ass=Wave.top_explosionass;
%img="Wave:image_topdown_explosion";
%anim="Wave:anim_topdown_explosion";
%waveanim="Wave:anim_topdown_Wave";
}
else
{
%ass=Wave.side_explosionass;
%img="Wave:image_sideview_explosion";
%anim="Wave:anim_sideview_explosion";
%waveanim="Wave:anim_sideview_Wave";
}

%explosion=new Sprite()
{
Position=%object.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
GravityScale="0";
BodyType="static";
};
DotsandCritsscene.add(%explosion);
%explosion.playAnimation(%anim);
%explosion.setBlendAlpha(0.25);

schedule(1000,0,"ontimerdelete",%explosion);

if (%object.SceneGroup==30||%object.SceneGroup==28||%object.SceneGroup==29)//walls, projectiles
{

%this.playAnimation(%waveanim);

}

}
