exec("./portals.cs");
exec("./loadplayerclass.cs");
exec("./loadlevel.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./healthdisplay.cs");
exec("./ai.cs");
exec("./npcs.cs");

function deathballvalley::create(%this)
{
echo("created deathballvalley");
}

function deathballvalley::destroy(%this)
{
echo("deathballvalley destroy() called");
if (isObject(%this.loadedscene))
{
%this.loadedscene.delete();
}
createDotsandCritsscene();
}
