exec("./portals.cs");
exec("./loadlevel.cs");
exec("./loadplayerclass.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./healthdisplay.cs");
exec("./ai.cs");
exec("./npcs.cs");

function catacombs::create(%this)//change catacombs to your module name
{
echo("created catacombs");
}

function catacombs::destroy(%this)
{
echo("catacombs destroy() called");
if (isObject(%this.loadedscene))
{
%this.loadedscene.delete();
}
createDotsandCritsscene();
}
