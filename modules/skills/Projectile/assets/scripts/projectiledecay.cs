//function Projectile::projectiledecay(%this,%projectile)//this doesn't work
function projectiledecay(%projectile)
{
if (isObject(%projectile))
{
%projectile.cancelMoveTo();
%projectile.parenthandle.wavevectors.deleteObjects();
%projectile.parenthandle.wavevectors.delete();
cancel(%projectile.parenthandle.schedule_decay);
%parenthandle=%projectile.parenthandle;
%projectile.safeDelete();
%parenthandle.delete();
}
}
