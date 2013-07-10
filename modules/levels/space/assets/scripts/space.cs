exec("./portals.cs");
exec("./loadplayerclass.cs");
exec("./loadlevel.cs");
exec("./menuicon.cs");
exec("./sudodestroy.cs");
exec("./healthdisplay.cs");
exec("./ai.cs");

function space::create(%this)
{
echo("created space");
}

function space::destroy(%this)
{
echo("space destroy() called");
if (isObject(%this.loadedscene))
{
%this.loadedscene.delete();
}
createDotsandCritsscene();
}
