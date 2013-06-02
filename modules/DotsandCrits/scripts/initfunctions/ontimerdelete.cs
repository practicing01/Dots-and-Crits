function ontimerdelete(%sceneobject)
{
if (isObject(%sceneobject))
{
%sceneobject.safeDelete();
}
}
