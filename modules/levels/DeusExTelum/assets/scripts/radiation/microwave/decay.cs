function class_microwaveparticle::decay(%this)
{
if (isObject(%this))
{
%this.safeDelete();
}
}
