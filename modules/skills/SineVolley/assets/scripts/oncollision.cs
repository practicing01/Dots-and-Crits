function class_sinevolleyprojectile::onCollision(%this,%object,%collisionDetails)
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

%explosion=new Sprite()
{
Position=%object.Position;
Size=ScaleAssSizeVectorToCam(SineVolley.explosionass);
Image="SineVolley:image_explosion";
GravityScale="0";
};
DotsandCritsscene.add(%explosion);
%explosion.playAnimation("SineVolley:anim_explosion");

sinevolleydecay(%this);

schedule(1000,0,"ontimerdelete",%explosion);

}
