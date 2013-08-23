exec("./portals.cs");
exec("./loadplayerclass.cs");
exec("./levelgeneration/worldlimits.cs");
exec("./levelgeneration/spawnportals.cs");
exec("./levelgeneration/floortiles.cs");
exec("./levelgeneration/walls.cs");
exec("./levelgeneration/decals.cs");
exec("./levelgeneration/dwos.cs");
exec("./levelgeneration/npcs.cs");
exec("./loadass.cs");
exec("./unloadass.cs");
exec("./loadlevel.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./healthdisplay.cs");
exec("./ai.cs");
exec("./npcs.cs");
exec("./radiation/radiation.cs");
exec("./goal/goal.cs");

function DeusExTelum::create(%this)//change DeusExTelum to your module name
{
echo("created DeusExTelum");
}

function DeusExTelum::destroy(%this)
{
echo("DeusExTelum destroy() called");
if (isObject(%this.loadedscene))
{
%this.loadedscene.delete();
}
createDotsandCritsscene();
}
