exec("./portals.cs");
exec("./audio.cs");
exec("./spawnplayers.cs");
exec("./loadplayerclass.cs");
exec("./loadlevel.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./dynamicworldobjects/gates/gates.cs");

function bitweb::create(%this)
{
echo("created bitweb");
}

function bitweb::destroy(%this)
{
echo("bitweb destroy() called");
if (isObject(%this.loadedscene))
{
%this.loadedscene.delete();
}
createDotsandCritsscene();
}
