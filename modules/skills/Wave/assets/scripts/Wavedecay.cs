function class_Wave::Wavedecay(%this)
{
if (isObject(%this))
{
%this.cancelMoveTo();
%this.parenthandle.wavevectors.deleteObjects();
%this.parenthandle.wavevectors.delete();
cancel(%this.parenthandle.schedule_decay);
%parenthandle=%this.parenthandle;
%this.safeDelete();
%parenthandle.delete();
}
}
