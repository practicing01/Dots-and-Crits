function Wavedecay(%Wave)
{
if (isObject(%Wave))
{
%Wave.cancelMoveTo();
%Wave.parenthandle.wavevectors.deleteObjects();
%Wave.parenthandle.wavevectors.delete();
cancel(%Wave.parenthandle.schedule_decay);
%parenthandle=%Wave.parenthandle;
%Wave.safeDelete();
%parenthandle.delete();
}
}
