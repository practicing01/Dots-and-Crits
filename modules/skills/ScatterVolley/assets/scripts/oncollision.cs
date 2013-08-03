function class_ScatterVolley::onCollision(%this,%object,%collisionDetails)
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

%ass=0;
%img=0;
%anim=0;
if ($view==0)
{
%ass=ScatterVolley.top_explosionass;
%img="ScatterVolley:image_topdown_explosion";
%anim="ScatterVolley:anim_topdown_explosion";
}
else
{
%ass=ScatterVolley.side_explosionass;
%img="ScatterVolley:image_sideview_explosion";
%anim="ScatterVolley:anim_sideview_explosion";
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

ScatterVolleydecay(%this);

schedule(1000,0,"ontimerdelete",%explosion);

}
