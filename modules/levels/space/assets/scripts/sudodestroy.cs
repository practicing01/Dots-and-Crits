function space::sudodestroy(%this)
{

alxStopAll();

if (isObject(gui_spacescore))
{
gui_spacescore.delete();
}

%this.p1moduleid.ScopeSet.unloadass();
%this.p2moduleid.ScopeSet.unloadass();
}
