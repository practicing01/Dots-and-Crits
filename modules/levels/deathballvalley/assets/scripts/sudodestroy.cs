function deathballvalley::sudodestroy(%this)
{
if (isObject(gui_deathballvalleyscore))
{
gui_deathballvalleyscore.delete();
}

%this.p1moduleid.ScopeSet.unloadass();
%this.p2moduleid.ScopeSet.unloadass();
}
