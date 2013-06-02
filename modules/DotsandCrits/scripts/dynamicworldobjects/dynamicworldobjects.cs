function class_dynamicworldobject::updatehealth(%this)
{
if (%this.health<=0){%this.safeDelete();}
}
