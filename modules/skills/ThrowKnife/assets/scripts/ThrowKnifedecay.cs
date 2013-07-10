function ThrowKnifedecay(%ThrowKnife)
{
if (isObject(%ThrowKnife))
{
%ThrowKnife.cancelMoveTo();
%ThrowKnife.parenthandle.wavevectors.deleteObjects();
%ThrowKnife.parenthandle.wavevectors.delete();
cancel(%ThrowKnife.parenthandle.schedule_decay);
%parenthandle=%ThrowKnife.parenthandle;
%ThrowKnife.safeDelete();
%parenthandle.delete();
}
}
