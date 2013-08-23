function class_visibleparticle::decay(%this)
{
if (isObject(%this))
{
%this.safeDelete();
}
}
