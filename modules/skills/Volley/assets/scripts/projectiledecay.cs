function volleydecay(%projectile)
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
