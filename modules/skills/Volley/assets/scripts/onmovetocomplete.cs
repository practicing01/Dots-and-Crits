function class_Volleyprojectile::onMoveToComplete(%this)
{
if (isObject(%this))
{
cancel(%this.parenthandle.schedule_decay);

%this.parenthandle.current_destination_vector++;
if (%this.parenthandle.current_destination_vector>=%this.parenthandle.wavevectors.getCount())
{

%explosion=new Sprite()
{
Position=%this.Position;
Size=ScaleAssSizeVectorToCam(Volley.explosionass);
Image="Volley:image_explosion";
GravityScale="0";
};
DotsandCritsscene.add(%explosion);
%explosion.playAnimation("Volley:anim_explosion");

schedule(1000,0,"ontimerdelete",%explosion);

%this.volleydecay();
return;
}
%dest="0 0";
%dest.X=%this.parenthandle.wavevectors.getObject(%this.parenthandle.current_destination_vector).x;
%dest.Y=%this.parenthandle.wavevectors.getObject(%this.parenthandle.current_destination_vector).y;
%this.moveTo(%dest,10,1,1);

////////////////////
%this.setAngle(Vector2AngleToPoint(%this.Position,%dest));
////////////////////

%speed=10;
%time=((Vector2Distance(%this.Position,%dest)/%speed)*1000)+1000;
%this.parenthandle.schedule_decay=schedule(%time,0,"class_Volleyprojectile::volleydecay",%this);
}
}
