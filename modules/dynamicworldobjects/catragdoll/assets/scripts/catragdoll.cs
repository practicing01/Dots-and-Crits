exec("./loaddwo.cs");

function catragdoll::create(%this)
{
echo("created catragdoll");
}

function catragdoll::destroy(%this)
{
echo("freed catragdoll");
}

function class_catragdollbodypart::updatehealth(%this)
{
if (%this.health<=0){%this.safeDelete();}
}
