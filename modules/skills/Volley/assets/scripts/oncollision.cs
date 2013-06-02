function class_Volleyprojectile::onCollision(%this,%object,%collisionDetails)
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
Size=ScaleAssSizeVectorToCam(Volley.explosionass);
Image="Volley:image_explosion";
GravityScale="0";
};
DotsandCritsscene.add(%explosion);
%explosion.playAnimation("Volley:anim_explosion");

volleydecay(%this);

schedule(1000,0,"ontimerdelete",%explosion);

}
