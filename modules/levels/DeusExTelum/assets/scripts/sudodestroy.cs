//this function unloads level assets

function DeusExTelum::sudodestroy(%this)
{

alxStopAll();

if (isObject(gui_DeusExTelumscore))
{
gui_DeusExTelumscore.delete();
}

%this.unloadass();

%this.p1moduleid.ScopeSet.unloadass();
%this.p2moduleid.ScopeSet.unloadass();
}
