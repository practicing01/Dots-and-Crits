exec("./portals.cs");
exec("./loadlevel.cs");
exec("./loadplayerclass.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./healthdisplay.cs");
exec("./ai.cs");

function catacombs::create(%this)
{
echo("created catacombs");
}

function catacombs::destroy(%this)
{
echo("catacombs destroy() called");
%this.loadedscene.delete();
createDotsandCritsscene();
}
