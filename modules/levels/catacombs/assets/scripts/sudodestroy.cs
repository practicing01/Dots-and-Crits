//this function unloads level assets

function catacombs::sudodestroy(%this)
{

alxStopAll();

if (isObject(gui_catacombsscore))
{
gui_catacombsscore.delete();
}

%this.p1moduleid.ScopeSet.unloadass();
%this.p2moduleid.ScopeSet.unloadass();
}
