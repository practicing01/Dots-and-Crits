exec("./portals.cs");
exec("./loadplayerclass.cs");
exec("./levelgeneration/worldlimits.cs");
exec("./levelgeneration/spawnportals.cs");
exec("./levelgeneration/floortiles.cs");
exec("./levelgeneration/walls.cs");
exec("./loadass.cs");
exec("./unloadass.cs");
exec("./loadlevel.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./healthdisplay.cs");
exec("./ai.cs");
exec("./npcs.cs");

function ZombieBox::create(%this)//change ZombieBox to your module name
{
echo("created ZombieBox");
}

function ZombieBox::destroy(%this)
{
echo("ZombieBox destroy() called");
if (isObject(%this.loadedscene))
{
%this.loadedscene.delete();
}
createDotsandCritsscene();
}
