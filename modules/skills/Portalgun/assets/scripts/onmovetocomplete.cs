function class_portalprojectile::onMoveToComplete(%this)
{
if (isObject(%this))
{
cancel(%this.parenthandle.schedule_decay);

%this.parenthandle.current_destination_vector++;
if (%this.parenthandle.current_destination_vector>=%this.parenthandle.wavevectors.getCount())
{
%this.portalprojectiledecay();
return;
}
%dest="0 0";
%dest.X=%this.parenthandle.wavevectors.getObject(%this.parenthandle.current_destination_vector).x;
%dest.Y=%this.parenthandle.wavevectors.getObject(%this.parenthandle.current_destination_vector).y;
%this.moveTo(%dest,10,1,1);

%speed=10;
%time=((Vector2Distance(%this.Position,%dest)/%speed)*1000)+1000;
%this.parenthandle.schedule_decay=schedule(%time,0,"class_portalprojectile::portalprojectiledecay",%this);
}
}

