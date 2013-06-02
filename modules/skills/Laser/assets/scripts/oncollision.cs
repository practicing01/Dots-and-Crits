function class_Laser::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=1;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
%object.health-=1;
%object.updatehealth();
}

%ass=0;
%img=0;
%anim=0;
if ($view==0)
{
%ass=Laser.top_explosionass;
%img="Laser:image_topdown_explosion";
%anim="Laser:anim_topdown_explosion";
}
else
{
%ass=Laser.side_explosionass;
%img="Laser:image_sideview_explosion";
%anim="Laser:anim_sideview_explosion";
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

}
