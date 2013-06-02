function class_projectile::onMoveToComplete(%this)
{
if (isObject(%this))
{
cancel(%this.parenthandle.schedule_decay);

%this.parenthandle.current_destination_vector++;
if (%this.parenthandle.current_destination_vector>=%this.parenthandle.wavevectors.getCount())
{

%ass=0;
%img=0;
%anim=0;
if ($view==0)
{
%ass=Projectile.top_explosionass;
%img="Projectile:image_topdown_explosion";
%anim="Projectile:anim_topdown_explosion";
}
else
{
%ass=Projectile.side_explosionass;
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

schedule(1000,0,"ontimerdelete",%explosion);

projectiledecay(%this);
return;
}
%dest="0 0";
%dest.X=%this.parenthandle.wavevectors.getObject(%this.parenthandle.current_destination_vector).x;
%dest.Y=%this.parenthandle.wavevectors.getObject(%this.parenthandle.current_destination_vector).y;
%this.moveTo(%dest,10,1,1);

%speed=10;
%time=((Vector2Distance(%this.Position,%dest)/%speed)*1000)+1000;
%this.parenthandle.schedule_decay=schedule(%time,0,"projectiledecay",%this);
}
}

